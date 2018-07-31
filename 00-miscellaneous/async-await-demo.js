function sleep(milliseconds)
{
    return new Promise(resolve => setTimeout(resolve, milliseconds));
}

// Async functions are executed in a new thread
async function log(task)
{
    // Await pauses code execution until it's done
    // So it sort of becomes single-threaded internally?
    await sleep(1000);
    console.log(`Task ${task}`);
}

(async function ()
{
    // No await means the code continues execution after parsing the line and calling the function
    await log(1);
    await log(2);
    log(3);
    log(4);
}());