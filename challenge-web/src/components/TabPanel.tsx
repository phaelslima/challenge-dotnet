import { useEffect, useState } from "react";

import { TabPanel as CUITabPanel, Button, Center } from "@chakra-ui/react";

import { Card } from "./Card";

import { api } from "@/services/axios";

import { useDispatch, useSelector } from "react-redux";
import { addLeads } from "@/storage/features/leads/leadsSlice";

import { RootState } from "@/storage/store";

type Props = { status: number }

export function TabPanel({ status }: Props) {
  const leadsState = useSelector((state: RootState) => state.leads)
  const dispatch = useDispatch()

  const leads = leadsState.filter(item => item.status === status).sort((a, b) => a.id - b.id)
  
  const [skip, setSkip] = useState(leads.length / 5)
  const [take, setTake] = useState(5)
  const [count, setCount] = useState(0)
  const [isLoading, setIsloading] = useState(false)

  async function fetchLeads() {
    try {
      setIsloading(true)

      const response = await api.get(`leads/status/${status}?skip=${skip}&take=${take}`)
      const { data, count } = response.data
      
      dispatch(addLeads(data))
      setCount(count)

    } catch (error) {
      
    } finally {
      setIsloading(false)
    }
  }

  useEffect(() => {
    if (isLoading) return
    fetchLeads()
  }, [skip])
  
  return (
    <CUITabPanel>
      {leads.map((item, index) => <Card key={index} {...item} />)}

      {leads.length < count && (
        <Center>
          <Button onClick={() => setSkip(oldState => oldState + take)}>Ver mais</Button>
        </Center>
      )}
    </CUITabPanel>
  )
}