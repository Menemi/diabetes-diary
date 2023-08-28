import React, {useEffect, useState} from "react"
import Constants from "../utilities/Constants";

export default function Stats() {
    //#region Константы
    const initialFormData = Object.freeze({
        date1: null,
        date2: null,
    });

    const [sugars, setSugars] = useState(0);
    const [daySugars, setDaySugars] = useState(0);
    const [weekSugars, setWeekSugars] = useState(0);
    const [monthSugars, setMonthSugars] = useState(0);
    const [insulins, setInsulins] = useState([]);
    const [catheters, setCatheters] = useState([]);
    const [dates, setDates] = useState("date1:date2");
    const [formData, setFormData] = useState(initialFormData);

    //#endregion

    //#region Работа с датами
    function getToday(plusDays = 0) {
        let today = new Date();
        today = new Date(today.getFullYear(), today.getMonth(), today.getDate() + plusDays)
        let dd = String(today.getDate()).padStart(2, "0");
        let mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
        let yyyy = today.getFullYear();

        return dd + "." + mm + "." + yyyy;
    }

    function toShortDateString(date = getToday()) {
        let d = date.split("-")
        return d[2] + "." + d[1];
    }


    //#endregion

    //#region Загрузка данных
    useEffect(() => {
        let url = Constants.API_URL_GET_LAST_INSULIN;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(insulinFromServer => {
                setInsulins(insulinFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })

        url = Constants.API_URL_GET_LAST_CATHETER;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(cathetersFromServer => {
                setCatheters(cathetersFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })

        url = `${Constants.API_URL_GET_AVG_SUGARS}/?date1=${getToday()}`;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(sugarsFromServer => {
                setDaySugars(sugarsFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })

        url = `${Constants.API_URL_GET_AVG_SUGARS}/?date1=${getToday(-7)}&date2=${getToday()}`;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(sugarsFromServer => {
                setWeekSugars(sugarsFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })

        url = `${Constants.API_URL_GET_AVG_SUGARS}/?date1=${getToday(-30)}&date2=${getToday()}`;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(sugarsFromServer => {
                setMonthSugars(sugarsFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }, []);
    //#endregion

    //#region Отображение данных на странице
    function renderSugarTable() {
        return (
            <div className="single-data">
                <div className="data-info-stats">
                    <ul className="data-list">
                        {daySugars !== 0 &&
                            <li className="data-list-item">
                                <i className="bx bx-band-aid bx-xs"></i>
                                Сегодня: {daySugars}
                            </li>
                        }
                        <li className="data-list-item">
                            <i className="bx bx-band-aid bx-xs"></i>
                            Неделя: {weekSugars}
                        </li>
                        <li className="data-list-item">
                            <i className="bx bx-band-aid bx-xs"></i>
                            Месяц: {monthSugars}
                        </li>
                        {sugars !== 0 &&
                            <li className="data-list-item">
                                <i className="bx bx-band-aid bx-xs"></i>
                                {dates}: {sugars}
                            </li>
                        }
                    </ul>
                </div>
            </div>
        )
    }

    function renderInsulinTable() {
        return (
            <div className="single-data">
                <div className="data-info-stats">
                    <div className="data-time-container">
                        <div className="data-time">{insulins["time"]}</div>
                    </div>
                </div>
            </div>
        )
    }

    function renderCathetersTable() {
        return (
            <div className="single-data">
                <div className="data-info-stats">
                    <div className="data-time-container">
                        <div className="data-time">{catheters["time"]}</div>
                    </div>
                </div>
            </div>
        )
    }

    //#endregion

    const handleChange = (event) => {
        setFormData({
            ...formData,
            [event.target.name]: event.target.value,
        })
    };

    const handleSubmit = (event) => {
        event.preventDefault();

        let date1 = formData.date1;
        let date2 = formData.date2;

        if (formData.date1 == null && formData.date2 == null) {
            date1 = getToday();
            date2 = getToday();
        } else if (formData.date1 == null) {
            date1 = date2;
        } else if (formData.date2 == null) {
            date2 = date1;
        }

        let url = `${Constants.API_URL_GET_AVG_SUGARS}?date1=${date1}&date2=${date2}`;
        setDates(`${toShortDateString(date1)} - ${toShortDateString(date2)}`)

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(sugarsFromServer => {
                setSugars(sugarsFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    };

    return (
        <main>
            <div className="board-view-centered">
                <div className="input-stats-area">
                    <div className="input-single-date">
                        <span className="single-date-tip-text">Дата 1</span>
                        <input value={formData.date1} name="date1" type="date" className="input-area"
                               onChange={handleChange}/>
                    </div>
                    <div className="input-single-date">
                        <span className="single-date-tip-text">Дата 2</span>
                        <input value={formData.date2} name="date2" type="date" className="input-area"
                               onChange={handleChange}/>
                    </div>
                    <div className="button-stats-area">
                        <button onClick={handleSubmit} className="btn green-btn stats-submit-btn">Submit</button>
                    </div>
                </div>

                <div className="day-column">
                    <div className="column-head-stats">
                        <h3>Средний сахар</h3>
                    </div>

                    {renderSugarTable()}
                </div>

                <div className="day-column">
                    <div className="column-head-stats">
                        <h3>Последний инсулин</h3>
                    </div>

                    {renderInsulinTable()}
                </div>

                <div className="day-column">
                    <div className="column-head-stats">
                        <h3>Последний катетер</h3>
                    </div>

                    {renderCathetersTable()}
                </div>
            </div>
        </main>
    )
}
