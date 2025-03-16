#ver 1.1 - currently working
#
# import cv2
# import numpy as np
#
# # HSV range for blue detection (Based on your values)
# lower_blue = np.array([66, 57, 0])
# upper_blue = np.array([107, 255, 255])
#
# # Start webcam
# cap = cv2.VideoCapture(1)
#
# # Set the window to fullscreen
# window_name = "Blue Tape Detection"
# cv2.namedWindow(window_name)
# cv2.setWindowProperty(window_name, cv2.WND_PROP_FULLSCREEN, cv2.WINDOW_FULLSCREEN)
#
# # --- Lane Drawing Parameters (Adjust these based on your intersection) ---
# lane_lines = [
#     ((250, 0), (250, 480), "5"),  # Lane 1 - Left Boundary (empty label)
#     ((295, 0), (295, 480), "6"),  # Lane 1 - Right Boundary
#     ((345, 0), (345, 480), "7"),  # Lane 2 - Right Boundary
#     ((385, 0), (385, 480), " "),  # Lane 3 - Right Boundary
#     ((0, 190), (640, 180), "1"),  # Lane 4 - Top Boundary
#     ((0, 219), (640, 210), "2"),  # Lane 5 - Bottom Boundary
#     ((0, 250), (640, 240), ""),  # Lane 6 - Top Boundary (empty label)
#     ((0, 275), (640, 265), "3"),  # Lane 6 - Middle Boundary
#     ((0, 305), (640, 290), "4"),  # Lane 7 - Bottom Boundary
# ]
# lane_color = (0, 165, 255)  # Orange color for lanes (BGR format)
# lane_thickness = 2
# # -------------------------------------------------------------------------
#
# def get_lane(x, y, lane_lines):
#     """Determines the lane based on x, y coordinates."""
#     if y < 190:
#         return "5"
#     elif 190 <= y < 219:
#         return "6"
#     elif 250 <= y < 305:
#         return "3"
#     elif y >= 305:
#         return "4"
#     elif 250 <= x < 295:
#         return "5"
#     elif 295 <= x < 345:
#         return "6"
#     elif 345 <= x < 385:
#         return "7"
#     else:
#         return "Unknown"
#
# while True:
#     ret, frame = cap.read()
#     if not ret:
#         break
#
#     # Convert to HSV
#     hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
#
#     # Create mask for blue
#     mask = cv2.inRange(hsv, lower_blue, upper_blue)
#
#     # Apply morphological operations to enhance detection
#     kernel = np.ones((5, 5), np.uint8)
#     mask = cv2.dilate(mask, kernel, iterations=2)
#
#     # Find contours
#     contours, _ = cv2.findContours(mask, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
#
#     for cnt in contours:
#         area = cv2.contourArea(cnt)
#         if area > 50:
#             (x, y), radius = cv2.minEnclosingCircle(cnt)
#             center = (int(x), int(y))
#             radius = int(radius)
#
#             if radius > 5:
#                 cv2.circle(frame, center, radius, (255, 0, 0), 2)  # Draw blue circle on frame
#
#                 lane = get_lane(x, y, lane_lines)  # Determine the lane
#                 coordinates = f"({int(x)}, {int(y)}) Lane: {lane}"  # Include lane in text
#                 cv2.putText(frame, coordinates, (int(x) + 10, int(y) - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 255, 0), 1)
#
#     # Draw lane lines and add labels
#     for start_point, end_point, lane_label in lane_lines:
#         cv2.line(frame, start_point, end_point, lane_color, lane_thickness)
#
#         # Place label in top-left corner of the line segment
#         label_x = min(start_point[0], end_point[0]) + 5  # Add a small offset
#         label_y = min(start_point[1], end_point[1]) + 20  # Add a small offset
#
#         if lane_label:  # Only draw labels that are not empty strings
#             cv2.putText(frame, lane_label, (label_x, label_y), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0), 2)  # Green color
#
#     # Show results
#     cv2.imshow(window_name, frame)
#     cv2.imshow("Mask", mask)
#     result = cv2.bitwise_and(frame, frame, mask=mask)
#     cv2.imshow("Filtered Blue", result)
#
#     if cv2.waitKey(1) & 0xFF == ord("q"):
#         break
#
# cap.release()
# cv2.destroyAllWindows()




