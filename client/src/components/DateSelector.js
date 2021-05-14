import dayjs from 'dayjs'
import React from 'react'
import DayPickerInput from 'react-day-picker/DayPickerInput'
import { useDispatch } from 'react-redux'
import { getDeliveryDate } from '../redux/slices/cart'

const DateSelector = () => {
    const dispatch = useDispatch()

    const handleDateChange = date => dispatch(getDeliveryDate(dayjs(date).toISOString()))

    return <DayPickerInput
        inputProps={{ style: { textAlign: 'center', width: '283px' } }} 
        onDayChange={handleDateChange}
    />
}

export default DateSelector
