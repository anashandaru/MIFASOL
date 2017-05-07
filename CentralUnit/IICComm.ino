void measureSimul()
{
  Wire.flush();
	Wire.beginTransmission(0); // broadcast to all modular unit
	Wire.write(highByte(ndata));
	Wire.write(lowByte(ndata));
	byte err = Wire.endTransmission(); // non-zero means error
}

void clearMemory()
{
  Wire.flush();
  Wire.beginTransmission(0); // broadcast to all modular unit
  Wire.write(highByte(ndata));
  byte err = Wire.endTransmission(); // non-zero means error
}

void requestDataFrom(byte slaveAddress)
{
  wireFlush();
	// loop for every a packet(consist of 8 samples)
	for (int i = 0; i < ndata/8; ++i)
	{
		Wire.requestFrom((int) slaveAddress, 4*8);
		while(Wire.available())
		{
			long packet[8];
			// loop for every samples in a packet
			for (int i = 0; i < 8; ++i)
			{
				byte dataBytes[4]; // long consist of 4 byte
				Wire.readBytes((byte *) &dataBytes, 4); // fill every element in data byte
				packet[i] = byte2long(dataBytes); // Convert 4 sized byte array to single long value
//				long data = byte2long(dataBytes);
//				Serial.println(data); // print every data
			}
			SendDataPacket(slaveAddress, packet); // Send packet over SerialComm to desktop apps
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

bool testAddress(uint8_t address)
{
	Wire.beginTransmission (address);
    if (Wire.endTransmission () == 0)
    	return true;
    else
    	return false;
}
