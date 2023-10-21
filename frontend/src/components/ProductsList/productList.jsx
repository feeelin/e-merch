import React from 'react';
import Product from "../Product/Product";
import classes from './productsList.module.css'

const ProductList = ({products, pageHandler}) => {

    let productsList = []


    {products.map(
        (product) => {
            productsList.push(
                <div onClick={(e) => {pageHandler(product.id)}}>
                    <Product
                        title={product.title}
                        image={product.imageUrl}
                        price={product.cost}
                    />
                </div>
            )
        }
    )}

        return (
                <div className={classes.container}>
                    {productsList}
                </div>
        );
};

export default ProductList;