<template>
    <div class="center">
        <form v-if="loginForm" @submit.prevent="loginUser" class="edit-form">
            <h2>Login</h2>
            <h5>Email</h5>
            <input class="my-1" type="text" v-model="creds.email">
            <h5>Password</h5>
            <input class="my-1" type="password" v-model="creds.password"></input>
            <div>
                <button type="submit" class="my-1">Login</button>
                <button @click="loginForm = !loginForm">No account? Click to Register</button>
            </div>
        </form>
        <form v-else @submit.prevent="register" class="row-form">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>

        <!-- <button v-else class="row">Already have an account? Click to Login</button> -->

    </div>
</template>

<script>
    export default {
        name: "login",
        mounted() {
            //checks for valid session
            this.$store.dispatch("authenticate");
        },
        data() {
            return {
                loginForm: true,
                creds: {
                    email: "",
                    password: ""
                },
                newUser: {
                    email: "",
                    password: "",
                    username: ""
                }
            };
        },
        methods: {
            register() {
                this.$store.dispatch("register", this.newUser);
            },
            loginUser() {
                this.$store.dispatch("login", this.creds);
            }
        }
    };
</script>

<style>
    .center {
        height: 95vh;
        width: 95vw;
        justify-content: center;
        align-content: center;
        display: flex;
        flex-direction: row;
    }

    .row-form {
        display: flex;
        flex-direction: row;
        height: 1.5rem;
    }

    .col {
        display: flex;
        flex-direction: column;
    }
</style>