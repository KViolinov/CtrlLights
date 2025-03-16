-- Stores all ESP devices
CREATE TABLE esp_devices (
    id SERIAL PRIMARY KEY,
    mac_address VARCHAR(17) UNIQUE NOT NULL
);

-- Stores all air quality checks
CREATE TABLE air_quality_logs (
    id SERIAL PRIMARY KEY,
    esp_device_id INT NOT NULL,
    air_quality FLOAT NOT NULL,
    recorded_at TIMESTAMPTZ DEFAULT NOW(),
    CONSTRAINT fk_air_quality_logs_devices 
        FOREIGN KEY (esp_device_id) 
        REFERENCES esp_devices(id) 
        ON UPDATE CASCADE
        ON DELETE CASCADE
);

-- Only for admins
CREATE TABLE admin_users (
    id SERIAL PRIMARY KEY,
    username VARCHAR(50) NOT NULL UNIQUE,
    key VARCHAR(16) NOT NULL UNIQUE
);

-- Stores all traffic lights devices
CREATE TABLE traffic_lights (
    id SERIAL PRIMARY KEY,
    location TEXT NOT NULL,
    direction TEXT NOT NULL
);

-- Recoreds the state of the traffic light
CREATE TABLE traffic_light_states (
    id SERIAL PRIMARY KEY,
    traffic_light_id INT NOT NULL,
    color TEXT NOT NULL CHECK (color IN ('red', 'yellow', 'green')),
    duration INT NOT NULL,
    timestamp TIMESTAMPTZ DEFAULT NOW(),
    CONSTRAINT fk_traffic_light_states_traffic_lights
      FOREIGN KEY (traffic_light_id)
      REFERENCES traffic_lights(id) 
      ON UPDATE CASCADE
      ON DELETE CASCADE
);