class CheckingAccount
{
    cliendId;
    email;
    firstName;
    lastName;

    constructor(clientId, email, firstName, lastName)
    {
        const idValidationPattern = new RegExp('^\\d{6}$');
        if (!clientId.match(idValidationPattern))
        {
            throw new TypeError('Client ID must be a 6-digit number');
        }

        const emailValidationPattern = new RegExp('^(\\w|\\d)+@(\\w|\\d|\\.)+$');
        if (!email.match(emailValidationPattern))
        {
            throw new TypeError('Invalid e-mail');
        }

        this.throwIfInvalidName(firstName, 'firstName');
        this.throwIfInvalidName(lastName, 'lastName');

        this.cliendId = clientId;
        this.email = email;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    getErrorTextName(name)
    {
        const lowerCaseName = name.toLowerCase();
        const splitName = lowerCaseName.replace('n', ' n');
        const capitalisedName = splitName[0].toUpperCase() + splitName.substring(1);

        return capitalisedName;
    }

    throwIfInvalidName(name, parameterName)
    {
        const nameLengthIsValid = 3 <= name.length && name.length <= 20;
        const badParameter = this.getErrorTextName(parameterName);

        if (nameLengthIsValid === false)
        {
            throw new TypeError(`${badParameter} must be between 3 and 20 characters long`);
        }

        const nameValidationPattern = new RegExp('^\\w{3,20}$');
        if (!name.match(nameValidationPattern))
        {
            throw new TypeError(`${badParameter} must contain only Latin characters`);
        }
    }
}

// Bad id regex
// Bad email regex
// const acc = new CheckingAccount('1121332', 'a@d.as', 'aaaaa-aaaaa-aaaaa-aa', 'cas');