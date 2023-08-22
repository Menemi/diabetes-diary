import React, {useState} from "react";
import Constants from "../../utilities/Constants";

export default function SugarCreateForm(props) {
    const initialFormData = Object.freeze({
        sugar: 5.5,
        time: `${((new Date().getHours() < 10) ? "0" : "") + new Date().getHours() + ":" + ((new Date().getMinutes() < 10) ? "0" : "") + new Date().getMinutes()}`,
        insulinIncreased: 0
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

        const sugar = {
            id: 0,
            sugar: formData.sugar,
            time: formData.time,
            insulinIncreased: formData.insulinIncreased
        };

        console.log(JSON.stringify(sugar))

        const url = Constants.API_URL_CREATE_SUGAR;

        fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(sugar)
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            });

        props.onSugarAdded(sugar);
    };

    return (
        <form>
            <h3>Новый сахар</h3>

            <div>
                <div className="form-input-area">
                    <label className="">Сахар</label>
                    <input value={formData.sugar} name="sugar" type="number" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Время</label>
                    <input value={formData.time} name="time" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Инсулин</label>
                    <input value={formData.insulinIncreased} name="insulinIncreased" type="number"
                           className="input-area" onChange={handleChange}/>
                </div>

                <div className="btn-container">
                    <button onClick={handleSubmit} className="btn green-btn">Submit</button>
                    <button onClick={() => props.onSugarAdded(null)} className="btn">Cancel</button>
                </div>
            </div>
        </form>
    );
};
