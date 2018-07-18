const passport = require('passport');
const localPassport = require('passport-local');
const User = require('../models').User;

const authenticateUser = (username, password, done) =>
{
    User
        .findOne({ email: username })
        .then(user =>
        {
            if (!user || !user.authenticate(password))
            {
                return done(null, false);
            }

            return done(null, user);
        });
}

module.exports = () =>
{
    // @ts-ignore
    passport.use(new localPassport({ usernameField: 'email', passwordField: 'password' }, authenticateUser));

    passport.serializeUser((user, done) =>
    {
        if (!user)
        {
            return done(null, false);
        }

        return done(null, user.id);
    });

    passport.deserializeUser((id, done) =>
    {
        User
            .findById(id)
            .then((user) =>
            {
                if (!user)
                {
                    return done(null, false);
                }

                return done(null, user);
            })
    })
};