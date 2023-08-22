import React, {useState} from "react";
import Constants from "../../utilities/Constants";

export default function CatheterCreateForm(props) {
    const initialFormData = Object.freeze({
        time: `${((new Date().getHours() < 10) ? "0" : "") + new Date().getHours() + ":" + ((new Date().getMinutes() < 10) ? "0" : "") + new Date().getMinutes()}`
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

        const catheter = {
            id: 0,
            time: formData.time
        };

        console.log(JSON.stringify(catheter))

        const url = Constants.API_URL_CREATE_CATHETER;

        fetch(url, {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(catheter)
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            });

        props.onCatheterAdded(catheter);
    };

    return (
        <form>
            <h3>Новый катетер</h3>

            <div>
                <div className="form-input-area">
                    <label className="">Время</label>
                    <input value={formData.time} name="time" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>
            </div>

            <div className="btn-container">
                <button onClick={handleSubmit} className="btn green-btn">Submit</button>
                <button onClick={() => props.onCatheterAdded(null)} className="btn">Cancel</button>
            </div>
        </form>
    );
};
