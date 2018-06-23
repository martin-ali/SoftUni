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
	<?php
	if (isset($_GET['num1']) &&
		isset($_GET['num2']) &&
		isset($_GET['num2']))
	{
		$num1 = intval($_GET['num1']);
		$num2 = intval($_GET['num2']);
		$num3 = intval($_GET['num3']);

		$numbers = array($num1, $num2, $num3);

		$zeroContained = false;
		$resultSign = true;
		foreach ($numbers as $number)
		{
			if ($number === 0)
			{
				$zeroContained = true;
				break;
			}

			// Don't need to count, just flip a variable
			if ($number < 0)
			{
				$resultSign = !$resultSign;
			}
		}

		if ($zeroContained || $resultSign)
		{
			echo 'Positive';
		}
		else
		{
			echo 'Negative';
		}
	}
	?>
</body>
</html>
