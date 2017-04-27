#include<SPIFlash.h>
#include <ADS1256.h>
#include<SPI.h>

const int ndata = 64;
long data[ndata];

uint16_t page1 = 0;


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

  adc.start(ADS1256_DRATE_3750SPS);
  adc.switchChannel(0,1); 
  flash.begin();
}

void loop() {
  
  long timeStart = millis();
  for(int i;i<ndata;i++)
  {
    SPI.setDataMode(SPI_MODE1);
    adc.waitDRDY();
    data[i]=adc.readCurrentChannel();

    SPI.setDataMode(SPI_MODE0);
    flash.writeLong(page1, 4*i, data[i],NOERRCHK);
  }
  long duration = millis() - timeStart;
  Serial.println(64000/duration);

  Serial.println(" Saved!");

  for(int i;i<ndata;i++)
  {
    data[i]=0;
  }
  Serial.println("Local values set to 0");

  for(int i;i<ndata;i++)
  {
    flash.readAnything(page1, 4*i, data[i]);
  }
  
  flash.eraseSector(page1, 0);
  
  Serial.println("After reading");
  for(int i;i<ndata;i++)
  {
    Serial.print(data[i]);
    Serial.print("|");
  }
  Serial.println("Continue");
  delay(1000);
}
