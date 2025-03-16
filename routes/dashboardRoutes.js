import express from "express";
import DashboardController from "../controllers/dashboardController.js";

const router = express.Router();
router.get("/", DashboardController.getDashboard);

export default router;