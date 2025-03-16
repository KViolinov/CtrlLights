import axios from "axios";

class User {
    constructor(id, username, key) {
        this.id = id;
        this.username = username;
        this.key = key;
    }

    async loginVerification(inputKey) {
        try {
            const response = await axios.get(`${process.env.API_BASE_URL}/getLoginVerification/${inputKey}`);
            return response.data.check;
        } catch (err) {
            console.error("Error verifying key:", err);
            throw err;
        }
    }

    static async getByUsername(username) {
        const response = await axios.get(`${process.env.API_BASE_URL}/getByUserName/${username}`);
        if (response.data.user) {
            const userData = response.data.user;
            return new User(
                userData.id,
                userData.username,
                null,
            );
        }
        return null;
    }

    // static async #getById(userId) {
    //     const result = await db.query("SELECT * FROM admin_users WHERE id = $1;", [
    //         userId,
    //     ]);
    //     if (result.rows[0]) {
    //         const userData = result.rows[0];
    //         return new User(
    //             userData.id,
    //             userData.username,
    //             userData.key,
    //         );
    //     }
    //     return null;
    // }
}

export default User;
