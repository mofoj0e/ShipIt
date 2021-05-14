import { createAsyncThunk, createSlice } from "@reduxjs/toolkit"
import axios from "axios"

const getProducts = createAsyncThunk(
    'products/getProducts',
    async () => {
        const products = await axios.get(`${process.env.REACT_APP_SERVICE_URL}/products`)
        return products.data
    }
)

const productsSlice = createSlice({
    name: 'products',
    initialState: {
        products: [],
        totalProducts: 0
    },
    reducers: {},
    extraReducers: {
        [getProducts.fulfilled]: (state, action) => {
            state.products = action.payload
            state.totalProducts = action.payload.length
        }
    }
})

export { getProducts }
export default productsSlice.reducer