// Written by Nick Gammon
// February 2011

#include <Wire.h>

const byte MY_ADDRESS = 25;      // me
const byte SLAVE_ADDRESS = 45;   // slave
const int ndata = 8;
const int block = 30;
long data[ndata*block];

void setup () 
  {
  Serial.begin(9600);
  Wire.begin (MY_ADDRESS);  // initialize hardware registers etc.
  }  // end of setup

void loop() 
{
  unsigned int value = 1234;  // ie. 0x04 0xD2

  Serial.println("broadcasting");
  Wire.beginTransmission (0);  // broadcast to all
  Wire.write (highByte (value));   
  Wire.write (lowByte (value)); 
  byte err = Wire.endTransmission  ();  // non-zero means error
  Serial.println(err);
      
  delay (1000);  // wait 7 seconds

  Serial.println("Requesting");

  for(int j=0;j<block;j++)
  {
    Wire.requestFrom(45,4*ndata);
    while(Wire.available())
    {
      for(int i=0;i<ndata;i++)
      {
        byte dataBytes[4];
        Wire.readBytes((byte *) &dataBytes, 4);
        data[i+(j*ndata)] = byte2long(dataBytes);
      }
    }    
  }
    

  for(int i=0;i<ndata*block;i++)
  {
    Serial.println(data[i]);
  }

  delay(1000);
}   // end of loop

long byte2long(byte bytes[4])
{
  long result;
  result = bytes[3];
  result = (result << 8) | bytes[2];
  result = (result << 8) | bytes[1];
  result = (result << 8) | bytes[0];
  return result; 
}
