import React, {useState} from 'react';
import Product from "../Product/Product";
import classes from './productsList.module.css'

const ProductList = (products) => {

    let productsList = []

    {products.products.map(
        (product) => {
            productsList.push(<Product title={product.title} image={''} price={product.cost}></Product>)
        }
    )}

        return (
            <div className={classes.container}>
                {productsList}
            </div>
        );
};

export default ProductList;