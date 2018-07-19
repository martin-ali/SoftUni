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
	$buttonCount = intval($_GET['num']);
	for ($count = 1; $count <= $buttonCount; $count++)
	{
		echo "<button>$count</button>";
	}
}
?>