function getSpeedingStatus([speed, area])
{
    const speedLimitsByArea = new Map();
    speedLimitsByArea.set("motorway", 130);
    speedLimitsByArea.set("interstate", 90);
    speedLimitsByArea.set("city", 50);
    speedLimitsByArea.set("residential", 20);

    if (speed > speedLimitsByArea.get(area) + 40)
    {
        return "reckless driving";
    }
    else if (speed > speedLimitsByArea.get(area) + 20)
    {
        return "excessive speeding";
    }
    else if (speed > speedLimitsByArea.get(area))
    {
        return "speeding";
    }
}