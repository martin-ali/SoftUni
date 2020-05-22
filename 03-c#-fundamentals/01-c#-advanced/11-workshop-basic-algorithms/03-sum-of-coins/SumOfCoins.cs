using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        // var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        // var targetSum = 923;

        // var availableCoins = new[] { 1 };
        // var targetSum = 42;

        // var availableCoins = new[] { 3, 7 };
        // var targetSum = 11;

        // var availableCoins = new[] { 1, 2, 5 };
        // var targetSum = 2031154123;

        // var availableCoins = new[] { 1, 9, 10 };
        // var targetSum = 27;

        var availableCoins = new[] { 1, 2, 5, 10, 20, 50 };
        var targetSum = 923;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        var sortedCoins = coins.OrderByDescending(c => c);
        var countByCoinValue = new Dictionary<int, int>();
        var currentSum = 0;

        var currentTarget = targetSum;
        foreach (var coin in sortedCoins)
        {
            var leftover = currentTarget % coin;

            var coinCount = currentTarget / coin;
            if (coinCount != 0)
            {
                countByCoinValue[coin] = coinCount;
                currentSum += coinCount * coin;
            }

            currentTarget = leftover;
        }

        if (currentSum != targetSum)
        {
            throw new InvalidOperationException();
        }

        return countByCoinValue;
    }
}
