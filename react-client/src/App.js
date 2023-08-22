import React, {useEffect, useState} from "react";
import Constants from "./utilities/Constants"
import SugarCreateForm from "./components/sugar/SugarCreateForm";
import SugarUpdateForm from "./components/sugar/SugarUpdateForm";
import FoodCreateForm from "./components/food/FoodCreateForm";
import FoodUpdateForm from "./components/food/FoodUpdateForm";
import InsulinCreateForm from "./components/insulin/InsulinCreateForm";
import InsulinUpdateForm from "./components/insulin/InsulinUpdateForm";
import CatheterCreateForm from "./components/catheter/CatheterCreateForm";
import CatheterUpdateForm from "./components/catheter/CatheterUpdateForm";
import "boxicons";

export default function App() {
    //#region Константы
    const [sugars, setSugars] = useState([]);
    const [showingAddNewSugarForm, setShowingAddNewSugarForm] = useState(false);
    const [updatedSugar, setUpdatedSugar] = useState(null);

    const [foods, setFoods] = useState([]);
    const [showingAddNewFoodForm, setShowingAddNewFoodForm] = useState(false);
    const [updatedFood, setUpdatedFood] = useState(null);

    const [insulins, setInsulins] = useState([]);
    const [showingAddNewInsulinForm, setShowingAddNewInsulinForm] = useState(false);
    const [updatedInsulin, setUpdatedInsulin] = useState(null);

    const [catheters, setCatheters] = useState([]);
    const [showingAddNewCatheterForm, setShowingAddNewCatheterForm] = useState(false);
    const [updatedCatheter, setUpdatedCatheter] = useState(null);

    //#endregion

    //#region Загрузка данных
    useEffect(() => {
        let url = Constants.API_URL_GET_TODAY_SUGARS;

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

        url = Constants.API_URL_GET_TODAY_FOOD;

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
        url = Constants.API_URL_GET_TODAY_INSULIN;

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

        url = Constants.API_URL_GET_TODAY_CATHETERS;

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
    }, []);
    //#endregion

    //#region Удаление данных
    function deleteSugar(id) {
        const url = `${Constants.API_URL_REMOVE_SUGAR_BY_ID}/${id}`;

        fetch(url, {
            method: "DELETE"
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                onSugarDeleted(id);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }

    function deleteFood(id) {
        const url = `${Constants.API_URL_REMOVE_FOOD_BY_ID}/${id}`;

        fetch(url, {
            method: "DELETE"
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                onFoodDeleted(id);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }

    function deleteInsulin(id) {
        const url = `${Constants.API_URL_REMOVE_INSULIN_BY_ID}/${id}`;

        fetch(url, {
            method: "DELETE"
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                onInsulinDeleted(id);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }

    function deleteCatheter(id) {
        const url = `${Constants.API_URL_REMOVE_CATHETER_BY_ID}/${id}`;

        fetch(url, {
            method: "DELETE"
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                onCatheterDeleted(id);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }

    //#endregion

    //#region Отображение данных на странице
    function renderSugarsTable() {
        return (
            <>
                {
                    sugars.map((sugar) =>
                        <div className="single-data">
                            <div className="data-info">
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
                            <div className="interaction-buttons-area">
                                <button onClick={() => {
                                    if (window.confirm(`Sure wanna remove sugar ${sugar.sugar} [${sugar.time}]`)) deleteSugar(sugar.id)
                                }} className="btn red-btn">
                                    <i className="bx bx-x bx-xs"></i>
                                </button>
                                <button onClick={() => setUpdatedSugar(sugar)} className="btn orange-btn">
                                    <i className="bx bx-edit bx-xs"></i>
                                </button>
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
                            <div className="data-info">
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
                                        ХЕ: {food.breadUnits}
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
                            <div className="interaction-buttons-area">
                                <button onClick={() => {
                                    if (window.confirm(`Sure wanna remove food [${food.time}]`)) deleteFood(food.id)
                                }} className="btn red-btn">
                                    <i className="bx bx-x bx-xs"></i>
                                </button>
                                <button onClick={() => setUpdatedFood(food)} className="btn orange-btn">
                                    <i className="bx bx-edit bx-xs"></i>
                                </button>
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
                            <div className="data-info">
                                <div className="data-time-container">
                                    <div className="data-time">{insulin.time}</div>
                                </div>
                            </div>
                            <div className="interaction-buttons-area">
                                <button onClick={() => {
                                    if (window.confirm(`Sure wanna remove insulin [${insulin.time}]`)) deleteInsulin(insulin.id)
                                }} className="btn red-btn">
                                    <i className="bx bx-x bx-xs"></i>
                                </button>
                                <button onClick={() => setUpdatedInsulin(insulin)} className="btn orange-btn">
                                    <i className="bx bx-edit bx-xs"></i>
                                </button>
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
                            <div className="data-info">
                                <div className="data-time-container">
                                    <div className="data-time">{catheter.time}</div>
                                </div>
                            </div>
                            <div className="interaction-buttons-area">
                                <button onClick={() => {
                                    if (window.confirm(`Sure wanna remove catheter [${catheter.time}]`)) deleteCatheter(catheter.id)
                                }} className="btn red-btn">
                                    <i className="bx bx-x bx-xs"></i>
                                </button>
                                <button onClick={() => setUpdatedCatheter(catheter)} className="btn orange-btn">
                                    <i className="bx bx-edit bx-xs"></i>
                                </button>
                            </div>
                        </div>)
                }
            </>
        )
    }

    //#endregion

    //#region Добавление данных
    function onSugarAdded(sugar) {
        setShowingAddNewSugarForm(false);

        if (sugar === null) {
            return;
        }
    }

    function onFoodAdded(food) {
        setShowingAddNewFoodForm(false);

        if (food === null) {
            return;
        }
    }

    function onInsulinAdded(insulin) {
        setShowingAddNewInsulinForm(false);

        if (insulin === null) {
            return;
        }
    }

    function onCatheterAdded(catheter) {
        setShowingAddNewCatheterForm(false);

        if (catheter === null) {
            return;
        }
    }

    //#endregion

    //#region Обновление данных
    function onSugarUpdated(sugar) {
        setUpdatedSugar(null);

        if (sugar === null) {
            return;
        }

        let sugarsCopy = [...sugars];
        const index = sugarsCopy.findIndex((sugarsCopySugar, currentIndex) => {
            if (sugarsCopySugar.id === sugar.id) {
                return true;
            }
        })

        if (index !== -1) {
            sugarsCopy[index] = sugar;
        }

        setSugars(sugarsCopy);
    }

    function onFoodUpdated(food) {
        setUpdatedFood(null);

        if (food === null) {
            return;
        }

        let foodCopy = [...foods];
        const index = foodCopy.findIndex((foodCopyFood, currentIndex) => {
            if (foodCopyFood.id === food.id) {
                return true;
            }
        })

        if (index !== -1) {
            foodCopy[index] = food;
        }

        setFoods(foodCopy);
    }

    function onInsulinUpdated(insulin) {
        setUpdatedInsulin(null);

        if (insulin === null) {
            return;
        }

        let insulinCopy = [...insulins];
        const index = insulinCopy.findIndex((insulinCopyInsulin, currentIndex) => {
            if (insulinCopyInsulin.id === insulin.id) {
                return true;
            }
        })

        if (index !== -1) {
            insulinCopy[index] = insulin;
        }

        setInsulins(insulinCopy);
    }

    function onCatheterUpdated(catheter) {
        setUpdatedCatheter(null);

        if (catheter === null) {
            return;
        }

        let cathetersCopy = [...catheters];
        const index = cathetersCopy.findIndex((cathetersCopyCatheter, currentIndex) => {
            if (cathetersCopyCatheter.id === catheter.id) {
                return true;
            }
        })

        if (index !== -1) {
            cathetersCopy[index] = catheter;
        }

        setCatheters(cathetersCopy);
    }

    //#endregion

    //#region Удаление данных
    function onSugarDeleted(id) {
        let sugarsCopy = [...sugars];
        const index = sugarsCopy.findIndex((sugarsCopySugar, currentIndex) => {
            if (sugarsCopySugar.id === id) {
                return true;
            }
        })

        if (index !== -1) {
            sugarsCopy.splice(index, 1);
        }

        setSugars(sugarsCopy);
    }

    function onFoodDeleted(id) {
        let foodCopy = [...sugars];
        const index = foodCopy.findIndex((foodCopySugar, currentIndex) => {
            if (foodCopySugar.id === id) {
                return true;
            }
        })

        if (index !== -1) {
            foodCopy.splice(index, 1);
        }

        setSugars(foodCopy);
    }

    function onInsulinDeleted(id) {
        let insulinCopy = [...sugars];
        const index = insulinCopy.findIndex((insulinCopySugar, currentIndex) => {
            if (insulinCopySugar.id === id) {
                return true;
            }
        })

        if (index !== -1) {
            insulinCopy.splice(index, 1);
        }

        setSugars(insulinCopy);
    }

    function onCatheterDeleted(id) {
        let cathetersCopy = [...sugars];
        const index = cathetersCopy.findIndex((cathetersCopySugar, currentIndex) => {
            if (cathetersCopySugar.id === id) {
                return true;
            }
        })

        if (index !== -1) {
            cathetersCopy.splice(index, 1);
        }

        setSugars(cathetersCopy);
    }

    //#endregion

    return (
        <main>
            <div className={"board-view"}>
                <div className="day-column">
                    {(showingAddNewSugarForm === false && updatedSugar === null) && (
                        <div className="column-head">
                            <h3>Сахара</h3>

                            <button onClick={() => setShowingAddNewSugarForm(true)}
                                    className="btn green-btn">
                                <i className="bx bx-band-aid bx-xs"></i>
                                Add
                            </button>
                        </div>
                    )}

                    {(sugars.length > 0 && showingAddNewSugarForm === false && updatedSugar === null) && renderSugarsTable()}

                    {showingAddNewSugarForm && <SugarCreateForm onSugarAdded={onSugarAdded}/>}

                    {updatedSugar !== null &&
                        <SugarUpdateForm sugar={updatedSugar} onSugarUpdated={onSugarUpdated}/>}
                </div>

                <div className="day-column">
                    {(showingAddNewFoodForm === false && updatedFood === null) && (
                        <div className="column-head">
                            <h3>Еда</h3>

                            <button onClick={() => setShowingAddNewFoodForm(true)}
                                    className="btn green-btn">
                                <i className="bx bx-bowl-hot bx-xs"></i>
                                Add
                            </button>
                        </div>
                    )}

                    {(foods.length > 0 && showingAddNewFoodForm === false && updatedFood === null) && renderFoodTable()}

                    {showingAddNewFoodForm && <FoodCreateForm onFoodAdded={onFoodAdded}/>}

                    {updatedFood !== null &&
                        <FoodUpdateForm food={updatedFood} onFoodUpdated={onFoodUpdated}/>}
                </div>

                <div className="day-column">
                    {(showingAddNewInsulinForm === false && updatedInsulin === null) && (
                        <div className="column-head">
                            <h3>Инсулин</h3>

                            <button onClick={() => setShowingAddNewInsulinForm(true)}
                                    className="btn green-btn">
                                <i className="bx bx-injection bx-xs"></i>
                                Add
                            </button>
                        </div>
                    )}

                    {(insulins.length > 0 && showingAddNewInsulinForm === false && updatedInsulin === null) && renderInsulinTable()}

                    {showingAddNewInsulinForm && <InsulinCreateForm onInsulinAdded={onInsulinAdded}/>}

                    {updatedInsulin !== null &&
                        <InsulinUpdateForm insulin={updatedInsulin} onInsulinUpdated={onInsulinUpdated}/>}
                </div>

                <div className="day-column">
                    {(showingAddNewCatheterForm === false && updatedCatheter === null) && (
                        <div className="column-head">
                            <h3>Катетеры</h3>

                            <button onClick={() => setShowingAddNewCatheterForm(true)}
                                    className="btn green-btn">
                                <i className="bx bxs-capsule bx-xs"></i>
                                Add
                            </button>
                        </div>
                    )}

                    {(catheters.length > 0 && showingAddNewCatheterForm === false && updatedCatheter === null) && renderCathetersTable()}

                    {showingAddNewCatheterForm && <CatheterCreateForm onCatheterAdded={onCatheterAdded}/>}

                    {updatedCatheter !== null &&
                        <CatheterUpdateForm catheter={updatedCatheter} onCatheterUpdated={onCatheterUpdated}/>}
                </div>
            </div>
        </main>
    );
}
