#include <arduino.h>

// Motor 1
#define ENABLE_A
#define INPUT_1
#define INPUT_2

// Motor 2
#define ENABLE_B
#define INPUT_3
#define INPUT_4

int motorASpeed = 0;
int motorBSpeed = 0;


void rotateLeftThenRight()
{
    digitalWrite(INPUT_1, HIGH);
    digitalWrite(INPUT_2, LOW);

    digitalWrite(INPUT_3, HIGH);
    digitalWrite(INPUT_4, LOW);

    delay(2000);

    digitalWrite(INPUT_1, LOW);
    digitalWrite(INPUT_2, HIGH);
    
    digitalWrite(INPUT_3, LOW);
    digitalWrite(INPUT_4, HIGH);
}



void setup()
{
    pinMode(ENABLE_A, OUTPUT);
    pinMode(ENABLE_B, OUTPUT);
    pinMode(INPUT_1, OUTPUT);
    pinMODE(INPUT_2, OUTPUT);
    pinMode(INPUT_3, OUTPUT);
    pinMode(INPUT_4, OUTPUT);
}

int main void()
{
    rotateLeftThenRight();
}