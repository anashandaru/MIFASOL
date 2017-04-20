
// Written by Nick Gammon
// February 2011

#include <Wire.h>
#include <ADS1256.h>
#include <SPI.h>

const byte MY_ADDRESS = 45;   // me
const byte LED = 17;          // LED is on pin 13

// ADC variables
const byte DRDY = 9;
const byte CS = 8;
const byte RST = 7;
const float clockMHZ = 7.68;
ADS1256 adc(clockMHZ,DRDY,CS,RST,2.5);

// Data Variables
const int ndata = 8;
const int block = 30;
volatile int index = 0;
long data[block][ndata];
long buff[ndata];

byte ledVal = 0;

void receiveEvent (int howMany)
{
  switch(howMany)
  {
    case 2:
       Serial.println("Acqiring");
       measure();
       //samplingCheck();
       printData();
       digitalWrite (LED, ledVal ^= 1);   // flash the LED
      break;
  }

  // throw away any I2C garbage
  while (Wire.available () > 0) 
    Wire.read ();

}  // end of receiveEvent

void requestEvent()
{
  //Serial.println("Sending");
  Wire.write((byte *) &data[index], 4*ndata);
  updateBlockIndex();
}

void measure()
{
  for(int j=0;j<block;j++)
   {
       for(int i=0;i<ndata;i++)
        {
          adc.waitDRDY();
          data[j][i] = adc.readCurrentChannel();
        }
   }
}

void samplingCheck()
{
  long startTime, duration;
  
  startTime = millis();
  measure();
  duration = millis() - startTime;
  float samplingRate = (ndata*block)/duration;
  Serial.println(duration);
}

void updateBlockIndex()
{
  index++;
  if(index>(block-1))index = 0;
}

void printData()
{
    for(int j=0;j<block;j++)
  {
   // Debuging ADC reading
     for(int i=0;i<ndata;i++)
     {
       //Serial.println(data[j][i]);
     }
  }
}

void long2byte(int32_t bigNum, byte (& bytes) [4])
{
  bytes[0] = (bigNum >> 24) & 0xFF;
  bytes[1] = (bigNum >> 16) & 0xFF;
  bytes[2] = (bigNum >> 8) & 0xFF;
  bytes[3] = bigNum & 0xFF;
}

void setup () 
{
  Serial.begin(9600);
  Wire.begin (MY_ADDRESS);  // initialize hardware registers etc.

  TWAR = (MY_ADDRESS << 1) | 1;  // enable broadcasts to be received

  Wire.onReceive(receiveEvent);  // set up receive handler
  Wire.onRequest(requestEvent);  // set up request handler
  pinMode(LED, OUTPUT);          // for debugging, allow LED to be flashed

  adc.start(ADS1256_DRATE_7500SPS); 
  Serial.println("ADC Started");
  adc.switchChannel(0,1);  // Set MUX Register to AINO and AIN1
  
}// end of setup

void loop () 
  {
  }  // end of loop
