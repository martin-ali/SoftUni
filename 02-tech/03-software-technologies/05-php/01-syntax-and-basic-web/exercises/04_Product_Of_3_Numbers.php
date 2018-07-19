<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        X: <input type="text" name="num1"/>
        Y: <input type="text" name="num2"/>
        Z: <input type="text" name="num3"/>
        <input type="submit"/>
    </form>
</body>
</html>
<?php
if (isset($_GET['num1']) &&
	isset($_GET['num2']) &&
	isset($_GET['num3']))
{
	$firstNumber = intval($_GET['num1']);
	$secondNumber = intval($_GET['num2']);
	$thirdNumber = intval($_GET['num3']);

	$resultIsPositive = true;
	$numbers = array($firstNumber, $secondNumber, $thirdNumber);
	foreach ($numbers as $number)
	{
		if ($number < 0)
		{
			$resultIsPositive = !$resultIsPositive;
		}
        elseif ($number === 0)
		{
			$resultIsPositive = true;
			break;
		}
	}

	$result = $resultIsPositive ? 'Positive' : 'Negative';
	echo $result;
}
?>
