// Written by Nick Gammon
// February 2011

#include <Wire.h>

const byte MY_ADDRESS = 25;      // me
const byte SLAVE1 = 45;   // slave one
const byte SLAVE2 = 35;   // slave one
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
  measureSimultaneously();
      
  delay (1000);  // wait 7 seconds
  i2cFlush();
  requestDataFrom(SLAVE1);
  printData();
  dataFlush();
//  i2cFlush();
//  requestDataFrom(SLAVE2);
//  printData();
//  dataFlush();

  delay(1000);
}   // end of loop

void measureSimultaneously()
{
  unsigned int value = 1234;  // ie. 0x04 0xD2

  //Serial.println("broadcasting");
  Wire.beginTransmission (0);  // broadcast to all
  Wire.write (highByte (value));   
  Wire.write (lowByte (value)); 
  byte err = Wire.endTransmission  ();  // non-zero means error
  //Serial.println(err);
}

void requestDataFrom(byte slaveAddress)
{
  //Serial.print("Requesting : ");
  //Serial.println(slaveAddress);
  for(int j=0;j<block;j++)
  {
    Wire.requestFrom(slaveAddress,4*ndata);
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
}

void dataFlush()
{
  for(int i=0;i<ndata*block;i++)
  {
    data[i] = 0.0;
  }  
}

void i2cFlush()
{
  while(Wire.available())
  {
    Wire.read();
  }
}

void printData()
{
  for(int i=0;i<ndata*block;i++)
  {
    Serial.println(data[i]);
  }
}

long byte2long(byte bytes[4])
{
  long result;
  result = bytes[3];
  result = (result << 8) | bytes[2];
  result = (result << 8) | bytes[1];
  result = (result << 8) | bytes[0];
  return result; 
}
