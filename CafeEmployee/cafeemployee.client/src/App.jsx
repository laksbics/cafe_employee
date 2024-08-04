import React from 'react';
import { Route, createBrowserRouter, createRoutesFromElements, RouterProvider } from 'react-router-dom';
import Cafe from './pages/cafe';
import Employee from './pages/employee';
import Header from './components/common/Header';



const router = createBrowserRouter(
    createRoutesFromElements(
        <Route path="/" element={<Header />}>
            <Route path="/" element={<Cafe />} />
            <Route path="Cafe" element={<Cafe />} />
            <Route path="Employee/:cafe?" element={<Employee />} />
        </Route>
    )
)

function App({ routes }) {

    return (
                <RouterProvider router={router} />
    );
}

export default App;