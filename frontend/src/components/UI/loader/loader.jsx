import React from 'react';
import classes from './loader.module.css'
import {ReactComponent as Triangle} from "./currency.svg";

const Loader = () => {
    return (
        <div className={classes.loaderContainer}>
            <Triangle className={classes.loader}/>
        </div>
    );
};

export default Loader;