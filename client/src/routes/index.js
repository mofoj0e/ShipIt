import React from "react"
import { Switch, BrowserRouter, Route } from "react-router-dom"

import Header from "../components/Header"
import Cart from "../pages/Cart"
import Home from "../pages/Home"

const Routes = () => {
    return (
        <BrowserRouter>
            <Header/>
            <Switch>
                <Route exact path="/" component={Home}/>
                <Route exact path="/cart" component={Cart}/>
            </Switch>
        </BrowserRouter>
    )
}

export default Routes