import './App.css';
import LoginPage from "./components/loginPage/loginPage";
import ContentPage from "./components/contentPage";
import ProductPage from "./components/ProductPage/productPage";
import Header from "./components/UI/header/header";
import React, {useState} from "react";

function App() {
    let [page, setPage] = useState('')
    let [isLogin, setIsLogin] = useState(false)
    let [user, setUser] = useState('')

    if(isLogin){
        return (
            <div>
                <Header user={user}></Header>
                {page
                    ? <ProductPage productId={page} setPage={setPage}/>
                    : <ContentPage page={page} setPage={setPage}></ContentPage>
                }
            </div>
        );
    }else{
        return(
            <div>
                <LoginPage setUser={setUser} setIsLogin={setIsLogin}></LoginPage>
            </div>
        )
    }

}

export default App;
