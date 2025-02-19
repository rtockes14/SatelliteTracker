
#include <Arduino.h>
#include "MPU9250.h"
#include <LiquidCrystal_I2C.h>
#include <ArduinoJson.h>
#include <cmath>

LiquidCrystal_I2C lcd(0x27,20,4);

MPU9250 mpu;

// Motor 1
#define ENABLE_A 32
#define INPUT_1 27
#define INPUT_2 14

// Motor 2
#define ENABLE_B 26
#define INPUT_3 33
#define INPUT_4 25

unsigned long previousMillis = 0;
const long interval = 500;

long currentHeading = 0;
long currentElevation;

String data;
char d1;

int motorASpeed = 0;
int motorBSpeed = 0;

int currentAzimuth = 0;
int curentElevation = 0;

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
const int maxElevation = 89;
const int minElevation = 0;

bool tiltingUp = false;
bool tiltingDown = false;
bool panningLeft = false;
bool panningRight = false;
bool alreadyTilting = false;
bool alreadyPanning = false;

int desiredElevation = 70; // test elevation for control
int desiredHeading = 280; // test heading for control
int tolerance = 5;

// ===========================================================================================================

void print_roll_pitch_yaw() {
    Serial.print("Yaw, Pitch, Roll: ");
    Serial.print(mpu.getYaw(), 2);
    Serial.print(", ");
    Serial.print(mpu.getPitch(), 2);
    Serial.print(", ");
    Serial.println(mpu.getRoll(), 2);
}

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

float normalize_angle(double angle) {
    angle = fmod(angle, 360.0);  // Wrap angle within [0, 360)
    if (angle < 0) {
        angle += 360.0;  // Ensure it's positive
    }
    if (angle > 180.0) {
        angle -= 360.0;  // Normalize to [-180, 180)
    }
    return angle;
}

float get_shortest_rotation(double current, double target) 
{
    float delta = target - current;
    return normalize_angle(delta);  // Normalize the difference to [-180, 180]
}

void orientationTest()
{
    float x = mpu.getMagX();
    float y = mpu.getMagY();

    float heading = atan2(x, y);
    float declination = -2.6;

    heading += declination;
    heading = heading * 180.0 / PI;

    if (heading < 0)
    {
        heading += 360;
    }

    currentHeading = heading;
    currentElevation = mpu.getRoll();

    // check if desired elevation is greater than current roll angle.  If so set tilting up to true
    if (currentElevation <= (satElevation - tolerance) && currentElevation < maxElevation && alreadyTilting == false)
    {
        tiltingUp = true;
        Serial.print("Begin Tilting UP  ");
        Serial.println(currentElevation);
    }
    if (currentElevation > (satElevation))
    {
        tiltingUp = false;
        Serial.println("Don't Begin Tilting UP");
    }
    // check if desired elevation is less than the current roll angle.  If so set tiling down to true
    if (currentElevation >= (satElevation + tolerance) && currentElevation > minElevation && alreadyTilting == false)
    {
        tiltingDown = true;
        Serial.print("Begin Tilting DOWN  ");
        Serial.println(currentElevation);
    }
    if (currentElevation < (satElevation))
    {
        tiltingDown = false;
        Serial.println("Don't Begin Tilting DOWN");
    }
    // Determine whether difference in azimuth requires left or right pan
    float rotation = get_shortest_rotation(currentAzimuth, desiredHeading);

    if (rotation < 0)
    {
        panningLeft = true;
        Serial.print("Begin Panning LEFT  ");
        Serial.println(currentAzimuth);
    }
    if (rotation > 0)
    {
        panningRight = true;
        Serial.print("Begin Panning RIGHT  ");
        Serial.println(currentAzimuth);
    }
    // Start panning Left if not already panning
    if ((panningLeft) && !(currentAzimuth < desiredHeading) && alreadyPanning == false)
    {
        digitalWrite(INPUT_1, LOW);
        digitalWrite(INPUT_2, HIGH);
        analogWrite(ENABLE_A, 55); // pan
        alreadyTilting = true;
        Serial.println("Currently Tilting UP");
    }
    // Start panning Right if not already panning
    if ((panningRight) && !(currentAzimuth < desiredHeading) && alreadyPanning == false)
    {
        digitalWrite(INPUT_1, HIGH);
        digitalWrite(INPUT_2, LOW);
        analogWrite(ENABLE_A, 55); // pan
        alreadyTilting = true;
        Serial.println("Currently Tilting UP");
    }
    // ===============================================================================================================================

    // if antenna should be tilting up, move motor in ccw direction.  ======== START TILTING UP
    if (tiltingUp == true && alreadyTilting == false)
    {
        digitalWrite(INPUT_3, LOW);
        digitalWrite(INPUT_4, HIGH);
        analogWrite(ENABLE_B, 55); // tilt
        alreadyTilting = true;
        Serial.println("Currently Tilting UP");
    }
   // if antenna should be tilting down, move motor in ccw direction.  ======== START TILTING DOWN
    if (tiltingDown == true && alreadyTilting == false)
    {
        digitalWrite(INPUT_3, HIGH);
        digitalWrite(INPUT_4, LOW);
        analogWrite(ENABLE_B, 55); // tilt
        alreadyTilting = true;
        Serial.println("Currently Tilting DOWN");
    }

    // ===============================================================================================================================

    // if neither up or down movement is needed, turn off motor
    if (tiltingDown == false && tiltingUp == false)
    {
        digitalWrite(INPUT_3, LOW);
        digitalWrite(INPUT_4, LOW);
        analogWrite(ENABLE_B, 0);
        alreadyTilting = false;
        Serial.println(" Quitting tilt condition");
    }
    // if neither left or right movement is needed, turn off motor
    if (panningLeft == false && panningRight == false)
    {
        digitalWrite(INPUT_1, LOW);
        digitalWrite(INPUT_2, LOW);
        analogWrite(ENABLE_A, 0);
        analogWrite(ENABLE_B, 0);
        alreadyPanning = false;
        Serial.println(" Quitting pan condition");
    }
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


void setup() {

    pinMode(ENABLE_A, OUTPUT);
    pinMode(ENABLE_B, OUTPUT);
    pinMode(INPUT_1, OUTPUT);
    pinMode(INPUT_2, OUTPUT);
    pinMode(INPUT_3, OUTPUT);
    pinMode(INPUT_4, OUTPUT);

    Serial.begin(9600);

    lcd.init();
    lcd.backlight();
    Wire.begin();
    delay(2000);

    if (!mpu.setup(0x68)) {  // change to your own address
        while (1) {
            Serial.println("MPU connection failed. Please check your connection with `connection_check` example.");
            delay(5000);
        }
    }

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
}


void loop() 
{

    unsigned long currentMillis = millis(); // get the current time

    if (mpu.update()) {
        static uint32_t prev_ms = millis();
        if (millis() > prev_ms + 25) {
            print_roll_pitch_yaw();
            prev_ms = millis();
        }
    }

    
    
    orientationTest();




    if (currentMillis - previousMillis >= interval) {
        previousMillis = currentMillis;

        float x = mpu.getMagX();
        float y = mpu.getMagY();

        float heading = atan2(x, y);
        float declination = -2.6;

        heading += declination;
        heading = heading * 180.0 / PI;

        if (heading < 0){
            heading += 360;
        }

        lcd.clear();
        lcd.print("Roll: ");
        lcd.print(mpu.getRoll());
        lcd.setCursor(0, 1);
        lcd.print("Pitch: ");
        lcd.print(mpu.getPitch());
        lcd.setCursor(0, 2);
        lcd.print("Mag: ");
        lcd.print(heading);
    }