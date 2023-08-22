import React, {useState} from "react";
import Constants from "../../utilities/Constants";

export default function DoseUpdateForm(props) {
    const initialFormData = Object.freeze({
        dose: props.dose.dose,
        startTime: props.dose.startTime,
        endTime: props.dose.endTime,
    });

    const [formData, setFormData] = useState(initialFormData);
    const handleChange = (event) => {
        setFormData({
            ...formData,
            [event.target.name]: event.target.value,
        })
    };

    const handleSubmit = (event) => {
        event.preventDefault();

        const dose = {
            id: props.dose.id,
            dose: formData.dose,
            startTime: formData.startTime,
            endTime: formData.endTime,
        };

        console.log(JSON.stringify(dose))

        const url = Constants.API_URL_UPDATE_DOSE;

        fetch(url, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(dose)
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            });

        props.onDoseUpdated(dose);
    };

    return (
        <form>
            <h3>Доза [{formData.startTime} - {formData.endTime}]</h3>

            <div>
                <div className="form-input-area">
                    <label className="">Доза</label>
                    <input value={formData.dose} name="dose" type="number" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Начало</label>
                    <input value={formData.startTime} name="startTime" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Конец</label>
                    <input value={formData.endTime} name="endTime" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="btn-container">
                    <button onClick={handleSubmit} className="btn green-btn">Submit</button>
                    <button onClick={() => props.onDoseUpdated(null)} className="btn">Cancel</button>
                </div>
            </div>
        </form>
    );
};
