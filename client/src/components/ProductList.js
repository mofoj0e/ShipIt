import React from "react"
import { useSelector } from "react-redux"
import ProductItem from "./ProductItem"

const ProductList = () => {
    const products = useSelector(state => state.products.products)

    return products.map(product => <ProductItem key={product.id} {...product} />)
}

export default ProductList