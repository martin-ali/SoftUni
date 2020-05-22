function getFibonator()
{
    const fibonacciNumbers = [0, 1];
    let currentFibonacciCount = 1;

    return function ()
    {
        const currentFibonacci = fibonacciNumbers[0] + fibonacciNumbers[1];
        if (currentFibonacciCount >= 2)
        {

            fibonacciNumbers.shift();
            fibonacciNumbers.push(currentFibonacci);
        }

        currentFibonacciCount++;

        return currentFibonacci;
    }
}

// let fib = getFibonator();
// console.log(fib()); // 1
// console.log(fib()); // 1
// console.log(fib()); // 2
// console.log(fib()); // 3
// console.log(fib()); // 5
// console.log(fib()); // 8
// console.log(fib()); // 13