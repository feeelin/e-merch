import React, {useState, useEffect} from 'react';
import Header from "./UI/header/header";
import Product from "./Product/Product";
import {EmerchApiClient} from "./emerch.client.ts";
import ProductList from "./ProductsList/productList";

const ContentPage = () => {

    let [isLoading, setIsLoading] = useState(false)
    let client = new EmerchApiClient("https://emerch.nakodeelee.ru")
    let [products, setProducts] = useState([])

    useEffect(() => {
        client.product().then(async (result) => {
            setProducts(result)
        })
    }, [])


    return (
        <div>
            <Header balance={1000}></Header>
            <ProductList products={products}></ProductList>

        </div>
    );
};

export default ContentPage;