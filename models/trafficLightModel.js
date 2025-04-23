import axios from "axios";

class TrafficLight {
    constructor(id, name, freeLaneStatus, timespan, lane, lightStatus) {
        this.id = id;
        this.name = name;
        this.freeLaneStatus = freeLaneStatus;
        this.timespan = timespan;
        this.lane = lane;
        this.lightStatus = lightStatus;
    }

    static async getAll() {
        const response = await axios.get(`${process.env.API_BASE_URL}/getTrafficLights`);
        const lights = Object.values(response.data.trafficLightsList);
        return lights.map((light) => new TrafficLight(
            light.id,
            light.name,
            light.freeLaneStatus,
            light.timeSpan,
            light.lane,
            light.lightStatus,
        ));
    }
}

export default TrafficLight;