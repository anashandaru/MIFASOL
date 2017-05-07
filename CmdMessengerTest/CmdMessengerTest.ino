#include <CmdMessenger.h>

CmdMessenger cmdMessenger = CmdMessenger(Serial);

void setup() {
  // put your setup code here, to run once:
  Serial.begin(115200);

  cmdMessenger.printLfCr();

  attachCommandCallbacks();
}

void loop() {
  // put your main code here, to run repeatedly:
  cmdMessenger.feedinSerialData();
}
