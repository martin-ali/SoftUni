const authentication = {
    userIsLogged: () => !!sessionStorage.getItem('token'),
    logout: function ()
    {
        sessionStorage.clear();
        // @ts-ignore
        firebase.auth().signOut();
    },

    getUsername: () => sessionStorage.getItem('username'),
    setUsername: (username) => sessionStorage.setItem('username', username),

    getToken: () => sessionStorage.getItem('token'),
    setToken: (token) => sessionStorage.setItem('token', token),

    login: async function (username, password)
    {
        // @ts-ignore
        const response = await firebase
            .auth()
            .signInWithEmailAndPassword(username, password);

        // @ts-ignore
        const token = await firebase.auth().currentUser.getIdToken()

        this.setToken(token);
        this.setUsername(username);

    },

    register: async function (username, password)
    {
        // @ts-ignore
        const response = await firebase.auth().createUserWithEmailAndPassword(username, password);

        await this.login(username, password);
    }
};

export default authentication;