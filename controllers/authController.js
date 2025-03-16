import User from "../models/userModel.js";

class UserController {
  static getLoginPage(req, res) {
    res.render("login");
  }

  static getHomePage(req, res) {
    if (req.isAuthenticated()) {
      res.render("home");
    } else {
      res.render("welcome");
    }
  }

  static logoutController(req, res) {
    req.logout(function (err) {
      if (err) {
        return next(err);
      }
      res.redirect("/");
    });
  }
}

export default UserController;
