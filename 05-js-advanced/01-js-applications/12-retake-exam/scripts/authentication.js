const authentication = {
    register: async function (email, password) {
        // @ts-ignore
        const response = await firebase.auth().createUserWithEmailAndPassword(email, password);

        return response;
    },

    login: async function (email, password) {
        // @ts-ignore
        const response = await firebase
            .auth()
            .signInWithEmailAndPassword(email, password);

        // @ts-ignore
        const token = await firebase.auth().currentUser.getIdToken()

        this.setToken(token);
        this.setUsername(email);

        return response;
    },

    logout: function () {
        sessionStorage.clear();
        // @ts-ignore
        firebase.auth().signOut();
    },

    userIsLogged: function () {
        return !!this.getToken()
    },

    getUsername: () => sessionStorage.getItem('username'),
    setUsername: (email) => sessionStorage.setItem('username', email),

    getToken: () => sessionStorage.getItem('token'),
    setToken: (token) => sessionStorage.setItem('token', token)
};

export default authentication;