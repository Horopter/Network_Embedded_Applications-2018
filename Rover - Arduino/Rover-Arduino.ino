int motor_A_1 = 4;
int motor_A_2 = 5;

int motor_B_1 = 6;
int motor_B_2 = 7;

int motor_C_1 = 8;
int motor_C_2 = 9;

int motor_D_1 = 10;
int motor_D_2 = 11;

int command = 'N';

const int trigPin1 = 12;
const int echoPin1 = 13;
const int trigPin2 = 2;
const int echoPin2 = 3;

long t1,t2;
int d1,d2;

void setup() {
    Serial.begin(9600);
    // Set the pin modes of the above IO pins to OUTPUT
    pinMode(motor_A_1, OUTPUT);
    pinMode(motor_A_2, OUTPUT);
    pinMode(motor_B_1, OUTPUT);
    pinMode(motor_B_2, OUTPUT);
    pinMode(motor_C_1, OUTPUT);
    pinMode(motor_C_2, OUTPUT);
    pinMode(motor_D_1, OUTPUT);
    pinMode(motor_D_2, OUTPUT);
    pinMode(trigPin1, OUTPUT);
    pinMode(echoPin1, INPUT);
    pinMode(trigPin2, OUTPUT);
    pinMode(echoPin2, INPUT);
    
}
void loop() {

    if(Serial.available())
    {
      int val = Serial.read();
      //String s = "Val : "+String(val); 
      //Serial.println(s);
      if(val!=command)
      {
        command = val;
      }
      
      Serial.println("Available");
    }
    
    digitalWrite(trigPin1, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin1, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin1, LOW);
    t1 = pulseIn(echoPin1, HIGH);
    d1= t1*0.034/2;

    digitalWrite(trigPin2, LOW);
    delayMicroseconds(2);
    digitalWrite(trigPin2, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin2, LOW);
    t2 = pulseIn(echoPin2, HIGH);
    d2= t2*0.034/2;

//    String s1 = String(d1);
//    String s2 = String(d2);
//    Serial.println(s1+","+s2);
    
  if(command == 76 && d1>20)
    {
      digitalWrite(motor_A_1, LOW);
      digitalWrite(motor_A_2, HIGH);
      digitalWrite(motor_B_1, LOW);
      digitalWrite(motor_B_2, HIGH);
      digitalWrite(motor_C_1, LOW);
      digitalWrite(motor_C_2, HIGH);
      digitalWrite(motor_D_1, LOW);
      digitalWrite(motor_D_2, HIGH);
      delay(200);
    }
    else if(command == 82 && d2>20)
    {
      digitalWrite(motor_A_2, LOW);
      digitalWrite(motor_A_1, HIGH);
      digitalWrite(motor_B_2, LOW);
      digitalWrite(motor_B_1, HIGH);
      digitalWrite(motor_C_2, LOW);
      digitalWrite(motor_C_1, HIGH);
      digitalWrite(motor_D_2, LOW);
      digitalWrite(motor_D_1, HIGH);
      delay(200);
    }
    else
    {
      digitalWrite(motor_A_1, LOW);
      digitalWrite(motor_A_2, LOW);
      digitalWrite(motor_B_1, LOW);
      digitalWrite(motor_B_2, LOW);
      digitalWrite(motor_C_1, LOW);
      digitalWrite(motor_C_2, LOW);
      digitalWrite(motor_D_1, LOW);
      digitalWrite(motor_D_2, LOW);
    }
    digitalWrite(motor_A_1, LOW);
    digitalWrite(motor_A_2, LOW);
    digitalWrite(motor_B_1, LOW);
    digitalWrite(motor_B_2, LOW);
    digitalWrite(motor_C_1, LOW);
    digitalWrite(motor_C_2, LOW);
    digitalWrite(motor_D_1, LOW);
    digitalWrite(motor_D_2, LOW);
    command = 'N';
 }
    
