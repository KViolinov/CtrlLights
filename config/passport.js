import passport from "passport";
import { Strategy as LocalStrategy } from "passport-local";
import User from "../models/userModel.js";

passport.use(
    new LocalStrategy(async (username, password, done) => {
        const user = await User.getByUsername(username);
        if (!user) {
            return done(null, false, { message: "Username does not exist." });
        }

        const isKeyCorrect = await user.loginVerification(password);
        if (!isKeyCorrect) {
            return done(null, false, { message: "Invalid key." });
        }
        return done(null, user);
    })
);

// Process users to put in session
passport.serializeUser((user, cb) => {
    return cb(null, user);
});

passport.deserializeUser((user, cb) => {
    return cb(null, user);
});

export default passport;