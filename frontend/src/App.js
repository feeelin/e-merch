import './App.css';
import LoginPage from "./components/loginPage";
import ContentPage from "./components/contentPage";
import ProductPage from "./components/ProductPage/productPage";

function App() {
  return (
      // <ContentPage></ContentPage>
      <ProductPage productId={1}/>
  );
}

export default App;
