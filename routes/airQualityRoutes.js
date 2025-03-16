import express from 'express';
import AirQualityController from '../controllers/airQualityController.js';

const router = express.Router();
router.get('/airQualities', AirQualityController.getAirQualities);

export default router;