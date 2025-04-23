import User from "../models/userModel.js";

class UserController {
  static getLoginPage(req, res) {
    res.render("login");
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
