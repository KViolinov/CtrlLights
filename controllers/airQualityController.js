import AirQuality from "../models/airQualityModel.js";

class AirQualityController {
    static async getAirQualities(req, res) {
        try {
            const airQualities = await AirQuality.getAll();
            res.render("airQuality", { airQualities });
        } catch (error) {
            console.log(error);
            res.status(500).send(error.message);
        }
    }
}

export default AirQualityController;