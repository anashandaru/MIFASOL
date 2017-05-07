#include <Wire.h>
#include <CmdMessenger.h>
#include <Adafruit_ADS1015.h>

// Trigger Variables
int triggerThreshold = 0;
Adafruit_ADS1015 ads;

// SerialComm Variables
CmdMessenger cmdMessenger = CmdMessenger(Serial);

// I2CComm Variables
const uint8_t myAddress = 25;
const uint8_t slave1 = 45;

// Measurement Variables
uint16_t ndata = 1000;
const unsigned int samplingRate = 3750;

void setup() {
  // For debugging purposes
  pinMode(13, OUTPUT);
  
  // SerialComm setup
  Serial.begin(115200);

  cmdMessenger.printLfCr();

  attachCommandCallBacks();

  // I2CComm setup
  Wire.begin(myAddress);

  // Trigger setup
  ads.setGain(GAIN_SIXTEEN);
  ads.begin();  
}

void loop() {
  // put your main code here, to run repeatedly:
//	measureSimul();
//	delay(ndata*samplingRate + 500);
//
//	wireFlush();
//	requestDataFrom(slave1);
//	delay(500);
  // Process incoming serial data, and perform callbacks
  cmdMessenger.feedinSerialData(); 
}


