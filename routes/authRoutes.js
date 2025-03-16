import express from "express";
import UserController from "../controllers/authController.js";
import passport from "../config/passport.js";

const router = express.Router();
router.get("/login", UserController.getLoginPage);
router.post(
  "/login",
  passport.authenticate("local", {
    successRedirect: "/",
    failureRedirect: "/login"
  })
);

router.get("/logout", UserController.logoutController);

export default router;
