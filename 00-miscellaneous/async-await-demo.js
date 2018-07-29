function logDone(value)
{
    return new Promise((resolve, reject) =>
    {
        setTimeout(resolve, 1000);
        console.log(`Did ${value}`)
    });
}

// Async functions are executed in a new thread
async function executeTasks()
{
    // Await pauses code execution until it's done
    // So it sort of becomes single-threaded internally?
    await logDone(1);
    await logDone(2);
    await logDone(3);
}

(async function ()
{
    // No await means the code continues execution after parsing the line and calling the function
    executeTasks();
    executeTasks();
    executeTasks();
})();