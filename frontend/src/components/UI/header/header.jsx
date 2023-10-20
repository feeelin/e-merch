import React from 'react';
import classes from './header.module.css'
import {ReactComponent as Currency} from "./currency.svg";
import {ReactComponent as Logo} from "./logo.svg";

const Header = ({balance}) => {
    return (
        <div className={classes.header}>
            <Logo className={classes.logo}></Logo>
            <div className={classes.moneyContainer}>
                <p>Баланс:</p>
                <p>{balance}<Currency className={classes.currency}/></p>
            </div>
        </div>
    );
};

export default Header;