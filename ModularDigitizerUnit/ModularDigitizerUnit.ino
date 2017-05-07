#include <Wire.h>
#include <SPI.h>
#include <ADS1256.h>
#include <SPIFlash.h>

// Wire variables
const byte myAddress = 45;

// ADC variables
const float clockMHz = 7.68;
ADS1256 adc(clockMHz,2.5,true);

// Data Buffer Variables
volatile uint16_t ndata = 240;
long wireBuffer[8];
volatile int stepIndex = 0;

// Flash Memory Variables
const byte flashCs = 5;
SPIFlash flash(flashCs);

void setup() {
    // For debugging purpose
    Serial.begin(115200);
    while (!Serial);

    // I2C setup
    Wire.begin(myAddress); // initialize hardware register
    TWAR = (myAddress << 1) | 1; // enable I2C broadcast to be receive
    Wire.onReceive(receiveEvent); // set up receive handler
    Wire.onRequest(requestEvent); // set up request handler
    
    // ADC (ADS1256) setup
    adc.begin(ADS1256_DRATE_3750SPS,ADS1256_GAIN_1,true);
    adc.setChannel(0,1); // set input channel positive to pin 0 and negative to pin 1
    Serial.println("ADC started");
    
    // Winbond flash memory setup
    flash.begin();
    Serial.println("Flash started");
}


void receiveEvent(int howMany)
{
	switch(howMany)
	{

    case 1:
        Wire.read();
        flash.eraseChip();
        Serial.println("Memory Erased");
      break;
      
		case 2:
        Serial.println("Acquiring Data ...");
        ndata = Wire.read();
        ndata <<= 8;
        ndata |= Wire.read();
        Serial.print("Set npts to ");
        Serial.println(ndata);
  			measure();
  			resetStepIndex();
		  break;
	}

	// throw away any I2C garbage
	wireFlush();
}

void requestEvent()
{
	// Read data packet (consist of 8 samples) from flash memory and fill it in I2C buffer
	Serial.print("Read data from memory - ");
	for (int i = 0; i < 8; ++i)
	{
		wireBuffer[i] = readFlash(i+stepIndex*8);
	}

	// Send data packet in I2C buffer over I2C Wire
	Serial.print("Sending data ");
	Wire.write((byte *) &wireBuffer, 4*8);
  
	// update stepindex for next data packet
	Serial.println(stepIndex);
	updateStepIndex();
}

long readFlash(int dataIndex)
{
	long data;
	uint16_t page = (4*dataIndex)/256;
	uint8_t offset = (4*dataIndex)%256;
	flash.readAnything(page, offset, data);
	return data;
}

void measure()
{
	for (int i = 0; i < ndata; ++i)
	{
		long dataBuffer = sampleAdc(); // do analog digital conversion and sampling the data
		store(i, dataBuffer); // store data buffer to flash memory		
	}
}

long sampleAdc()
{
	SPI.setDataMode(SPI_MODE1);
    adc.waitDRDY();
	long buff = adc.readChannel();
	return buff;
}

void store(int dataIndex, long data)
{
	SPI.setDataMode(SPI_MODE0);
	int page = (4*dataIndex)/256;
	int offset = (4*dataIndex)%256;
	flash.writeLong(page, offset, data, NOERRCHK);
}

void updateStepIndex()
{
	stepIndex++;
	if(stepIndex > (ndata/8 - 1)) 
	{
	  stepIndex = 0;
    Wire.flush();
    wireFlush();
	}
}

void resetStepIndex()
{
	stepIndex = 0;
}

void wireFlush()
{
	while(Wire.available())
		Wire.read();
}

void loop() { }

