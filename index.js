/* 
The Ballad of the Broken Auth

Oh, cursed night, devoid of rest,
My code is flawed, my heart’s distressed.
I type, I run, I crash, I cry—
Authentication, tell me why?

Why do you mock me, line by line?
The logic's sound, the routes align!
Yet still you whisper “Access Denied,”
Like some cruel specter, gloating wide.

Why don’t you work? What must I do?
I’ve checked the docs, I’ve checked them twice,
Yet Passport’s silent, cold as ice—
My user stands, but locked from view.

The session fails, the key’s ignored,
My desperate prints fall unexplored.
"Local strategy not found," you jeer,
Oh, tell me, why am I still here?

I hash, I salt, I fix, I break,
Each step I take’s another ache.
The queries run, the tables stand,
Yet still you slip right through my hand.

Oh, cruelest fate, oh endless fight!
Shall I debug into the night?
Or must I yield, admit defeat,
And let this auth consume my sleep?

No! I rise—my will is steel!
I vow to break this cursed wheel!
Through print statements and pure despair,
I'll force you, auth, to work—I swear!
*/

import express from "express";
import session from "express-session";
import path from "path";
import dotenv from "dotenv";
import passport from "./config/passport.js";
import authRoutes from "./routes/authRoutes.js";

dotenv.config();
const app = express();
const PORT = process.env.PORT || 3000;

// View engine setup
app.set("view engine", "ejs");
app.set("views", path.join(path.resolve(), "views"));
app.use(express.urlencoded({ extended: true }));
app.use(express.json());
app.use(express.static("public"));


// Session middleware
app.use(
    session({
        secret: process.env.SESSION_SECRET,
        resave: false,
        saveUninitialized: true,
        cookie: {
            maxAge: 1000 * 60 * 60 * 24,
        },
    })
);
app.use(passport.initialize());
app.use(passport.session());



// Middleware for global data
app.use((req, res, next) => {
    if (req.user) {
        res.locals.user = req.user;
    } else {
        res.locals.user = null;
    }
    next();
});

function isAuthenticated(req, res, next) {
    if (req.isAuthenticated()) return next();
    res.redirect("/login");
}

// Routes
app.use("/", authRoutes);

app.listen(PORT, () => {
    console.log(`Server running on http://localhost:${PORT}`);
});
