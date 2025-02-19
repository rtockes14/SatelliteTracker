#include <Wire.h>
#include <LiquidCrystal.h>
#include <LiquidCrystal_I2C.h>
#include <Arduino.h>
#include <SPI.h>
#include <ArduinoJson.h>

#define DT  0.02          // Loop time
#define AA  0.97         // complementary filter constant
#define G_GAIN 0.070    // [deg/s/LSB]


#define SCREEN_SIZE 80
#define ROWS 4
#define COLUMNS 20

// Motor 1
#define ENABLE_A 32
#define INPUT_1 27
#define INPUT_2 14

// Motor 2
#define ENABLE_B 26
#define INPUT_3 33
#define INPUT_4 25

int lineCounter = 0;
int colCounter = 0;

// Set the LCD address to 0x27 for a 20 chars and 4 line display
LiquidCrystal_I2C lcd(0x27, 20, 4);

char d1;

int motorASpeed = 0;
int motorBSpeed = 0;

float currentAzimuth = 0;
float currentElevation = 0;

// Satellite info via app
const char *satName;
int satId;
double satElevation;
double satAzimuth;
double satLatitude;
double satLongitude;
const char *date;

char shorterDate[19];

const int minimumSpeed = 50;
const int maxSpeed = 255;

const int maxRotation = 359;

// =======================================================================================================

void rotateLeftThenRight()
{
    digitalWrite(INPUT_1, HIGH);
    digitalWrite(INPUT_2, LOW);
    digitalWrite(INPUT_3, HIGH);
    digitalWrite(INPUT_4, LOW);

    analogWrite(ENABLE_A, 75);
    analogWrite(ENABLE_B, 70);

    delay(4000);

    analogWrite(ENABLE_A, 0);
    analogWrite(ENABLE_B, 0);

    delay(5000);

    digitalWrite(INPUT_1, LOW);
    digitalWrite(INPUT_2, HIGH);
    digitalWrite(INPUT_3, LOW);
    digitalWrite(INPUT_4, HIGH);

    analogWrite(ENABLE_A, 75);
    analogWrite(ENABLE_B, 75);

    delay(2000);

    analogWrite(ENABLE_A, 0);
    analogWrite(ENABLE_B, 0);

    delay(5000);
}

void elevationTest()
{
    digitalWrite(INPUT_3, HIGH);
    digitalWrite(INPUT_4, LOW);
    delay(5000);
    digitalWrite(INPUT_3, LOW);
    digitalWrite(INPUT_4, HIGH);
    delay(5000);
}

void stop()
{
    digitalWrite(INPUT_1, LOW);
    digitalWrite(INPUT_2, LOW);

    digitalWrite(INPUT_3, LOW);
    digitalWrite(INPUT_4, LOW);
}

void parseJson(String jsonData)
{
  Serial.println("Received JSON: " + jsonData);

  // Create a JSON document to parse the incoming data
  JsonDocument doc;

  // Parse the JSON data
  DeserializationError error = deserializeJson(doc, jsonData);

  // Check for parsing errors
  if (error)
  {
    Serial.println("Failed to parse JSON");
    return;
  }

  satName = doc["SatName"];
  satId = doc["SatId"];
  satElevation = doc["SatElevation"];
  satAzimuth = doc["SatAzimuth"];
  satLatitude = doc["SatLatitude"];
  satLongitude = doc["SatLongitude"];
  date = doc["Date"];
  strcpy(shorterDate, date);
  shorterDate[20] = '\0';
}

void lcdPrint()
{
    lcd.clear();
    lcd.setCursor(0, 0);

    lcd.print("SAT: ");
    lcd.setCursor(5, 0);
    lcd.print(satName);
    lcd.setCursor(0, 1);
    lcd.print("ELV:");
    lcd.setCursor(4, 1);
    lcd.print(satElevation);
    lcd.setCursor(11, 1);
    lcd.print("AZI:");
    lcd.setCursor(15, 1);
    lcd.print(satAzimuth);
    lcd.setCursor(0, 2);
    lcd.print("LAT:");
    lcd.setCursor(4, 2);
    lcd.print(satLatitude);
    lcd.setCursor(10, 2);
    lcd.print("LNG:");
    lcd.setCursor(14, 2);
    lcd.print(satLongitude);
    lcd.setCursor(0, 3);
    lcd.print(shorterDate);

}

// Calibrate northern direction

// Calibrate elevation 

// return to home position -- once ele & dir are calibrated

// Parse serial data

// Take serial data and move to position(perhaps next predicted position for leading)
// if next position is less than 10, 5, 2.5 degrees reduce speed to minimum position

void trackToCurrentPOS(float heading, float currentAzimuth, float currentElevation)
{

}


// =======================================================================================================

void setup()
{
    pinMode(ENABLE_A, OUTPUT);
    pinMode(ENABLE_B, OUTPUT);
    pinMode(INPUT_1, OUTPUT);
    pinMode(INPUT_2, OUTPUT);
    pinMode(INPUT_3, OUTPUT);
    pinMode(INPUT_4, OUTPUT);

  Serial.begin(115200);

  lcd.init(21, 22);
  lcd.backlight();

  lcd.clear();
  lcd.setCursor(0, 0);
  lcd.print("  SAT TRACKER v1.0");
  delay(500);
  lcd.setCursor(0, 1);
  lcd.print("====================");
  lcd.setCursor(0, 2);
  lcd.print(" START APPLICATION");
  lcd.setCursor(0, 3);
  lcd.print(" TO BEGIN TRACKING->");

  delay(2000);

  detectIMU();
  lcd.print("Detected IMU");
  //enableIMU();
  lcd.setCursor(0,0);
  lcd.print("Made it past you know what");
  delay(2000);

}

void loop(void)
{
  startTime = millis();

  //rotateLeftThenRight();
  //stop();
  //elevationTest();

  if (Serial.available())
  {

    String jsonData = Serial.readString();

    parseJson(jsonData);

    //lcdPrint();
    
  }
  lcd.clear();

  
  //trackToCurrentPOS(heading, currentAzimuth, currentElevation);
 lcd.setCursor(0,0);
 lcd.print(heading);
 delay(500);

}