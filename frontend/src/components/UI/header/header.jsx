import React, {useState} from 'react';
import classes from './header.module.css'
import {ReactComponent as Currency} from "./currency.svg";
import {ReactComponent as Logo} from "./logo.svg";
import Popup from "../popup/popup";
import Profile from "../../Profile/profile";

const Header = ({user}) => {
    const [isVisible, setIsVisible] = useState(false)


    return (
        <div>
            <Popup visible={isVisible} setVisible={setIsVisible}>
                <Profile user={user}></Profile>
            </Popup>
            <div className={classes.header}>
                <Logo className={classes.logo}></Logo>
                <div className={classes.moneyContainer}>
                    <p>{user.eCoins}<Currency className={classes.currency}/></p>
                    <img className={classes.userImage} src={user.thumbnailUrl} alt={''} onClick={(e) => {setIsVisible(true)}}/>
                </div>
            </div>
        </div>
    );
};

export default Header;