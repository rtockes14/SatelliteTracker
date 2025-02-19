
#include <Arduino.h>
#include <Wire.h>
#include <LiquidCrystal_I2C.h>
#include "MPU9250.h"


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

String data;
char d1;

int motorASpeed = 0;
int motorBSpeed = 0;

int currentAzimuth = 0;
int curentElevation = 0;

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

// =======================================================================================================

void setup()
{
    pinMode(ENABLE_A, OUTPUT);
    pinMode(ENABLE_B, OUTPUT);
    pinMode(INPUT_1, OUTPUT);
    pinMode(INPUT_2, OUTPUT);
    pinMode(INPUT_3, OUTPUT);
    pinMode(INPUT_4, OUTPUT);

  Serial.begin(9600);


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

}

void loop(void)
{
    rotateLeftThenRight();
    //stop();
    //elevationTest();

  if (Serial.available())
  {
    colCounter = 0;
    lineCounter = 0;
    int printed = 0;

    data = Serial.readString();

    lcd.clear();
    lcd.setCursor(0, 0);

    for (int i = 0; i <= 80; i++) // needs to be exact number this is just to fix problem
    {
      // base case
      if (lineCounter == 3 && colCounter == 19)
      {
        break;
      }

      if (data[i] == '%')
      {
        printed += (COLUMNS - colCounter);
        lineCounter++;
        colCounter = 0;
        lcd.setCursor(0, lineCounter);
      }
      else if (data[i] == '$')
      {
        printed = 31;
        colCounter = 11;
        lcd.setCursor(colCounter, lineCounter);
      }
      else if (data[i] == '#')
      {
        colCounter = 10;
        lcd.setCursor(colCounter, lineCounter);
      }
      else if (data[i] == '@')
      {
        printed = 60;
        lcd.setCursor(0, 3);
      }
      else
      {
      lcd.print(data[i]);
      colCounter++;
      lcd.setCursor(colCounter, lineCounter);
      printed++;
      }
    }
    printed = 0;
  }
}