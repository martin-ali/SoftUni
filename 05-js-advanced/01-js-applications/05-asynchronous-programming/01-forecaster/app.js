// Won't clear on second request, but no such requirement was mentioned in the description
function attachEvents()
{
    function generateDataSpan(data, spanClass)
    {
        const span = document.createElement('span');

        span.classList.add(spanClass);
        span.textContent = data;

        return span;
    }

    function generateWeatherCard(weatherInformation, containerClass)
    {
        const container = document.createElement('span');
        container.classList.add(containerClass);

        if (weatherInformation.symbol)
        {
            const symbolSpan = generateDataSpan(weatherInformation.symbol, 'symbol');

            container.appendChild(symbolSpan);
        }

        for (const data in weatherInformation.forecastData)
        {
            const dataSpan = generateDataSpan(weatherInformation.forecastData[data], 'forecast-data');

            container.appendChild(dataSpan);
        }

        return container;
    }

    function generateCurrentWeatherDiv(weather, weatherSymbol, degreesSymbol)
    {
        const container = document.createElement('div');
        container.classList.add('forecasts');

        const symbolSpan = document.createElement('span');
        symbolSpan.classList.add('condition');
        symbolSpan.classList.add('symbol');
        symbolSpan.textContent = weatherSymbol;
        container.appendChild(symbolSpan);

        const weatherInformation = {
            forecastData:
            {
                name: weather.name,
                temperature: `${weather.forecast.low}${degreesSymbol}/${weather.forecast.high}${degreesSymbol}`,
                condition: weather.forecast.condition
            }
        };
        const weatherCard = generateWeatherCard(weatherInformation, 'condition');
        container.appendChild(weatherCard);

        return container;
    }

    function generateUpcomingWeatherDiv(weatherDays, weatherSymbols, degreesSymbol)
    {
        const container = document.createElement('div');
        container.classList.add('forecast-info');

        for (const day of weatherDays)
        {
            const symbol = weatherSymbols[day.condition]
            const weatherInformation = {
                symbol,
                forecastData:
                {
                    temperature: `${day.low}${degreesSymbol}/${day.high}${degreesSymbol}`,
                    condition: day.condition
                }
            };
            const weatherCard = generateWeatherCard(weatherInformation, 'upcoming');
            container.appendChild(weatherCard);
        }

        return container;
    }

    const getWeatherButton = document.getElementById('submit');
    const degrees = '°';
    const symbolByCondition = {
        'Sunny': '☀',
        'Partly sunny': '⛅',
        'Overcast': '☁',
        'Rain': '☂',
    };

    getWeatherButton.addEventListener('click', async event =>
    {
        const requestedLocation = document.getElementById('location').value;
        const locationsAndCodesJson = await http.getAsync(' https://judgetests.firebaseio.com/locations.json');
        const locationsAndCodes = JSON.parse(locationsAndCodesJson);

        document.getElementById('forecast').style.display = 'block';

        const { name: location, code } = locationsAndCodes.find(x => x.name === requestedLocation);

        // Works in parallel :)
        http.getAsync(`https://judgetests.firebaseio.com/forecast/today/${code}.json `)
            .then(currentWeatherJson =>
            {
                const currentWeather = JSON.parse(currentWeatherJson);
                const currentWeatherDiv = document.getElementById('current');
                const currentForecastDiv = generateCurrentWeatherDiv(currentWeather, symbolByCondition[currentWeather.forecast.condition], degrees);

                currentWeatherDiv.appendChild(currentForecastDiv);
            });

        http.getAsync(`https://judgetests.firebaseio.com/forecast/upcoming/${code}.json`)
            .then(upcomingWeatherJson =>
            {
                const upcomingWeather = JSON.parse(upcomingWeatherJson).forecast;
                const upcomingWeatherDiv = document.getElementById('upcoming');
                const upcomingForecastDiv = generateUpcomingWeatherDiv(upcomingWeather, symbolByCondition, degrees);

                upcomingWeatherDiv.appendChild(upcomingForecastDiv);
            });
    });
}

attachEvents();