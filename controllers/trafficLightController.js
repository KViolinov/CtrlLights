import TrafficLight from "../models/trafficLightModel.js";

class TrafficLightController {
    static async getTrafficLights(req, res) {
        try {
            const trafficLights = await TrafficLight.getAll();
            res.render("trafficLight", { trafficLights });
        } catch (error) {
            console.log(error);
            res.status(500).send(error.message);
        }
    }
}

export default TrafficLightController;