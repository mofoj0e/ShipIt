import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import axios from "axios"
import dayjs from "dayjs"

const getDeliveryDate = createAsyncThunk(
    'products/getDeliveryDate',
    async (orderDate, thunkAPI) => {
        const ids = thunkAPI.getState().cart.cart.map(product => `ids=${product.id}`).join('&')
        const products = await axios.get(`${process.env.REACT_APP_SERVICE_URL}/products?${ids}&orderDate=${orderDate}`)
        return products.data
    }
)

const cartSlice = createSlice({
    name: 'cart',
    initialState: {
        cart: [],
        totalQuantity: 0,
        orderDate: dayjs().toString()
    },
    reducers: {
        incrementQuantity: (state, action) => {
            const productToAdd = action.payload
            const foundProduct = state.cart.find(product => productToAdd.id === product.id)
            foundProduct ? foundProduct.quantity++ : state.cart.push({ ...productToAdd, quantity: 1 })
            state.totalQuantity++
        },
        decrementQuantity: (state, action) => {
            const productId = action.payload
            const foundProduct = state.cart.find(product => productId === product.id)
            foundProduct.quantity > 1 ? foundProduct.quantity-- : 
                state.cart = state.cart.filter(product => productId !== product.id)
            state.totalQuantity--
        },
        removeFromCart: (state, action) => {
            const productId = action.payload
            const productQuantity = state.cart.find(product => product.id === productId && product.quantity)
            state.totalQuantity -= productQuantity
            state.cart = state.cart.filter(product => productId !== product.id)
        },
        saveQuantityInput: (state, action) => {
            const { id, quantity } = action.payload
            const foundProduct = state.cart.find(product => product.id === id)
            quantity < 1 ? state.cart = state.cart.filter(product => id !== product.id) : foundProduct.quantity = quantity
            state.totalQuantity = 0
            state.cart.forEach(product => state.totalQuantity += product.quantity)
        }
    },
    extraReducers: {
        [getDeliveryDate.fulfilled]: (state, action) => {
            const data = action.payload
            state.cart = state.cart.map(product => ({ ...product, ...data.find(updatedProduct => updatedProduct.id === product.id) }))
        }
    }
})

export const {
    incrementQuantity,
    removeFromCart,
    decrementQuantity,
    saveQuantityInput,
    calculateTotalQuantity
} = cartSlice.actions

export { getDeliveryDate }

export default cartSlice.reducer