import React from "react"
import dayjs from "dayjs"
import { useDispatch } from "react-redux"
import { incrementQuantity } from "../redux/slices/cart"

const ProductItem = product => {
    const dispatch = useDispatch()

    const handleAddToCart = () => dispatch(incrementQuantity(product))

    return (
        <div className="col-4 my-2">
            <div className="card">
                <img src={product.imageUrl} className="card-img-top" alt={product.name}/>
                <div className="card-body">
                    <h5 className="card-title" style={{ textTransform: 'capitalize' }}>
                        { product.name }
                    </h5>
                    <small className="card-text d-block">
                        <i className="bi-truck"/> Delivery <span className="text-muted" style={{ fontWeight: 'bold' }}>{ dayjs(product.deliveryDate).format('MMM D, YYYY') }</span>
                    </small>
                    <button onClick={handleAddToCart} className="btn btn-outline-primary w-100 mt-3">
                        <i className="bi-plus-square-dotted me-2"/>
                        Add to cart
                    </button>
                </div>
            </div>
        </div>
    )
}

export default ProductItem