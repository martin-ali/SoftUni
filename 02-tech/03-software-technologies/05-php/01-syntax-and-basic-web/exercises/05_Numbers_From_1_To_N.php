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
	$limit = intval($_GET['num']);
	$numbers = array();
	for ($number = 1; $number <= $limit; $number++)
	{
		$numbers[] = $number;
	}

	echo implode(' ', $numbers);
}
?>