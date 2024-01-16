import { Avatar, Box, Button, Card as CUICard, CardBody, CardFooter, CardHeader, HStack, Heading, Stack, StackDivider, Text } from "@chakra-ui/react";
import { MdOutlineBusinessCenter, MdOutlineLocalPhone, MdOutlineLocationOn, MdOutlineMail } from "react-icons/md";

import { api } from "@/services/axios";

import { useDispatch } from "react-redux";
import { leadAccepted, leadDeleted } from "@/storage/features/leads/leadsSlice";

import { parseISO, format } from 'date-fns';
import { useState } from "react";

type Props = {
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

export function Card(data: Props) {
  const [isLoadingAccept, setIsLoadingAccept] = useState(false)
  const [isLoadingDecline, setIsLoadingDecline] = useState(false)

  const dispatch = useDispatch()

  const auxName = data.status === 0 ? data.name.trim().split(' ')[0] : data.name;
  const date = parseISO(data.createdAt);

  async function handleAccept(id: number) {
    try {
      setIsLoadingAccept(true)
      await api.post(`leads/${id}/accept`)
      dispatch(leadAccepted(id))
    } catch (error) {

    } finally {
      setIsLoadingAccept(false)
    }
  }

  async function handleDecline(id: number) {
    try {
      setIsLoadingDecline(true)
      await api.post(`leads/${id}/decline`)
      dispatch(leadDeleted(id))
    } catch (error) {
      
    } finally {
      setIsLoadingDecline(false)
    }
  }

  return (
    <CUICard mb={4}>
      <CardHeader p={4}>
        <HStack>
          <Avatar name={auxName} backgroundColor="orange.500" color="white" />
          <Box>
            <Heading size="md">{auxName}</Heading>
            <Text>{format(date, 'LLLL d yyyy @ h:mm a')}</Text>
          </Box>
        </HStack>
      </CardHeader>

      <CardBody px={0} py={2} borderTopWidth={1} borderTopColor="gray.200" borderBottomWidth={1} borderBottomColor="gray.200">
        <Stack divider={<StackDivider />}>
          <HStack px={4} spacing={4}>
            <HStack spacing={1}>
              <MdOutlineLocationOn />
              <Text>{data.suburb}</Text>
            </HStack>
            
            <HStack spacing={1}>
              <MdOutlineBusinessCenter />
              <Text>{data.category}</Text>
            </HStack>

            <Text>Job ID: {data.id}</Text>

            {data.status === 1 && <Text>${parseFloat(data.totalPrice).toFixed(2)} Lead Invitation</Text>}
          </HStack>
          <Box px={4}>
            {data.status === 1 && (
              <HStack mb={2} spacing={4}>
                <HStack spacing={1}>
                  <MdOutlineLocalPhone />
                  <Text as="b" color="orange.500">{data.phone}</Text>
                </HStack>
                
                <HStack spacing={1}>
                  <MdOutlineMail />
                  <Text as="b" color="orange.500">{data.email}</Text>
                </HStack>
              </HStack>
            )}

            <Text>
              {data.description}
            </Text>
          </Box>
        </Stack>
      </CardBody>

      {data.status === 0 && (
        <CardFooter p={4}>
          <Stack direction='row' spacing={4} align='center'>
            <Button colorScheme='orange' variant='solid' onClick={() => handleAccept(data.id)} isLoading={isLoadingAccept}>
              Accept
            </Button>

            <Button colorScheme='orange' variant='outline' onClick={() => handleDecline(data.id)} isLoading={isLoadingDecline}>
              Decline
            </Button>

            <Text><Text as="b">${parseFloat(data.price).toFixed(2)}</Text> Lead Invitation</Text>
          </Stack>
        </CardFooter>
      )}
    </CUICard>
  )
}