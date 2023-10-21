import React, {useEffect, useState} from 'react';
import classes from './productPage.module.css'
import {useFetching} from "../../hooks/useFetching";
import PostService from "../API/postService";
import Header from "../UI/header/header";
import {ReactComponent as Triangle} from "./currency.svg";
import Popup from "../UI/popup/popup";
import Loader from "../UI/loader/loader";

const ProductPage = ({productId}) => {
    const [product, setProduct] = useState({})
    const [popup, setPopup] = useState(false)
    const [message, setMessage] = useState('')

    const [fetchProduct, isProductLoading, productError] = useFetching(
        async () => {
            const receivedProduct = await PostService.getOne(productId)
            console.log(receivedProduct)
            setProduct(receivedProduct)
        }
    )

    useEffect(() => {
        fetchProduct()
    }, []);

    const handlePopupMessage = () => {
        setMessage('Какое-то сообщение!')
        setPopup(true)
    }

    return (
        <div>
            <Header balance={10000}></Header>
            {
                isProductLoading
                    ? <Loader></Loader>
                    : <div>
                        <div>
                            <div className={classes.container}>
                                <img src={product.imageUrl} alt={product.title} className={classes.image}/>
                                <div className={classes.textContainer}>
                                    <h2>{product.title}</h2>
                                    <p>{product.description}</p>
                                    <div className={classes.buyContainer}>
                                        <div className={classes.cost}>
                                            <p>{product.cost}</p>
                                            <Triangle className={classes.triangle}></Triangle>
                                        </div>
                                        <button onClick={handlePopupMessage}>Купить</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <Popup visible={popup} setVisible={setPopup}>{message}</Popup>
                    </div>}
        </div>
)
};

export default ProductPage;