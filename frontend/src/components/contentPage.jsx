import React from 'react';
import Header from "./UI/header/header";
import Product from "../Product/Product";

const ContentPage = () => {
    return (
        <div>
            <Header balance={1000}></Header>
            <Product title={'Название'} price={'1000'}></Product>
        </div>
    );
};

export default ContentPage;