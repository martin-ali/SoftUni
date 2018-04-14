<head>
    <style>
        div {
            display: inline-block;
            width: 150px;
            padding: 2px;
            margin: 5px;
        }
    </style>
</head>
<body>
<?php
for ($red = 0; $red < 256; $red += 51)
{
	for ($green = 0; $green < 256; $green += 51)
	{
		for ($blue = 0; $blue < 256; $blue += 51)
		{
			echo "<div style='background: rgb($red, $green, $blue)'>rgb($red, $green, $blue)</div>";
		}
	}
}
?>
</body>