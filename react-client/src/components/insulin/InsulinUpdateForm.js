import React, {useState} from "react";
import Constants from "../../utilities/Constants";

export default function InsulinUpdateForm(props) {
    const initialFormData = Object.freeze({
        time: props.insulin.time
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

        const insulin = {
            id: props.insulin.id,
            time: formData.time
        };

        console.log(JSON.stringify(insulin))

        const url = Constants.API_URL_UPDATE_INSULIN;

        fetch(url, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(insulin)
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            });

        props.onInsulinUpdated(insulin);
    };

    return (
        <form>
            <h3>Инсулин [{formData.time}]</h3>

            <div>
                <div className="form-input-area">
                    <label className="">Время</label>
                    <input value={formData.time} name="time" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>
            </div>

            <div className="btn-container">
                <button onClick={handleSubmit} className="btn green-btn">Submit</button>
                <button onClick={() => props.onInsulinUpdated(null)} className="btn">Cancel</button>
            </div>
        </form>
    );
};
