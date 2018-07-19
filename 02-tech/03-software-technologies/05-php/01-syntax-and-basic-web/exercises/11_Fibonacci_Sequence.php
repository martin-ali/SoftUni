<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num"/>
        <input type="submit"/>
    </form>
</body>
</html>
<?php
if (isset($_GET['num']))
{
	$fibonacci = intval($_GET['num']);
	$fibonacciNumbers = array(1, 1);
	for ($current = count($fibonacciNumbers); $current < $fibonacci; $current++)
	{
		$currentFibonacci = $fibonacciNumbers[$current - 1] + $fibonacciNumbers[$current - 2];
		$fibonacciNumbers[] = $currentFibonacci;
	}

	echo implode(' ', $fibonacciNumbers);
}
?>