# python controlling esp32 device

# import serial
# import time
#
# # Open the serial connection to the master ESP32
# ser = serial.Serial('COM4', 115200)  # Replace COM_PORT with your actual COM port (e.g., COM3 on Windows or /dev/ttyUSB0 on Linux)
#
# # Wait for the ESP32 to initialize
# time.sleep(2)
#
# # Send a command (message) to the master ESP32
# message = "2"
# ser.write((message + '\n').encode())  # Send message to ESP32, append newline to match the trimming on ESP32
#
# # Optionally, wait for a response (if implemented in ESP32)
# time.sleep(1)
#
# # Close the serial connection
# ser.close()




# camera settings/config
#
# import cv2
# import numpy as np
#
# def nothing(x):
#     pass
#
# # Start webcam
# cap = cv2.VideoCapture(1)
#
# # Create trackbars to adjust HSV values
# cv2.namedWindow("Trackbars")
# cv2.createTrackbar("Lower H", "Trackbars", 90, 180, nothing)
# cv2.createTrackbar("Lower S", "Trackbars", 50, 255, nothing)
# cv2.createTrackbar("Lower V", "Trackbars", 50, 255, nothing)
# cv2.createTrackbar("Upper H", "Trackbars", 130, 180, nothing)
# cv2.createTrackbar("Upper S", "Trackbars", 255, 255, nothing)
# cv2.createTrackbar("Upper V", "Trackbars", 255, 255, nothing)
#
# while True:
#     ret, frame = cap.read()
#     if not ret:
#         break
#
#     hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)
#
#     # Get trackbar positions
#     lower_h = cv2.getTrackbarPos("Lower H", "Trackbars")
#     lower_s = cv2.getTrackbarPos("Lower S", "Trackbars")
#     lower_v = cv2.getTrackbarPos("Lower V", "Trackbars")
#     upper_h = cv2.getTrackbarPos("Upper H", "Trackbars")
#     upper_s = cv2.getTrackbarPos("Upper S", "Trackbars")
#     upper_v = cv2.getTrackbarPos("Upper V", "Trackbars")
#
#     lower_blue = np.array([lower_h, lower_s, lower_v])
#     upper_blue = np.array([upper_h, upper_s, upper_v])
#
#     mask = cv2.inRange(hsv, lower_blue, upper_blue)
#     result = cv2.bitwise_and(frame, frame, mask=mask)
#
#     cv2.imshow("Original", frame)
#     cv2.imshow("Mask", mask)
#     cv2.imshow("Filtered Blue", result)
#
#     if cv2.waitKey(1) & 0xFF == ord("q"):
#         break
#
# cap.release()
# cv2.destroyAllWindows()


import cv2
import numpy as np

# HSV range for blue detection (Based on your values)
lower_blue = np.array([66, 57, 0])
upper_blue = np.array([107, 255, 255])

# Start webcam
cap = cv2.VideoCapture(2)

# Set the window to fullscreen
window_name = "Blue Tape Detection"
cv2.namedWindow(window_name)
cv2.setWindowProperty(window_name, cv2.WND_PROP_FULLSCREEN, cv2.WINDOW_FULLSCREEN)

