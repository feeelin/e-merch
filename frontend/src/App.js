import './App.css';
import LoginPage from "./components/loginPage";
import ContentPage from "./components/contentPage";
import ProductPage from "./components/ProductPage/productPage";
import Header from "./components/UI/header/header";
import React, {useState} from "react";

function App() {
    let [page, setPage] = useState('')

  return (
      <div>
        <Header balance={10000}></Header>
          {page
              ? <ProductPage productId={page}/>
              : <ContentPage page={page} setPage={setPage}></ContentPage>
        }
      </div>
  );
}

export default App;
