import React from "react"
import { useSelector } from "react-redux"
import { Link } from "react-router-dom"

const Header = () => {
    const totalQuantity = useSelector(state => state.cart.totalQuantity)

    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="container-fluid">
                <Link className="navbar-brand" to="/">Closure</Link>
                <Link to='cart' className="btn position-relative">
                    <i className="bi-bag me-2"/>
                    Cart
                    { totalQuantity > 0 && <small className="ms-1">({totalQuantity})</small> }
                </Link>
            </div>
        </nav>
    )
}

export default Header