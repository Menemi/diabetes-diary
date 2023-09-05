const API_BASE_URL_DEV = "https://localhost:7233";
const API_BASE_URL_PROD = "https://appname.azurewebsites.net";

function getToday() {
    let today = new Date();
    let dd = String(today.getDate()).padStart(2, "0");
    let mm = String(today.getMonth() + 1).padStart(2, "0"); //January is 0!
    let yyyy = today.getFullYear();

    return dd + "." + mm + "." + yyyy;
}

const ENDPOINTS = {
    GET_SUGARS: "sugars",
    GET_AVG_SUGAR: "sugars/avg",
    CREATE_SUGAR: "sugars",
    UPDATE_SUGAR: "sugars",
    REMOVE_SUGAR_BY_ID: "sugars",

    GET_FOOD: "food",
    CREATE_FOOD: "food",
    UPDATE_FOOD: "food",
    REMOVE_FOOD_BY_ID: "food",

    GET_INSULIN: "insulin",
    GET_LAST_INSULIN: "insulin/last",
    CREATE_INSULIN: "insulin",
    UPDATE_INSULIN: "insulin",
    REMOVE_INSULIN_BY_ID: "insulin",

    GET_CATHETERS: "catheters",
    GET_LAST_CATHETER: "catheter/last",
    CREATE_CATHETER: "catheters",
    UPDATE_CATHETER: "catheters",
    REMOVE_CATHETER_BY_ID: "catheters",

    GET_DOSES: "doses",
    CREATE_DOSE: "doses",
    UPDATE_DOSE: "doses",
    REMOVE_DOSE_BY_ID: "doses",
}

