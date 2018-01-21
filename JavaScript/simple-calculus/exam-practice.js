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

function money()
{

}

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