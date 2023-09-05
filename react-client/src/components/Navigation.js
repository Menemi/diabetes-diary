import {NavLink} from "react-router-dom";
import React, {useState} from "react";

const Navigation = () => {
    const [isOpen, setIsOpen] = useState(false);
    const toggle = () => setIsOpen(!isOpen);
    const menuItem = [
        {
            path: "/",
            name: "Сегодня",
            icon: <i className="bx bx-calendar bx-md nav-icon"></i>
        },
        {
            path: "/stats",
            name: "Архив данных",
            icon: <i className="bx bx-data bx-md nav-icon"></i>
        },
        {
            path: "/last-changes",
            name: "Статистика",
            icon: <i className="bx bx-stats bx-md nav-icon"></i>
        },
        {
            path: "/doses",
            name: "Дозы",
            icon: <i className="bx bx-injection bx-md nav-icon"></i>
        }
    ]
    return (
        <div style={{width: isOpen ? "250px" : "68px"}} className="navigation">
            <div className="nav-head">
                <h1 style={{display: isOpen ? "block" : "none"}}>Дневник диабета</h1>
                <i className="bx bx-menu bx-md nav-icon nav-logo"
                   onClick={toggle}></i>
            </div>

            {
                menuItem.map((item, index) => (
                    <NavLink to={item.path} key={index} className="nav-link">
                        {item.icon}
                        <h2 style={{display: isOpen ? "block" : "none"}} className="nav-item">{item.name}</h2>
                    </NavLink>
                ))
            }
        </div>
    );
}

export default Navigation;
