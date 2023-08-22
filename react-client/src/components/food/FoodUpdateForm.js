import React, {useState} from "react";
import Constants from "../../utilities/Constants";

export default function FoodUpdateForm(props) {
    const initialFormData = Object.freeze({
        time: props.food.time,
        breadUnits: props.food.breadUnits,
        foodName: props.food.foodName,
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

        const food = {
            id: props.food.id,
            dose: 0,
            time: formData.time,
            breadUnits: formData.breadUnits,
            insulinPinned: 0,
            foodName: formData.foodName,
        };

        console.log(JSON.stringify(food))

        const url = Constants.API_URL_UPDATE_FOOD;

        fetch(url, {
            method: "PUT",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(food)
        }).then(response => response.json())
            .then(responseFromServer => {
                console.log(responseFromServer);
            })
            .catch((error) => {
                console.log(error);
                alert(error)
            });

        props.onFoodUpdated(food);
    };

    return (
        <form>
            <h3>Еда [{formData.time}]</h3>

            <div>
                <div className="form-input-area">
                    <label className="">Время</label>
                    <input value={formData.time} name="time" type="time" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Хлебные единицы</label>
                    <input value={formData.breadUnits} name="breadUnits" type="number" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="form-input-area">
                    <label className="">Еда</label>
                    <input value={formData.foodName} name="foodName" type="text" className="input-area"
                           onChange={handleChange}/>
                </div>

                <div className="btn-container">
                    <button onClick={handleSubmit} className="btn green-btn">Submit</button>
                    <button onClick={() => props.onFoodUpdated(null)} className="btn">Cancel</button>
                </div>
            </div>
        </form>
    );
};
