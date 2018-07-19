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
	$tribonacci = intval($_GET['num']);
	$tribonacciNumbers = array(1, 1, 2);
	for ($current = count($tribonacciNumbers); $current < $tribonacci; $current++)
	{
		$currentTribonacci = $tribonacciNumbers[$current - 1]
			+ $tribonacciNumbers[$current - 2]
			+ $tribonacciNumbers[$current - 3];
		$tribonacciNumbers[] = $currentTribonacci;
	}

	echo implode(' ', $tribonacciNumbers);
}
?>