const dev = {
    API_URL_GET_SUGARS: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_SUGARS}`,
    API_URL_GET_AVG_SUGARS: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_AVG_SUGAR}`,
    API_URL_GET_TODAY_SUGARS: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_SUGARS}?date1=${getToday()}`,
    API_URL_CREATE_SUGAR: `${API_BASE_URL_DEV}/${ENDPOINTS.CREATE_SUGAR}`,
    API_URL_UPDATE_SUGAR: `${API_BASE_URL_DEV}/${ENDPOINTS.UPDATE_SUGAR}`,
    API_URL_REMOVE_SUGAR_BY_ID: `${API_BASE_URL_DEV}/${ENDPOINTS.REMOVE_SUGAR_BY_ID}`,

    API_URL_GET_FOOD: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_FOOD}`,
    API_URL_GET_TODAY_FOOD: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_FOOD}?date1=${getToday()}`,
    API_URL_CREATE_FOOD: `${API_BASE_URL_DEV}/${ENDPOINTS.CREATE_FOOD}`,
    API_URL_UPDATE_FOOD: `${API_BASE_URL_DEV}/${ENDPOINTS.UPDATE_FOOD}`,
    API_URL_REMOVE_FOOD_BY_ID: `${API_BASE_URL_DEV}/${ENDPOINTS.REMOVE_FOOD_BY_ID}`,

    API_URL_GET_INSULIN: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_INSULIN}`,
    API_URL_GET_LAST_INSULIN: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_LAST_INSULIN}`,
    API_URL_GET_TODAY_INSULIN: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_INSULIN}?date1=${getToday()}`,
    API_URL_CREATE_INSULIN: `${API_BASE_URL_DEV}/${ENDPOINTS.CREATE_INSULIN}`,
    API_URL_UPDATE_INSULIN: `${API_BASE_URL_DEV}/${ENDPOINTS.UPDATE_INSULIN}`,
    API_URL_REMOVE_INSULIN_BY_ID: `${API_BASE_URL_DEV}/${ENDPOINTS.REMOVE_INSULIN_BY_ID}`,

    API_URL_GET_CATHETERS: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_CATHETERS}`,
    API_URL_GET_LAST_CATHETER: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_LAST_CATHETER}`,
    API_URL_GET_TODAY_CATHETERS: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_CATHETERS}?date1=${getToday()}`,
    API_URL_CREATE_CATHETER: `${API_BASE_URL_DEV}/${ENDPOINTS.CREATE_CATHETER}`,
    API_URL_UPDATE_CATHETER: `${API_BASE_URL_DEV}/${ENDPOINTS.UPDATE_CATHETER}`,
    API_URL_REMOVE_CATHETER_BY_ID: `${API_BASE_URL_DEV}/${ENDPOINTS.REMOVE_CATHETER_BY_ID}`,

    API_URL_GET_DOSES: `${API_BASE_URL_DEV}/${ENDPOINTS.GET_DOSES}`,
    API_URL_CREATE_DOSE: `${API_BASE_URL_DEV}/${ENDPOINTS.CREATE_DOSE}`,
    API_URL_UPDATE_DOSE: `${API_BASE_URL_DEV}/${ENDPOINTS.UPDATE_DOSE}`,
    API_URL_REMOVE_DOSE_BY_ID: `${API_BASE_URL_DEV}/${ENDPOINTS.REMOVE_DOSE_BY_ID}`,
}

const prod = {
    API_URL_GET_SUGARS: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_SUGARS}`,
    API_URL_GET_AVG_SUGARS: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_AVG_SUGAR}`,
    API_URL_CREATE_SUGAR: `${API_BASE_URL_PROD}/${ENDPOINTS.CREATE_SUGAR}`,
    API_URL_UPDATE_SUGAR: `${API_BASE_URL_PROD}/${ENDPOINTS.UPDATE_SUGAR}`,
    API_URL_REMOVE_SUGAR_BY_ID: `${API_BASE_URL_PROD}/${ENDPOINTS.REMOVE_SUGAR_BY_ID}`,

    API_URL_GET_FOOD: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_FOOD}`,
    API_URL_GET_TODAY_FOOD: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_FOOD}?date1=${getToday()}`,
    API_URL_CREATE_FOOD: `${API_BASE_URL_PROD}/${ENDPOINTS.CREATE_FOOD}`,
    API_URL_UPDATE_FOOD: `${API_BASE_URL_PROD}/${ENDPOINTS.UPDATE_FOOD}`,
    API_URL_REMOVE_FOOD_BY_ID: `${API_BASE_URL_PROD}/${ENDPOINTS.REMOVE_FOOD_BY_ID}`,

    API_URL_GET_INSULIN: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_INSULIN}`,
    API_URL_GET_LAST_INSULIN: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_LAST_INSULIN}`,
    API_URL_GET_TODAY_INSULIN: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_INSULIN}?date1=${getToday()}`,
    API_URL_CREATE_INSULIN: `${API_BASE_URL_PROD}/${ENDPOINTS.CREATE_INSULIN}`,
    API_URL_UPDATE_INSULIN: `${API_BASE_URL_PROD}/${ENDPOINTS.UPDATE_INSULIN}`,
    API_URL_REMOVE_INSULIN_BY_ID: `${API_BASE_URL_PROD}/${ENDPOINTS.REMOVE_INSULIN_BY_ID}`,

    API_URL_GET_CATHETERS: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_CATHETERS}`,
    API_URL_GET_LAST_CATHETER: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_LAST_CATHETER}`,
    API_URL_GET_TODAY_CATHETERS: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_CATHETERS}?date1=${getToday()}`,
    API_URL_CREATE_CATHETER: `${API_BASE_URL_PROD}/${ENDPOINTS.CREATE_CATHETER}`,
    API_URL_UPDATE_CATHETER: `${API_BASE_URL_PROD}/${ENDPOINTS.UPDATE_CATHETER}`,
    API_URL_REMOVE_CATHETER_BY_ID: `${API_BASE_URL_PROD}/${ENDPOINTS.REMOVE_CATHETER_BY_ID}`,

    API_URL_GET_DOSES: `${API_BASE_URL_PROD}/${ENDPOINTS.GET_DOSES}`,
    API_URL_CREATE_DOSE: `${API_BASE_URL_PROD}/${ENDPOINTS.CREATE_DOSE}`,
    API_URL_UPDATE_DOSE: `${API_BASE_URL_PROD}/${ENDPOINTS.UPDATE_DOSE}`,
    API_URL_REMOVE_DOSE_BY_ID: `${API_BASE_URL_PROD}/${ENDPOINTS.REMOVE_DOSE_BY_ID}`,
}

const Constants = process.env.NODE_ENV === "development" ? dev : prod;

export default Constants;
