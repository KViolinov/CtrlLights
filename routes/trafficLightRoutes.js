import express from "express";
import TrafficLightController from "../controllers/trafficLightController.js";

const router = express.Router();
router.get("/trafficLights", TrafficLightController.getTrafficLights);

export default router;