// #include <WiFi.h>
// #include <esp_now.h>

// #define LED_PIN 2  // The built-in LED is typically on GPIO2

// // Structure to receive data (only message field)
// typedef struct struct_message {
//   char a[32];  // Message field
// } struct_message;

// // Create a struct_message object to hold the incoming data
// struct_message incomingMessage;

// // Callback function to handle received data
// void onDataReceived(const esp_now_recv_info* recv_info, const uint8_t* data, int len) {
//   // Copy the received data into the structure
//   memcpy(&incomingMessage, data, sizeof(incomingMessage));

//   // Print the received message
//   Serial.print("Received message from master: ");
//   Serial.println(incomingMessage.a);

//   // Optionally, print the MAC address of the sender
//   Serial.print("Sender MAC address: ");
//   for (int i = 0; i < 6; i++) {
//     Serial.print(recv_info->src_addr[i], HEX);
//     if (i < 5) {
//       Serial.print(":");
//     }
//   }
//   Serial.println();

//   // Check if the message is "1", "2", or "3"
//   if (strcmp(incomingMessage.a, "1") == 0) {
//     Serial.println("Received message '1'");
//     digitalWrite(LED_PIN, HIGH);  // Turn the LED on

//     // Add your code to handle message "1"
//   }
//   else if (strcmp(incomingMessage.a, "2") == 0) {
//     Serial.println("Received message '2'");
//     digitalWrite(LED_PIN, LOW);  // Turn the LED on
//     // Add your code to handle message "2"
//   }
//   else if (strcmp(incomingMessage.a, "3") == 0) {
//     Serial.println("Received message '3'");
//     // Add your code to handle message "3"
//   }
//   else {
//     Serial.println("Received an unknown message");
//   }
// }

// void setup() {
//   // Initialize Serial Monitor
//   Serial.begin(115200);

//   // Set device as Wi-Fi Station
//   WiFi.mode(WIFI_STA);

//   // Initialize GPIO2 as an output
//   pinMode(LED_PIN, OUTPUT);
  
//   // Turn the LED on by setting GPIO2 to LOW (active LOW)
//   digitalWrite(LED_PIN, LOW);

//   // Initialize ESP-NOW
//   if (esp_now_init() != ESP_OK) {
//     Serial.println("ESP-NOW initialization failed");
//     return;
//   }

//   // Register the callback function to receive data
//   esp_now_register_recv_cb(onDataReceived);
// }

// void loop() {
//   // Nothing to do in loop, just waiting for data
//   delay(1000);
// }







const int TL1Red = 34;
const int TL1Green = 35;

const int TL2Red = 32;
const int TL2Green = 33;

const int TL3Red = 25;
const int TL3Green = 26;

const int TL4Red = 27;
const int TL4Green = 14;

const int TL5Red = 12;
const int TL5Green = 13;

const int TL6Red = 23;
const int TL6Green = 22;

const int TL7Red = 21;
const int TL7Green = 19;

const int TL8Red = 18;
const int TL8Green = 5;

void setup() {
  pinMode (TL1Red, OUTPUT);
  pinMode (TL1Green, OUTPUT);

  pinMode (TL2Red, OUTPUT);
  pinMode (TL2Green, OUTPUT);

  pinMode (TL3Red, OUTPUT);
  pinMode (TL3Green, OUTPUT);

  pinMode (TL4Red, OUTPUT);
  pinMode (TL4Green, OUTPUT);

  pinMode (TL5Red, OUTPUT);
  pinMode (TL5Green, OUTPUT);

  pinMode (TL6Red, OUTPUT);
  pinMode (TL6Green, OUTPUT);

  pinMode (TL7Red, OUTPUT);
  pinMode (TL7Green, OUTPUT);

  pinMode (TL8Red, OUTPUT);
  pinMode (TL8Green, OUTPUT);
}

void loop() {
  // Turn on each LED pair sequentially
  digitalWrite(TL1Red, HIGH);
  delay(1000);
  digitalWrite(TL1Red, LOW);
  delay(500);
  digitalWrite(TL1Green, HIGH);
  delay(1000);
  digitalWrite(TL1Green, LOW);
  delay(500);

  digitalWrite(TL2Red, HIGH);
  delay(1000);
  digitalWrite(TL2Red, LOW);
  delay(500);
  digitalWrite(TL2Green, HIGH);
  delay(1000);
  digitalWrite(TL2Green, LOW);
  delay(500);

  digitalWrite(TL3Red, HIGH);
  delay(1000);
  digitalWrite(TL3Red, LOW);
  delay(500);
  digitalWrite(TL3Green, HIGH);
  delay(1000);
  digitalWrite(TL3Green, LOW);
  delay(500);

  digitalWrite(TL4Red, HIGH);
  delay(1000);
  digitalWrite(TL4Red, LOW);
  delay(500);
  digitalWrite(TL4Green, HIGH);
  delay(1000);
  digitalWrite(TL4Green, LOW);
  delay(500);

  digitalWrite(TL5Red, HIGH);
  delay(1000);
  digitalWrite(TL5Red, LOW);
  delay(500);
  digitalWrite(TL5Green, HIGH);
  delay(1000);
  digitalWrite(TL5Green, LOW);
  delay(500);

  digitalWrite(TL6Red, HIGH);
  delay(1000);
  digitalWrite(TL6Red, LOW);
  delay(500);
  digitalWrite(TL6Green, HIGH);
  delay(1000);
  digitalWrite(TL6Green, LOW);
  delay(500);

  digitalWrite(TL7Red, HIGH);
  delay(1000);
  digitalWrite(TL7Red, LOW);
  delay(500);
  digitalWrite(TL7Green, HIGH);
  delay(1000);
  digitalWrite(TL7Green, LOW);
  delay(500);

  digitalWrite(TL8Red, HIGH);
  delay(1000);
  digitalWrite(TL8Red, LOW);
  delay(500);
  digitalWrite(TL8Green, HIGH);
  delay(1000);
  digitalWrite(TL8Green, LOW);
  delay(500);
}
