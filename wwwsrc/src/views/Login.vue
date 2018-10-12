<template>
    <div class="center">
        <form v-if="loginForm" @submit.prevent="loginUser" class="row-form">
            <input type="email" v-model="creds.email" placeholder="email">
            <input type="password" v-model="creds.password" placeholder="password">
            <button type="submit">Login</button>
        </form>
        <form v-else @submit.prevent="register" class="row-form">
            <input type="text" v-model="newUser.username" placeholder="name">
            <input type="email" v-model="newUser.email" placeholder="email">
            <input type="password" v-model="newUser.password" placeholder="password">
            <button type="submit">Create Account</button>
        </form>
        <div @click="loginForm = !loginForm" class="row-form">
            <button v-if="loginForm" class="row">No account? Click to Register</button>
            <button v-else class="row">Already have an account? Click to Login</button>
        </div>
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