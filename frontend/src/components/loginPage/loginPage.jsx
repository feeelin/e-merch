import React, {useEffect, useState} from 'react';
import TelegramLoginButton from "telegram-login-button";
import classes from './loginPage.module.css'
import {ReactComponent as Logo} from "./logo.svg";
import axios from "axios";

const LoginPage = ({setUser, setIsLogin, tgWebAppData}) => {
    const [telegramUser, setTelegramUser] = useState()

    const getCorrectUser = (telegramUser) => {
        return {
            telegramId: telegramUser.id + '',
            nickname: telegramUser.username,
            firstName: telegramUser.first_name,
            lastName: telegramUser.last_name,
            thumbnailUrl: telegramUser.photo_url
        }
    }

    useEffect(
        () => {
            let user = JSON.parse(tgWebAppData.get('user'));
            if(Object.keys(user).length){
                let correct = getCorrectUser(user)
                axios.get(`https://emerch.nakodeelee.ru/api/Customer/telegram/${correct.telegramId}`)
                    .then(response => {
                        setUser(response.data)
                        setIsLogin(true)
                    })
                    .catch(error => {

                        axios.post('https://emerch.nakodeelee.ru/api/Customer', correct)
                            .then(response => {setUser(response.data)})
                    })
            }
        }, [telegramUser]
    )
    

    return (
        <div className={classes.form}>
            <Logo className={classes.logo}/>
            <TelegramLoginButton dataOnauth={user => {setTelegramUser(user)}} botName={'EMerchBot'}></TelegramLoginButton>
        </div>
    );
};

export default LoginPage;