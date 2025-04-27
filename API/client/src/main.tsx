import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './app/layout/styles.css'
import {QueryClient, QueryClientProvider} from '@tanstack/react-query'
import { ReactQueryDevtools } from '@tanstack/react-query-devtools'
import { RouterProvider } from 'react-router'
import { router } from "./app/router/routes";
import { store } from './lib/stores/Store'
import { StoreContext } from './lib/stores/Store'

const queryClient = new QueryClient();

createRoot(document.getElementById('root')!).render(
    <StrictMode>
      <StoreContext.Provider value={store}>
      <QueryClientProvider client={queryClient}>
       <RouterProvider router={router} />
        <ReactQueryDevtools initialIsOpen={false} />
      </QueryClientProvider>
      </StoreContext.Provider>
    </StrictMode>
 
)