# --- Lane Drawing Parameters (Adjust these based on your intersection) ---
lane_lines = [
    ((250, 0), (250, 480), "5"),  # Lane 1 - Left Boundary (empty label)
    ((295, 0), (295, 480), "6"),  # Lane 1 - Right Boundary
    ((345, 0), (345, 480), "7"),  # Lane 2 - Right Boundary
    ((385, 0), (385, 480), " "),  # Lane 3 - Right Boundary
    ((0, 190), (640, 180), "1"),  # Lane 4 - Top Boundary
    ((0, 219), (640, 210), "2"),  # Lane 5 - Bottom Boundary
    ((0, 250), (640, 240), ""),  # Lane 6 - Top Boundary (empty label)
    ((0, 275), (640, 265), "3"),  # Lane 6 - Middle Boundary
    ((0, 305), (640, 290), "4"),  # Lane 7 - Bottom Boundary
]
lane_color = (0, 165, 255)  # Orange color for lanes (BGR format)
lane_thickness = 2


# -------------------------------------------------------------------------

def get_lane(x, y, lane_lines):
    """Determines the lane based on x, y coordinates."""
    if 250 <= x < 295:
        return "5"
    elif 295 <= x < 345:
        return "6"
    elif 345 <= x < 385:
        return "7"
    elif y < 190:
        return "1"  # Corrected lane number to 1
    elif 190 <= y < 219:
        return "2"
    elif 250 <= y < 305:
        return "3"
    elif y >= 305:
        return "4"
    else:
        return "Unknown"


def count_cars_in_lanes(cars):
    """Counts cars in each lane."""
    lane_counts = {}
    for lane in ["1", "2", "3", "4", "5", "6", "7", "Unknown"]:
        lane_counts[lane] = 0

    for car in cars:
        lane_counts[car["lane"]] += 1

    return lane_counts


while True:
    ret, frame = cap.read()
    if not ret:
        break

    # Convert to HSV
    hsv = cv2.cvtColor(frame, cv2.COLOR_BGR2HSV)

    # Create mask for blue
    mask = cv2.inRange(hsv, lower_blue, upper_blue)

    # Apply morphological operations to enhance detection
    kernel = np.ones((5, 5), np.uint8)
    mask = cv2.dilate(mask, kernel, iterations=2)

    # Find contours
    contours, _ = cv2.findContours(mask, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)

    cars = []  # List to store car information
    for cnt in contours:
        area = cv2.contourArea(cnt)
        if area > 50:
            (x, y), radius = cv2.minEnclosingCircle(cnt)
            center = (int(x), int(y))
            radius = int(radius)

            if radius > 5:
                cv2.circle(frame, center, radius, (255, 0, 0), 2)  # Draw blue circle on frame

                lane = get_lane(x, y, lane_lines)  # Determine the lane
                coordinates = f"({int(x)}, {int(y)}) Lane: {lane}"  # Include lane in text
                cv2.putText(frame, coordinates, (int(x) + 10, int(y) - 10), cv2.FONT_HERSHEY_SIMPLEX, 0.5, (0, 255, 0),
                            1)

                cars.append({"x": x, "y": y, "lane": lane})

    # Draw lane lines and add labels
    for start_point, end_point, lane_label in lane_lines:
        cv2.line(frame, start_point, end_point, lane_color, lane_thickness)

        # Place label in top-left corner of the line segment
        label_x = min(start_point[0], end_point[0]) + 5  # Add a small offset
        label_y = min(start_point[1], end_point[1]) + 20  # Add a small offset

        if lane_label:  # Only draw labels that are not empty strings
            cv2.putText(frame, lane_label, (label_x, label_y), cv2.FONT_HERSHEY_SIMPLEX, 1, (0, 255, 0),
                        2)  # Green color

    # Count cars in each lane
    lane_counts = count_cars_in_lanes(cars)
    print("Car Counts per Lane:", lane_counts)

    # Show results
    cv2.imshow(window_name, frame)
    cv2.imshow("Mask", mask)
    result = cv2.bitwise_and(frame, frame, mask=mask)
    cv2.imshow("Filtered Blue", result)

    if cv2.waitKey(1) & 0xFF == ord("q"):
        break

cap.release()
cv2.destroyAllWindows()
