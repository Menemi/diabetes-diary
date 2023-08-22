import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import "./index.css";
import {BrowserRouter as Router, Route, Routes} from "react-router-dom";
import PeriodData from "./pages/PeriodData";
import Stats from "./pages/Stats";
import Doses from "./pages/Doses";
import Navigation from "./components/Navigation";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
    <Router>
        <Navigation/>
        <Routes>
            <Route path="/" element={<App/>}/>
            <Route path="/stats" element={<PeriodData/>}/>
            <Route path="/last-changes" element={<Stats/>}/>
            <Route path="/doses" element={<Doses/>}/>
        </Routes>
    </Router>
);
