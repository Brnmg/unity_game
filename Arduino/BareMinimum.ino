#include <SoftwareSerial.h>

SoftwareSerial bluetooth(10, 11); //RX, TX
int inputBluetooth;
int device = A1;

int X;
int Y;
float TIME = 0;
float FREQUENCY = 0;
float WATER = 0;
float TOTAL = 0;
float LS = 0;
const int input = A0;
void setup()
{
  Serial.begin(9600);

  delay(2000);
  pinMode(input, INPUT);

  bluetooth.begin(9600); 
  pinMode(device, INPUT);
}
void loop()
{
  X = pulseIn(input, HIGH);
  Y = pulseIn(input, LOW);
  TIME = X + Y;
  FREQUENCY = 1000000 / TIME;
  WATER = FREQUENCY / 7.5;
  LS = WATER / 60;
  if (FREQUENCY >= 0)
  {
    if (isinf(FREQUENCY))
    {

      Serial.println("VOL. :0.00");
      Serial.print("|TOTAL:");
      Serial.print(TOTAL);
      Serial.print(" L");
      LS = 0;
    }
    else
    {
      TOTAL = TOTAL + LS;
      Serial.println(FREQUENCY);

      Serial.print("VOL.: ");
      Serial.print(WATER);
      Serial.print(" L/M");
      Serial.print("|TOTAL:");
      Serial.print(TOTAL);
      Serial.print(" L");
    }
  }

  bluetooth.print(LS);  
  bluetooth.print(";");  
  Serial.println(input);  
  delay(50);
}
