import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import Register from "./pages/login/Register";
import Login from "./pages/login/Login";
import CaravanModelInfo from "./pages/caravanModelInfo/CaravanModelInfo";
import CaravanModel from "./pages/caravanModels/CaravanModel";
import Reservations from "./pages/reservations/Reservations";
import Navbar from "./Navbar";

function App (){
    return (
        <BrowserRouter>
            <Navbar/>
            <Routes>
                <Route exact path="/" element={<CaravanModel />} />
                <Route exact path="/Navbar" element={<Navbar />} />
                <Route exact path="/login" element={<Login />} />
                <Route exact path="/register" element={<Register />} />
                <Route exact path="/reservations" element={<Reservations />} />
                <Route exact path="/CaravanModelInfo/:id" element={<CaravanModelInfo />} />
            </Routes>
        </BrowserRouter>     
    );
}
export default App;