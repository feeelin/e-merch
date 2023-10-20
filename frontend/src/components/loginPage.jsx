import React from 'react';
import TelegramLoginButton, {TelegramUser} from "telegram-login-button";

const LoginPage = () => {

    return (
        <div>
            <TelegramLoginButton dataOnauth={user => (console.log(user))} botName={'EMerchBot'}></TelegramLoginButton>
        </div>
    );
};

export default LoginPage;