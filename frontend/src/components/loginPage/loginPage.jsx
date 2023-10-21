import React, {useState} from 'react';
import TelegramLoginButton, {TelegramUser} from "telegram-login-button";
import classes from './loginPage.module.css'
import {ReactComponent as Logo} from "./logo.svg";

const LoginPage = () => {
    const [user, setUser] = useState('')

    return (
        <div className={classes.form}>
            <Logo className={classes.logo}/>
            <TelegramLoginButton dataOnauth={user => (console.log(user))} botName={'EMerchBot'}></TelegramLoginButton>
        </div>
    );
};

export default LoginPage;