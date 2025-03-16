import db from "../config/db.js";

class User {
    constructor(id, username, key) {
        this.id = id;
        this.username = username;
        this.key = key;
    }

    async loginVerification(inputKey) {
        try {
            const result = await db.query(
                "SELECT key FROM admin_users WHERE id = $1",
                [this.id]
            );
            const storedKey = result.rows[0].key;
            return inputKey === storedKey;
        } catch (err) {
            console.error("Error verifying key:", err);
            throw err;
        }
    }

    static async getByUsername(username) {
        const result = await db.query(
            "SELECT id, username FROM admin_users WHERE username = $1;",
            [username]
        );

        if (result.rows[0]) {
            const userData = result.rows[0];
            return new User(
                userData.id,
                userData.username,
                null,
            );
        }
        return null;
    }

    static async #getById(userId) {
        const result = await db.query("SELECT * FROM admin_users WHERE id = $1;", [
            userId,
        ]);
        if (result.rows[0]) {
            const userData = result.rows[0];
            return new User(
                userData.id,
                userData.username,
                userData.key,
            );
        }
        return null;
    }
}

export default User;
