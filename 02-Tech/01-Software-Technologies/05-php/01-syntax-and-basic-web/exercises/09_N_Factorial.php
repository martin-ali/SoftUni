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
		$end = intval($_GET['num']);
		$factorial = 1;
		for ($current = 1; $current <= $end; $current++)
		{
			$factorial *= $current;
		}

		echo $factorial;
	}

	?>
</body>
</html>