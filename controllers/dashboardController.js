import TrafficLight from "../models/trafficLightModel.js";
import AirQuality from "../models/airQualityModel.js";
import db from "../config/db.js";

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

    static async getTrafficLightsState(req, res) {
        try {
            const trafficLights = await db.query(`SELECT id, LightStatus, 
                EXTRACT(EPOCH FROM TimeSpan) AS RemainingSeconds 
                FROM TrafficLights;`);
            res.json(trafficLights.rows);
        } catch (error) {
            console.log(error);
            res.status(500).send(error.message);
        }
    }

    static async switchTrafficLight(req, res) {
        const { id } = req.body;
        try {
            const trafficLight = await db.query("SELECT LightStatus, TimeSpan FROM TrafficLights WHERE id = $1;", [id]);
            if (!trafficLight.rows[0]) return res.status(404).json({ error: "Traffic light not found" });

            const newStatus = trafficLight.rows[0].LightStatus === "G" ? "R" : "G";
            const remainingTime = trafficLight.rows[0].TimeSpan;

            await db.query("UPDATE TrafficLights SET LightStatus = $1, TimeSpan = $2 WHERE id = $3;", [newStatus, remainingTime, id]);
            res.json({ id, lightStatus: newStatus, timeSpan: remainingTime });
        } catch (error) {
            console.log(error);
            res.status(500).send(error.message);
        }
    }
}

export default DashboardController;