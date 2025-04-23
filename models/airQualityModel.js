import axios from "axios";

class AirQuality {
    constructor(id, date, amount) {
        this.id = id;
        this.date = date;
        this.amount = amount;
    }

    static async getAll() {
        const response = await axios.get(`${process.env.API_BASE_URL}/getAirQualities`);
        const airQualities = Object.values(response.data.airQualityList);
        return airQualities.map((airQuality) => new AirQuality(
            airQuality.id,
            airQuality.date,
            airQuality.amount,
        ));
    }
}

export default AirQuality;