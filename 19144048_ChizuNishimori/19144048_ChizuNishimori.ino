//傾きを計測する
#include <ADXL345.h> 
ADXL345 adxl;

//圧力を計測
float val = 0;

//タッチを検出する、信号のピンはD2に接続する
int TouchPin = 2;

int lastTouchingState = 0;
int count = 0;
int touchingNum = -1;

#define LED_PIN 13 //LEDのピン番号。13は内蔵LED。
char data;

void setup() {
  Serial.begin(115200);
  adxl.powerOn();

  pinMode(LED_PIN, OUTPUT);
}
 
void loop() {
  int sensorValue = digitalRead(TouchPin);

  int x, y, z;
  int a;
  adxl.readXYZ(&x, &y, &z);
  a = atan2(x, z) / 3.14 * 180.0 ;
  //Serial.print("x=") ;
  Serial.print(a);
  Serial.print(",");//X軸方向角度表示
  
  //Serial.print("y=") ;
  a = atan2(y, z) / 3.14 * 180.0 ;
  Serial.print(a);
  Serial.print(",");//Y軸方向角度表示

  val = analogRead(0);
  Serial.print(val);//圧力
  Serial.print(",");


if (sensorValue != lastTouchingState)
  {
    count ++;
  }

  if (count > 0 && count % 2 == 1) //タッチしている
  {
    touchingNum = count / 2;
    Serial.print("touching");
  }
  else if (count > 0 && count % 2 == 0) //離れている
  {
    Serial.print("leaving");
  }
  else
  {
    Serial.print("No Touching"); //初期状態
  }
  lastTouchingState = sensorValue;
  Serial.println(",");//
  
  delay(50);

  //受信
  if ( Serial.available()  > 0 )
  {   // 受信データがあるか？
    data = Serial.read();            // 1文字だけ読み込む
    if (data == 0x31) { //文字コード0x31、つまり"1"を受信したらLEDを光らせる。
      digitalWrite(LED_PIN, HIGH);
      delay(500);
      digitalWrite(LED_PIN, LOW);
    }
  }
}
