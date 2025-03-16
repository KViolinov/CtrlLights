import TrafficLight from "../models/trafficLightModel.js";
import AirQuality from "../models/airQualityModel.js";

class DashboardController {
    static async getDashboard(req, res) {
        if (req.isAuthenticated()) {
            try {
                const trafficLights = await TrafficLight.getAll();
                const airQualities = await AirQuality.getAll();
                console.log(airQualities);
                res.render("home", { airQualities, trafficLights });
            } catch (error) {
                console.log(error);
                res.status(500).send(error.message);
            }
        } else {
          res.render("welcome");
        }
    }
}

export default DashboardController;