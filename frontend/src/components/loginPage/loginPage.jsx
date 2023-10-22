import React, {useEffect, useState} from 'react';
import TelegramLoginButton from "telegram-login-button";
import classes from './loginPage.module.css'
import {ReactComponent as Logo} from "./logo.svg";
import axios from "axios";

const LoginPage = ({setUserCallback, loginCallback, tgWebAppData}) => {
    
    const getCorrectUser = (telegramUser) => {
        return {
            telegramId: telegramUser.id + '',
            nickname: telegramUser.username,
            firstName: telegramUser.first_name,
            lastName: telegramUser.last_name,
            thumbnailUrl: telegramUser.photo_url
        }
    }

    let telegramUser = {}
    let convertedUser = {};
    if (Object.keys(tgWebAppData).length)
        telegramUser = JSON.parse(tgWebAppData.get('user'));

    if(Object.keys(telegramUser).length){
        axios.get(`https://emerch.nakodeelee.ru/api/Customer/telegram/${telegramUser.id}`)
            .then(response => {
                convertedUser = response.data;
            })
            .catch(error => {
                axios.post('https://emerch.nakodeelee.ru/api/Customer', convertedUser)
                    .then(response => {
                        convertedUser = response.data;
                    })
            }).finally(() => {
                setUserCallback(convertedUser)
                loginCallback(true)
            })
    }

    return (
        <div className={classes.form}>
            <Logo className={classes.logo}/>
            <TelegramLoginButton dataOnauth={user =>
             {
                let test = getCorrectUser(user);
                debugger;
                setUserCallback(test)
             }} botName={'EMerchBot'}></TelegramLoginButton>
        </div>
    );
};

export default LoginPage;