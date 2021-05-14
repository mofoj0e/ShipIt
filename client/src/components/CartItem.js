import dayjs from 'dayjs'
import React, { useEffect, useState } from 'react'
import { useDispatch } from 'react-redux'
import { decrementQuantity, incrementQuantity, saveQuantityInput } from '../redux/slices/cart'

const CartItem = product => {
    const dispatch = useDispatch()
    const [quantity, setQuantity] = useState(0)

    useEffect(() => {
        setQuantity(product.quantity)
    }, [product.quantity])

    const handleQuantityChange = e => !isNaN(e.target.value) && setQuantity(Number(e.target.value))

    const handleIncrementQuantity = () => dispatch(incrementQuantity(product))
    const handleDecrementQuantity = () => dispatch(decrementQuantity(product.id))
    const handleQuantitySave = () => dispatch(saveQuantityInput({ id: product.id, quantity }))

    return (
        <div className="card mb-3">
            <div className="row g-0">
                <div className="col-md-1">
                    <img src={product.imageUrl} alt={product.name} style={{ width: '6rem' }} />
                </div>
                <div className="col-md-9">
                    <div className="card-body">
                        <h5 className="card-title text-capitalize">{product.name}</h5>
                        <p className="card-text">
                            <small className="text-muted">
                                <i className="bi-truck"/> Delivery <span style={{ fontWeight: 'bold' }}>{ dayjs(product.deliveryDate).format('MMM D, YYYY') }</span>
                            </small>
                        </p>
                    </div>
                </div>
                <div className="col-md-2">
                    <div className="h-100 d-flex justify-content-center align-items-center">
                        <button className="btn" onClick={handleIncrementQuantity}>+</button>
                        <input className="w-25 mx-2 input-group-text" type="text" value={quantity} onChange={handleQuantityChange} onBlur={handleQuantitySave} />
                        <button className="btn" onClick={handleDecrementQuantity}>-</button>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default CartItem
