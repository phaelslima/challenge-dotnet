import { createSlice } from '@reduxjs/toolkit'

interface LeadState {
  id: number
  name: string
  phone: string
  email: string
  status: number
  category: string
  suburb: string
  description: string
  createdAt: string
  price: string
  totalPrice: string
}

const initialState: LeadState[] = []

const leadsSlice = createSlice({
  name: 'leads',
  initialState,
  reducers: {
    addLeads(state, action) {
      state.push(...action.payload)
    },
    leadAccepted(state, action) {
      let item = state.find(lead => lead.id === action.payload)
      if (item) item.status = 1
    },
    leadDeleted(state, action) {
      return state.filter(lead => lead.id !== action.payload)
    }
  }
})

export const { addLeads, leadAccepted, leadDeleted } = leadsSlice.actions
export default leadsSlice.reducer