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
    <!--    <ul>
	 </ul>-->
</body>
</html>
<?php
if (isset($_GET['num1']) &&
	isset($_GET['num2']))
{
	function indent(int $level): string
	{
		return str_repeat('    ', $level);
	}

	$outerLiCount = intval($_GET['num1']);
	$innerLiCount = intval($_GET['num2']);

	echo '<ul>';
	for ($outerLi = 1; $outerLi <= $outerLiCount; $outerLi++)
	{
		echo indent(1) . "<li>List $outerLi";
		echo indent(2) . "<ul>";

		for ($innerLi = 1; $innerLi <= $innerLiCount; $innerLi++)
		{
			echo indent(3) . "<li>";
			echo indent(4) . "Element $outerLi.$innerLi";
			echo indent(3) . "</li>";
		}

		echo indent(2) . "</ul>";
		echo indent(1) . "</li>";
	}
	echo '</ul>';
}
?>