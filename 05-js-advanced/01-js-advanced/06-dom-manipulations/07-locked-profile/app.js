function lockedProfile()
{
    const profiles = document.getElementsByClassName('profile');

    for (const profile of [...profiles])
    // for (const profile of Array.from(profiles))
    {
        const additionalInfo = profile.getElementsByTagName('div')[0];
        const showMoreButton = profile.getElementsByTagName('button')[0];
        const lockRadioButton = profile.getElementsByTagName('input')[0]

        showMoreButton.addEventListener('click', event =>
        {
            const lockStatus = profile.querySelector('input[type=radio]:checked').value;

            if (lockStatus === 'lock')
            {
                return;
            }

            if (additionalInfo.style.display !== 'none')
            {
                additionalInfo.style.display = 'block';
                showMoreButton.textContent = 'Hide it';
            }
            else if (showMoreButton.textContent === 'Hide it')
            {
                additionalInfo.style.display = 'none';
                showMoreButton.textContent = 'Show more';
            }
        });
    }
}