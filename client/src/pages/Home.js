import React from "react"
import ProductList from "../components/ProductList"

const Home = () => {
    return (
        <div className="container-fluid my-3">
            <div className="row">
                <ProductList/>
            </div>
        </div>
    )
}

export default Home