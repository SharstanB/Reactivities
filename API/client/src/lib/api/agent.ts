import axios from "axios";
import { store } from "../stores/Store";
import { toast } from "react-toastify";
import { router } from "../../app/router/routes";

const agent = axios.create({
    baseURL: import.meta.env.VITE_API_URL
});
// const sleep = (delay: number) => {
//     return new Promise((resolve) => {
//         setTimeout(resolve, delay);
//     });
// }
agent.interceptors.request.use(
     request => {
        store.uiStore.isBusy();
        return request;
    }
);
//Interceptors in Axios are like "middleware" — they let you intercept and modify requests before
// they’re sent, and responses before they’re handled by your .then() or .catch() functions.
agent.interceptors.response.use( async response => {
      // No need for try-catch if you're just returning the response
      // await sleep(1000);
      store.uiStore.isIdle();
      return response;
    },
    error => {
      const {status ,data} = error.response;
      // This handles errors from the response
      switch(status)
      {
        case 400:
          toast.error(data.title);
          break;
        case 401:
          toast.error(data.title);
          break;
        case 403:
          toast.error(data.title);
          break;
        case 404:
          router.navigate('/not-found');
          break;
        case 500:
            {
              router.navigate('/server-error', {state: {error: data}});
              break; }
        default:{
          toast.error(data.title);
          break;
        }
            
      }
      store.uiStore.isIdle();
      return Promise.reject(error); // Properly propagate the error
    },
    
  );

  export default agent;