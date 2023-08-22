import React, {useEffect, useState} from "react"
import Constants from "../utilities/Constants";
import DoseCreateForm from "../components/dose/DoseCreateForm";
import DoseUpdateForm from "../components/dose/DoseUpdateForm";

export default function Doses() {
    //#region Константы
    const initialFormData = Object.freeze({
        date1: null,
        date2: null,
    });

    const [doses, setDoses] = useState([]);
    const [showingAddNewDoseForm, setShowingAddNewDoseForm] = useState(false);
    const [updatedDose, setUpdatedDose] = useState(null);
    // const [formData, setFormData] = useState(initialFormData);

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
        let url = Constants.API_URL_GET_DOSES;

        fetch(url, {
            method: "GET"
        }).then(response => response.json())
            .then(doseFromServer => {
                setDoses(doseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }, []);
    //#endregion

    //#region Отображение данных на странице
    function renderDosesTable() {
        return (
            <>
                {
                    doses.map((dose) =>
                        <div className="single-dose-data">
                            <div className="dose-info">
                                <div className="data-time-container">
                                    <div className="dose-data">{dose.startTime} - {dose.endTime} : {dose.dose}</div>
                                </div>
                            </div>
                            <div className="interaction-doses-buttons-area">
                                <button onClick={() => {
                                    if (window.confirm(`Sure wanna remove sugar [${dose.startTime} - ${dose.endTime}]`)) deleteDose(dose.id)
                                }} className="btn red-btn">
                                    <i className="bx bx-x bx-xs"></i>
                                </button>
                                <button onClick={() => setUpdatedDose(dose)} className="btn orange-btn">
                                    <i className="bx bx-edit bx-xs"></i>
                                </button>
                            </div>
                        </div>)
                }
            </>
        )
    }

    //#endregion

    //#region Работа с данными
    function deleteDose(id) {
        const url = `${Constants.API_URL_REMOVE_DOSE_BY_ID}/${id}`;

        fetch(url, {
            method: "DELETE"
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
                onDoseDeleted(id);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            })
    }
    
    function onDoseAdded(dose) {
        setShowingAddNewDoseForm(false);

        if (dose === null) {
            return;
        }
    }

    function onDoseUpdated(dose) {
        setUpdatedDose(null);

        if (dose === null) {
            return;
        }

        let dosesCopy = [...doses];
        const index = dosesCopy.findIndex((dosesCopyDose, currentIndex) => {
            if (dosesCopyDose.id === dose.id) {
                return true;
            }
        })

        if (index !== -1) {
            dosesCopy[index] = dose;
        }

        setDoses(dosesCopy);
    }

    function onDoseDeleted(id) {
        let dosesCopy = [...doses];
        const index = dosesCopy.findIndex((dosesCopyDose, currentIndex) => {
            if (dosesCopyDose.id === id) {
                return true;
            }
        })

        if (index !== -1) {
            dosesCopy.splice(index, 1);
        }

        setDoses(dosesCopy);
    }
    //#endregion

    return (
        <main>
            <div className={"board-view-centered"}>
                <div className="day-column dose">
                    {(showingAddNewDoseForm === false && updatedDose === null) && (
                        <div className="column-head">
                            <h3>Дозы</h3>

                            <button onClick={() => setShowingAddNewDoseForm(true)}
                                    className="btn green-btn">
                                <i className="bx bx-injection bx-xs"></i>
                                Add
                            </button>
                        </div>
                    )}

                    {(doses.length > 0 && showingAddNewDoseForm === false && updatedDose === null) && renderDosesTable()}

                    {showingAddNewDoseForm && <DoseCreateForm onDoseAdded={onDoseAdded}/>}

                    {updatedDose !== null &&
                        <DoseUpdateForm dose={updatedDose} onDoseUpdated={onDoseUpdated}/>}
                </div>
            </div>
        </main>
    )
}
