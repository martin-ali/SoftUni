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
	$primesCount = intval($_GET['num']);
	$primes = range(0, $primesCount + 1, 1);
	$primes[0] = false;
	$primes[1] = false;

	for ($primeCandidate = 2; $primeCandidate < count($primes); $primeCandidate++)
	{
		if ($primes[$primeCandidate])
		{
			$primes[$primeCandidate] = $primeCandidate;

			for ($primeToRemove = $primeCandidate * 2; $primeToRemove < count($primes); $primeToRemove += $primeCandidate)
			{
				$primes[$primeToRemove] = false;
			}
		}
	}

	$primesFiltered = array_filter($primes, function ($primeCandidate)
	{
		return !!$primeCandidate;
	});

	echo implode("\n", array_reverse($primesFiltered));
}
?>