import type { AppProps } from 'next/app'

import { Provider } from 'react-redux'
import { ChakraProvider } from '@chakra-ui/react'

import { store } from '@/storage/store'

export default function App({ Component, pageProps }: AppProps) {
  return (
    <Provider store={store}>
      <ChakraProvider>
        <Component {...pageProps} />
      </ChakraProvider>
    </Provider>
  )
}
