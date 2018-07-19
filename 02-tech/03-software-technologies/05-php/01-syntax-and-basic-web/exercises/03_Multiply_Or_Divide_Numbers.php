<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num1"/>
        M: <input type="text" name="num2"/>
        <input type="submit"/>
    </form>
</body>
</html>
<?php
if (isset($_GET['num1']) && isset($_GET['num2']))
{
	$firstNumber = $_GET['num1'];
	$secondNumber = $_GET['num2'];

	if ($firstNumber > $secondNumber)
	{
		$result = $firstNumber / $secondNumber;
	}
	else
	{
		$result = $firstNumber * $secondNumber;
	}

	echo $result;
}
?>