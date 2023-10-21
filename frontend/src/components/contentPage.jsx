import React, {useState, useEffect} from 'react';
import Header from "./UI/header/header";
import ProductList from "./ProductsList/productList";
import Loader from "./UI/loader/loader";
import {useFetching} from "../hooks/useFetching";
import PostService from "./API/postService";

const ContentPage = ({page, setPage}) => {

    const [fetchProducts, isProductsLoading, productsError] = useFetching(
        async () => {
            const receivedProducts = await PostService.getAll();
            setProducts(receivedProducts)
        }
    )
    let [products, setProducts] = useState([])

    const updateContentState = (id) => {
        setPage(id)
    }

    useEffect( () => {
        fetchProducts()
        }, []
    )



    return (
        <div className={'contentPage'}>
            {isProductsLoading
                ? <Loader></Loader>
                : <ProductList products={products} pageHandler={updateContentState}></ProductList>
            }
        </div>
    );

};

export default ContentPage;