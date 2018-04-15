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
	<?php

	if (isset($_GET['num']))
	{
		$num = intval($_GET['num']);

		$fib1 = 1;
		$fib2 = 1;

		$fibonacci = 1;
		$fibonacciNumbers = array();

		for ($current = 1; $current < $num; $current++)
		{
			$fibonacciNumbers[] = $fibonacci;

			$fibonacci = $fib2 + $fib1;
			$fib2 = $fib1;
			$fib1 = $fibonacci;
		}

		echo implode(' ', $fibonacciNumbers);
	}

	?>
</body>
</html>