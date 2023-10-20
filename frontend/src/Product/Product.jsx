import React from 'react';
import classes from './product.module.css'
import {ReactComponent as Currency} from './currency.svg'

const Product = ({title, price, image}) => {
    return (
        <div className={classes.productContainer}>
            <div className={classes.image}>
                <img src={image} alt={title}/>
            </div>
            <div className={classes.textContainer}>
                <h3>{title}</h3>
                <p>
                    {price}
                    <Currency className={classes.currency}></Currency>
                </p>
            </div>
        </div>
    );
};

export default Product;