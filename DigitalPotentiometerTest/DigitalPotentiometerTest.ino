const int inc = 6;
const int ud = 4;
const int cs = 10;
int tag = 0;

void setup() {
  // put your setup code here, to run once:
  pinMode(inc, OUTPUT);
  pinMode(ud, OUTPUT);
  pinMode(cs, OUTPUT);

  digitalWrite(cs, HIGH); //Stand by
  digitalWrite(inc, HIGH);
  digitalWrite(ud, HIGH);
  delayMicroseconds(1000); 
  SetPot(20,true);
  SetPot(2,false);
}

void loop() {
  // put your main code here, to run repeatedly:
}
void SetPot(int increment, bool up)
{
  for(int i=0;i<increment;++i)
  {
    ChangePot(up);
  }
}

void ChangePot(bool up)
{
  delayMicroseconds(200);
  digitalWrite(ud, up);
  digitalWrite(cs, LOW);
    
    delayMicroseconds(2);
    digitalWrite(inc, LOW);
    delayMicroseconds(2);

  digitalWrite(inc, HIGH);
  delayMicroseconds(2);
  digitalWrite(cs, HIGH);
}

