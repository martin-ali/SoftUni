function getTimeToWalk(stepsCount, stepLengthInMeters, StudentSpeedInKmH)
{
    'use strict';

    const distanceToUniversityInMeters = stepsCount * stepLengthInMeters;
    const studentSpeedInMetersPerSecond = StudentSpeedInKmH / 3.6;
    const breaksCount = Math.floor(distanceToUniversityInMeters / 500);
    const secondsSpentInBreak = breaksCount * 60;
    let secondsTravel = distanceToUniversityInMeters / studentSpeedInMetersPerSecond + secondsSpentInBreak;

    let hoursNeeded = 0;
    if (secondsTravel >= 3600)
    {
        hoursNeeded = Math.floor(secondsTravel / 3600);
        secondsTravel = secondsTravel % 3600;
    }

    let minutesNeeded = 0;
    if (secondsTravel >= 60)
    {
        minutesNeeded = Math.floor(secondsTravel / 60);
        secondsTravel = secondsTravel % 60;
    }

    let secondsNeeded = Math.round(secondsTravel);

    let hours = String(hoursNeeded).padStart(2, "0");
    let minutes = String(minutesNeeded).padStart(2, "0");
    let seconds = String(secondsNeeded).padStart(2, "0");

    const result = `${hours}:${minutes}:${seconds}`;

    return result;
}