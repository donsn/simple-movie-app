import { createBrowserRouter, RouterProvider} from "react-router-dom";
import { Routes } from "./pages";

const route = createBrowserRouter(Routes);

/**
 * Defines all the App routes
 */
function App () {
  return <RouterProvider router = {route}/>
}


export default App;
