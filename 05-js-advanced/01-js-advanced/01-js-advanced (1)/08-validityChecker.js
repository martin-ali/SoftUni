function printDistancesValidity([x1, y1, x2, y2])
{
    function distanceBetweenPointsIsValid(x1, y1, x2, y2)
    {
        const horizontalDistance = Math.abs(x1 - x2);
        const verticalDistance = Math.abs(y1 - y2);

        const distance = Math.sqrt(horizontalDistance ** 2 + verticalDistance ** 2);
        const distanceIsValid = Number.isInteger(distance);

        return distanceIsValid;
    }

    function getPointComparisonInfo(x1, y1, x2, y2, result)
    {
        const state = result ? "valid" : "invalid";
        return `{${x1}, ${y1}} to {${x2}, ${y2}} is ${state}`;
    }

    const firstComparison = distanceBetweenPointsIsValid(x1, y1, 0, 0);
    const secondComparison = distanceBetweenPointsIsValid(x2, y2, 0, 0);
    const thirdComparison = distanceBetweenPointsIsValid(x1, y1, x2, y2);

    console.log(getPointComparisonInfo(x1, y1, 0, 0, firstComparison));
    console.log(getPointComparisonInfo(x2, y2, 0, 0, secondComparison));
    console.log(getPointComparisonInfo(x1, y1, x2, y2, thirdComparison));
}