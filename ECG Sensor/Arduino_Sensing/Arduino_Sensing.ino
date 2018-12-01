void setup() {
  // put your setup code hconst int heartPin = A1;
void setup() {
   Serial.begin(4800);
 }
 void loop() { 
 int heartValue = analogRead(heartPin);
//Serial.print(100);  // To freeze the lower limit
//Serial.print(" ");
//Serial.print(600);  // To freeze the upper limit
//Serial.print(" ");
//Serial.print(340);  // To freeze the upper limit
//Serial.print(" ");
 Serial.println(heartValue);
 delay(5);
 }

 ere, to run once:

}

void loop() {
  // put your main code here, to run repeatedly:

}
