<?php

function convertCelsiusToFahrenheit(float $celsius): float
{
	return $celsius * 1.8 + 32;
}

function convertFahrenheitToCelsius(float $fahrenheit): float
{
	return ($fahrenheit - 32) / 1.8;
}

$messageAfterCelsius = "";
$messageAfterFahrenheit = "";

if (isset($_GET['cel']))
{
	$cel = floatval($_GET['cel']);
	$fah = convertCelsiusToFahrenheit($cel);
	$messageAfterCelsius = "$cel &deg;C = $fah &deg;F";
}
else if (isset($_GET['fah']))
{
	$fah = floatval($_GET['fah']);
	$cel = convertFahrenheitToCelsius($fah);
	$messageAfterFahrenheit = "$fah &deg;F = $cel &deg;C";
}
?>
<form>
    Celsius: <input type="text" name="cel"/>
    <input type="submit" value="Convert"/>
	<?= $messageAfterCelsius ?>
</form>
<form>
    Fahrenheit: <input type="text" name="fah"/>
    <input type="submit" value="Convert"/>
	<?= $messageAfterFahrenheit ?>
</form>