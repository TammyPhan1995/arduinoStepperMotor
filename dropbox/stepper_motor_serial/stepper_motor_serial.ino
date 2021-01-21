#include <Stepper.h>      //Stepper motor lib
#include <SPI.h>          //serial lib

const int stepsPerMotorRevolution = 32; //No of steps per internal revolution of motor,
//4-step mode as used in Arduino Stepper library

const int stepsPerOutputRevolution = 32*64; //no of steps per revolution of the output shaft

const int motorpin1 = 8; //Assign motor (ie board) pins to Arduino pins
const int motorpin2 = 9; //
const int motorpin3 = 10; //
const int motorpin4 = 11; //

// initialize the stepper library on pins 8 through 11, Motor rev steps, "Firing" sequence 1-3-2-4,
Stepper myStepper(stepsPerMotorRevolution, motorpin1,motorpin3,motorpin2,motorpin4);

String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

void setup() {
  myStepper.setSpeed(200); //Set the speed
  Serial.begin(9600);
}

void loop() {
  if(stringComplete){
    getCommand();
    stringComplete = false;
    if (commandString.equals("FDOP"))
    {
      myStepper.step(stepsPerOutputRevolution);
      delay(500);
      Serial.println(F("OPENED"));
    }
      if (commandString.equals("FDCL"))
    {
      myStepper.step(-stepsPerOutputRevolution);
      delay(500);
      Serial.println(F("CLOSED"));
    }

    inputString = "";
  }

}


//get message from csharp form
void serialEvent() {
  while (Serial.available()) {
    // get the new byte:
    char inChar = (char)Serial.read();
    // add it to the inputString:
    inputString += inChar;
    // if the incoming character is a newline, set a flag
    // so the main loop can do something about it:
    if (inChar == '\n') {
      stringComplete = true;
    }
  }
}

//get 4 chars from serial message
void getCommand()
{
  if (inputString.length() > 0)
  {
    commandString = inputString.substring(1, 5);
  }
}
