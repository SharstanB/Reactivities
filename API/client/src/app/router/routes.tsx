import { createBrowserRouter } from "react-router";
import App from "../layout/App";
import HomePage from "../../features/home/HomePage";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import ActivityForm from "../../features/activities/Form/ActivityForm";
import ActivityDetailsPage from "../../features/activities/Details/ActivityDetailsPage";
import Counter from "../../features/counter/Counter";
export const router = createBrowserRouter([
    {
      path: "/",
      element: <App/>,
      children:[
        {path:'/', element: <HomePage/>},
        {path: 'activities', element: <ActivityDashboard/>},
        {path: 'createActivity', element: <ActivityForm key='create' />},
        {path: 'editActivity/:id', element: <ActivityForm/>},
        {path: 'activities/:id', element: <ActivityDetailsPage/>},
        {path: 'counter', element: <Counter/>},
      ]
    },
  ]);
