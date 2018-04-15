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

	function isPrime(int $number): int
	{
		$numberIsPrime = true;

		for ($current = 2; $current < $number; $current++)
		{
			if ($number % $current == 0)
			{
				$numberIsPrime = false;
				break;
			}
		}

		return $numberIsPrime;
	}

	if (isset($_GET['num']))
	{
		// Sqrt also possible
		$num = intval($_GET['num']);
		$numbers = array();

		for ($current = $num; $current > 0; $current--)
		{
			if (isPrime($current))
			{
				$numbers[] = $current;
			}
		}

		echo implode(' ', $numbers);
	}
	?>
</body>
</html>