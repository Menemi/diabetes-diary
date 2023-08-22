import React, {useState} from "react"
import Constants from "../utilities/Constants";

export default function PeriodData() {
    //#region Константы
    const initialFormData = Object.freeze({
        date1: null,
        date2: null,
    });

    const [sugars, setSugars] = useState([]);
    const [foods, setFoods] = useState([]);
    const [insulins, setInsulins] = useState([]);
    const [catheters, setCatheters] = useState([]);
    const [formData, setFormData] = useState(initialFormData);

    //#endregion

    //#region Отображение данных на странице
    function renderSugarsTable() {
        return (
            <>
                {
                    sugars.map((sugar) =>
                        <div className="single-data">
                            <div className="data-info-stats">
                                <div className="data-time-container">
                                    <div className="data-time">{sugar.time}</div>
                                </div>
                                <ul className="data-list">
                                    <li className="data-list-item">
                                        <i className="bx bx-band-aid bx-xs"></i>
                                        Cахар: {sugar.sugar}
                                    </li>
                                    {sugar.insulinIncreased !== 0 &&
                                        <li className="data-list-item">
                                            <i className="bx bx-injection bx-xs"></i>
                                            Инсулин: {sugar.insulinIncreased}
                                        </li>
                                    }
                                </ul>
                            </div>
                        </div>)
                }
            </>
        )
    }

    function renderFoodTable() {
        return (
            <>
                {
                    foods.map((food) =>
                        <div className="single-data">
                            <div className="data-info-stats">
                                <div className="data-time-container">
                                    <div className="data-time">{food.time}</div>
                                </div>
                                <ul className="data-list">
                                    <li className="data-list-item">
                                        <i className="bx bx-injection bx-xs"></i>
                                        Доза: {food.dose}
                                    </li>
                                    <li className="data-list-item">
                                        <i className="bx bx-baguette bx-xs"></i>
                                        ХБ: {food.breadUnits}
                                    </li>
                                    <li className="data-list-item">
                                        <i className="bx bx-injection bx-xs"></i>
                                        Инсулин: {food.insulinPinned}
                                    </li>
                                    <li className="data-list-item">
                                        <i className="bx bx-bowl-hot bx-xs"></i>
                                        Еда: {food.foodName}
                                    </li>
                                </ul>
                            </div>
                        </div>)
                }
            </>
        )
    }

    function renderInsulinTable() {
        return (
            <>
                {
                    insulins.map((insulin) =>
                        <div className="single-data">
                            <div className="data-info-stats">
                                <div className="data-time-container">
                                    <div className="data-time">{insulin.time}</div>
                                </div>
                            </div>
                        </div>)
                }
            </>
        )
    }

    function renderCathetersTable() {
        return (
            <>
                {
                    catheters.map((catheter) =>
                        <div className="single-data">
                            <div className="data-info-stats">
                                <div className="data-time-container">
                                    <div className="data-time">{catheter.time}</div>
                                </div>
                            </div>
                        </div>)
                }
            </>
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
            let today = new Date();
            let dd = String(today.getDate()).padStart(2, '0');
            let mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
            let yyyy = today.getFullYear();
            today = dd + '.' + mm + '.' + yyyy;
            date1 = today;
            date2 = today;
        } else if (formData.date1 == null) {
            date1 = date2;
        } else if (formData.date2 == null) {
            date2 = date1;
        }

        let url = `${Constants.API_URL_GET_SUGARS}?date1=${date1}&date2=${date2}`;

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

        url = `${Constants.API_URL_GET_FOOD}?date1=${date1}&date2=${date2}`;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(foodFromServer => {
                setFoods(foodFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })

        url = `${Constants.API_URL_GET_INSULIN}?date1=${date1}&date2=${date2}`;

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

        url = `${Constants.API_URL_GET_CATHETERS}?date1=${date1}&date2=${date2}`;

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
    };

    return (
        <main>
            <div className={"board-view"}>
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

                {sugars.length > 0 &&
                    <div className="day-column">
                        <div className="column-head-stats">
                            <h3>Сахара</h3>
                        </div>

                        {renderSugarsTable()}
                    </div>
                }

                {foods.length > 0 &&
                    <div className="day-column">
                        <div className="column-head-stats">
                            <h3>Еда</h3>
                        </div>

                        {renderFoodTable()}
                    </div>
                }

                {insulins.length > 0 &&
                    <div className="day-column">
                        <div className="column-head-stats">
                            <h3>Инсулин</h3>
                        </div>

                        {renderInsulinTable()}
                    </div>
                }

                {catheters.length > 0 &&
                    <div className="day-column">
                        <div className="column-head-stats">
                            <h3>Катетеры</h3>
                        </div>

                        {renderCathetersTable()}
                    </div>
                }
            </div>
        </main>
    )
}
