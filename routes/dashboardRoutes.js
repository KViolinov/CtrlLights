import express from "express";
import DashboardController from "../controllers/dashboardController.js";

const router = express.Router();
router.get("/", DashboardController.getDashboard);

router.get("/traffic-lights", DashboardController.getTrafficLightsState);
router.post("/traffic-lights/switch", DashboardController.switchTrafficLight);

export default router;