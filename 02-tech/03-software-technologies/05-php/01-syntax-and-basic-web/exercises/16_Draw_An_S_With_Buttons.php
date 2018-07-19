<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>
	<?php
	for ($row = 1; $row <= 9; $row++)
	{
		for ($col = 1; $col <= 5; $col++)
		{
			$correctRow = $row === 1 || $row === 5 || $row === 9;
			$correctCol = ($col === 1 && $row <= 5) || ($col === 5 && $row >= 5);

			if ($correctRow || $correctCol)
			{
				echo "<button style='background-color: blue'>1</button>";
			}
			else
			{
				echo "<button>0</button>";
			}
		}
		echo '<br/>';
	}
	?>
</body>
</html>
