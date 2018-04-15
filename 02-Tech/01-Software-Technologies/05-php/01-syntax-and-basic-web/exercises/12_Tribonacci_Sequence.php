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

	function sumLastThreeNumbers(array $arr): int
	{
		$sum = array_sum(array_slice($arr, -3, 3, true));
		return intval($sum);
	}

	if (isset($_GET['num']))
	{
		$num = intval($_GET['num']);
		$tribonacciNumbers = array(0, 1, 1);

		for ($current = 1; $current < $num; $current++)
		{
			$tribonacciNumbers[] = sumLastThreeNumbers($tribonacciNumbers);
		}

		echo implode(' ', $tribonacciNumbers);
	}

	?>
</body>
</html>