import {NavLink} from "react-router-dom";
import React from "react";
import {activeBlur, nonActiveBlur} from "../utilities/Constants";

export default function Navigation() {
    return (
        <nav className="navigation">
            <NavLink className="nav-head" to="/">
                <i className="bx bx-book-heart bx-sm nav-icon"></i>
                <h1>Дневник диабета</h1>
            </NavLink>
            <ul className="nav-list">
                <li className={"nav-item"}>
                    <NavLink className="nav-link" to="/"
                             style={({isActive}) => (
                                 isActive
                                     ? activeBlur
                                     : nonActiveBlur
                             )}>
                        <i className="bx bx-calendar bx-sm nav-icon"></i>
                        <h2>Сегодня</h2>
                    </NavLink>
                </li>
                <li className={"nav-item"}>
                    <NavLink className="nav-link" to="/stats"
                             style={({isActive}) => (
                                 isActive
                                     ? activeBlur
                                     : nonActiveBlur
                             )}>
                        <i className="bx bx-data bx-sm nav-icon"></i>
                        <h2>Данные за период времени</h2>
                    </NavLink>
                </li>
                <li className={"nav-item"}>
                    <NavLink className="nav-link" to="/last-changes"
                             style={({isActive}) => (
                                 isActive
                                     ? activeBlur
                                     : nonActiveBlur
                             )}>
                        <i className="bx bx-stats bx-sm nav-icon"></i>
                        <h2>Статистика</h2>
                    </NavLink>
                </li>
                <li className={"nav-item"}>
                    <NavLink className="nav-link" to="/doses"
                             style={({isActive}) => (
                                 isActive
                                     ? activeBlur
                                     : nonActiveBlur
                             )}>
                        <i className="bx bx-injection bx-sm nav-icon"></i>
                        <h2>Дозы</h2>
                    </NavLink>
                </li>
            </ul>
        </nav>
    );
}
