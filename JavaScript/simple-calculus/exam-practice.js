// jshint esversion:6

function classroom([height, width])
{

}

function vegetableMarket([vegetablePrice, fruitPrice, vegetableWeight, fruitWeight])
{
    let totalVegetablePrice = vegetablePrice * vegetableWeight;
    let totalFruitPrice = fruitPrice * fruitWeight;

    let totalPriceOfAllItemsInEuros = (totalFruitPrice + totalVegetablePrice) / 1.94;
    return totalPriceOfAllItemsInEuros;
}

function tilesRepair()
{

}

function money([numberOfBtc, numberOfCny, commission])
{
    let btcToBgnCourse = 1168;
    let UsdToBgnCourse = 1.76;
    let EurToBgnCourse = 1.95;
    let cnyToDollarCourse = 0.15;

    let eurValueOfBtc = (numberOfBtc * btcToBgnCourse);
    let eurValueOfCny = (numberOfCny * cnyToDollarCourse) * UsdToBgnCourse;

    let valueBeforeCommission = eurValueOfBtc + eurValueOfCny;
    let valueAfterCommission = valueBeforeCommission - (commission / 100 * valueBeforeCommission);
    let valueConvertedToEur = valueAfterCommission / EurToBgnCourse;

    let totalEurosAfterExchange = valueConvertedToEur.toFixed(2);
    return totalEurosAfterExchange;
}

// console.log(money([1, 5, 5]));
// console.log(money([20, 5678, 2.4]));

function dailyEarnings([workingDaysInMonth, dailyEarnings, bgnToUsdCourse])
{
    let monthlyEarnings = workingDaysInMonth * dailyEarnings;
    let bonusEarnings = monthlyEarnings * 2.5;
    let yearlyEarnings = (monthlyEarnings * 12);
    let tax = (yearlyEarnings + bonusEarnings) / 4;

    let totalYearlyEarnings = yearlyEarnings + bonusEarnings - tax;

    let averageDailyEarningsInBgn = (totalYearlyEarnings / 365) * bgnToUsdCourse;
    return averageDailyEarningsInBgn.toFixed(2);
}