#include<SPIFlash.h>
#include<SPI.h>

const int ndata = 64;
long data[ndata];

uint16_t page1 = 0;

SPIFlash flash(9);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);
  while (!Serial) ;
  flash.begin();

}

void loop() {
  // put your main code here, to run repeatedly:

  long timeStart = millis();
  for(int i;i<ndata;i++)
  {
    data[i]=i*100;
//    if (flash.writeLong(page1, 4*i, data[i]))
//      Serial.print (".");
//    else
//      Serial.print ("x");
    flash.writeLong(page1, 4*i, data[i],NOERRCHK);
  }
  long duration = millis() - timeStart;
  Serial.println(duration);

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
    Serial.print("-");
  }
  Serial.println("Continue");
  delay(1000);
}
