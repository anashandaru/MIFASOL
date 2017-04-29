#include <Wire.h>

const uint8_t myAddress = 25;
const uint8_t slave1 = 45;
const unsigned int ndata = 10000;
const unsigned int samplingRate = 3750;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  Wire.begin(myAddress);
}

void loop() {
  // put your main code here, to run repeatedly:
	measureSimul();
	delay(ndata*samplingRate + 500);

	wireFlush();
	requestDataFrom(slave1);
	delay(500);
}

void measureSimul()
{
	Wire.beginTransmission(0); // broadcast to all modular unit
	Wire.write(highByte(ndata));
	Wire.write(lowByte(ndata));
	byte err = Wire.endTransmission(); // non-zero means error
}

void requestDataFrom(byte slaveAddress)
{
	// loop for every a packet(consist of 8 samples)
	for (int i = 0; i < ndata/8; ++i)
	{
		Wire.requestFrom(slaveAddress, 4*8);
		while(Wire.available())
		{
			// loop for every samples in a packet
			for (int i = 0; i < 8; ++i)
			{
				byte dataBytes[4]; // long consist of 4 byte
				Wire.readBytes((byte *) &dataBytes, 4); // fill every element in data byte
				long data = byte2long(dataBytes); // Convert 4 sized byte array to single long value
				Serial.println(data); // print every data
			}	
		}
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

void wireFlush()
{
	while(Wire.available())
		Wire.read();
}
