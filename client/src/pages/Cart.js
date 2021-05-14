import React from 'react'
import { useSelector } from 'react-redux'
import CartItem from '../components/CartItem'
import DateSelector from '../components/DateSelector'

const Cart = () => {
    const cartItems = useSelector(state => state.cart.cart)
    
    return (
        <div className="container-fluid my-3">
            { cartItems.length > 0 && (
                <div className="mb-3 d-flex justify-content-end">
                    <DateSelector/>
                </div>
            ) }
            { cartItems.map(product => <CartItem key={product.id} {...product}/>) }
        </div>
    )
}

export default Cart
