import React, {useState, useEffect} from 'react';
import Header from "./UI/header/header";
import ProductList from "./ProductsList/productList";
import Loader from "./UI/loader/loader";
import {useFetching} from "../hooks/useFetching";
import PostService from "./API/postService";

const ContentPage = () => {

    const [fetchProducts, isProductsLoading, productsError] = useFetching(
        async () => {
            const receivedProducts = await PostService.getAll();
            setProducts(receivedProducts)
        }
    )
    let [products, setProducts] = useState([])
    let [page, setPage] = useState()

    const updateContentState = (id) => {
        setPage(id)
    }

    useEffect( () => {
        fetchProducts()
        }, []
    )



    return (
        <div className={'contentPage'}>
            <Header balance={1000}></Header>
            {isProductsLoading
                ? <Loader></Loader>
                : <ProductList products={products} ></ProductList>
            }
        </div>
    );

};

export default ContentPage;