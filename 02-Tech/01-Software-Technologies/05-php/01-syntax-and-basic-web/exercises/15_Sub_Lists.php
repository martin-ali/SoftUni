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
    <ul>
		<?php

		if (isset($_GET['num1']) && isset($_GET['num2']))
		{
			$externalLi = intval($_GET['num1']);
			$internalLi = intval($_GET['num2']);

			for ($outerIndex = 1; $outerIndex <= $externalLi; $outerIndex++)
			{
				echo "<li>List $outerIndex";
				echo "<ul>";
				for ($innerIndex = 1; $innerIndex <= $internalLi; $innerIndex++)
				{
					echo "<li>Element $outerIndex.$innerIndex</li>";
				}
				echo "</ul>";
				echo "</li>";
			}
		}
		?>
    </ul>
</body>
</html>