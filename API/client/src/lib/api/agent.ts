import axios from "axios";
import { store } from "../stores/Store";

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
      // This handles errors from the response
      console.log(error);
      store.uiStore.isIdle();
      return Promise.reject(error); // Properly propagate the error
    },
    
  );

  export default agent;