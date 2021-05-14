import { configureStore } from '@reduxjs/toolkit'
import CartReducer from '../slices/cart'
import ProductsSlice from '../slices/products'

export const store = configureStore({
  reducer: { 
    cart: CartReducer,
    products: ProductsSlice
  }
})
