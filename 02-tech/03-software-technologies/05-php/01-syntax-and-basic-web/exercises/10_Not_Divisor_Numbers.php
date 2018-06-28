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
		$numbers = array();
		for ($current = $num; $current >= 1; $current--)
		{
			if ($num % $current !== 0)
			{
				$numbers[] = $current;
			}
		}

		echo implode(' ', $numbers);
	}

	?>
</body>
</html>