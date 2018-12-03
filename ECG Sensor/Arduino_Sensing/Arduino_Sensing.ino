const int heartPin = A1;
unsigned int heartValue = 0;
byte buff[3];

void setup() {
  Serial.begin(4800);
}
 
void loop() { 
  heartValue = analogRead(heartPin);
  buff[1] = (heartValue >> 8) & 255;
  buff[2] = heartValue & 255;
  
  if(buff[1] == 255){
    buff[1] = 254; 
  }
  if(buff[2] == 255){
    buff[2] = 254;
  }
  
  buff[0] = 255;
  Serial.write(buff, sizeof(buff));
  delay(10);
}
