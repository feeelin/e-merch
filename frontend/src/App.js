import './App.css';
import LoginPage from "./components/loginPage/loginPage";
import ContentPage from "./components/contentPage";
import ProductPage from "./components/ProductPage/productPage";
import Header from "./components/UI/header/header";
import React, {useState} from "react";

function App() {
    let [page, setPage] = useState('')
    let [isLogin, setIsLogin] = useState(false)

    if(isLogin){
        return (
            <div>
                <Header balance={10000}></Header>
                {page
                    ? <ProductPage productId={page} setPage={setPage}/>
                    : <ContentPage page={page} setPage={setPage}></ContentPage>
                }
            </div>
        );
    }else{
        return(
            <div>
                <LoginPage></LoginPage>
            </div>
        )
    }

}

export default App;
