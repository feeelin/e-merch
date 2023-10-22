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
    let [tg, setTgWebAppData] = useState({})

    let hash = window.location.hash.slice(1);
    let hashParams = new URLSearchParams(hash);
    let tgWebAppData = new URLSearchParams(hashParams.get('tgWebAppData'));
    setTgWebAppData(tgWebAppData);

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
                <LoginPage setUser={setUser} setIsLogin={setIsLogin} tgWebAppData={setTgWebAppData}></LoginPage>
            </div>
        )
    }

}

export default App;
