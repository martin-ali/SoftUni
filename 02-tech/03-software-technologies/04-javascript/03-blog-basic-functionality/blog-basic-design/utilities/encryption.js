const crypto = require('crypto');

const cryptography = {
    /**
     * @returns {string}
     */
    generateSalt: () =>
    {
        const salt = crypto
            .randomBytes(128)
            .toString('base64');

        return salt;
    },

    /**
     * @param {string} password
     * @param {string} hashPassword
     * @returns {string}
     */
    hashPassword: (password, salt) =>
    {
        const passwordHash = crypto
            .createHmac('sha256', salt)
            .update(password)
            .digest('hex');

        return passwordHash;
    }
};

module.exports = cryptography;