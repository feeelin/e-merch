import React from 'react';
import classes from './popup.module.css'

const Popup = ({children, visible, setVisible}) => {
    const rootClasses = [classes.container]

    if(visible){
        rootClasses.push(classes.active)
    }

    return (
        <div className={rootClasses.join(' ')} onClick={(event) => {setVisible(false)}}>
            <div className={classes.content} onClick={(event) => event.stopPropagation()}>
                {children}
            </div>
        </div>
    );
};

export default Popup;