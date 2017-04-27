#include<SPIFlash.h>
#include <ADS1256.h>
#include<SPI.h>

const int ndata = 10000;
long data;

uint16_t page1 = 0;
uint8_t offset = 0;

const byte Drdy = 9;
const byte Cs = 8;
const byte Rst = 7;
const float clockMHz = 7.68;

SPIFlash flash(5);
ADS1256 adc(clockMHz,Drdy,Cs,Rst,2.5);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  while (!Serial) ;

  adc.start(ADS1256_DRATE_7500SPS);
  adc.switchChannel(0,1); 
  flash.begin();
}

void loop() {
  
  long timeStart = millis();
  for(unsigned int i;i<ndata;i++)
  {
    SPI.setDataMode(SPI_MODE1);
    adc.waitDRDY();
    data=adc.readCurrentChannel();

    SPI.setDataMode(SPI_MODE0);
    page1 = (4*i)/256;
    offset = (4*i)%256;
    flash.writeLong(page1, offset, data,NOERRCHK);
  }
  long duration = millis() - timeStart;
  Serial.println((float)ndata/duration*1000);

  Serial.println(" Saved!");

  for(unsigned int i;i<ndata;i++)
  {
    data=0;
  }
  Serial.println("Local values set to 0");

  for(unsigned int i;i<ndata;i++)
  {
    page1 = (4*i)/256;
    offset = (4*i)%256;
    flash.readAnything(page1, offset, data);
    Serial.print(data);
    Serial.print("|");
  }

  flash.eraseChip();
  
  Serial.println("Continue");
  delay(1000);
}
