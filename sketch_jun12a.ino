#include <SPI.h>
#include <MFRC522.h>

#define SS_PIN 10
#define RST_PIN 9

MFRC522 mfrc522(SS_PIN, RST_PIN);

void setup() {
  Serial.begin(9600);
  SPI.begin();
  mfrc522.PCD_Init();
}

void loop() {
  // Reset the loop if no new card present on the sensor/reader. This saves the entire process when idle.
  if (!mfrc522.PICC_IsNewCardPresent())
    return;

  // Select one of the cards
  if (!mfrc522.PICC_ReadCardSerial())
    return;

  // Show some details of the PICC (that is: the tag/card)
  
  dump_byte_array_lowercase_nospaces(mfrc522.uid.uidByte, mfrc522.uid.size);
  // Send the UID to the console application
  Serial.println();
   delay(1100);
}

void dump_byte_array_lowercase_nospaces(byte *buffer, byte bufferSize) {
  for (byte i = 0; i < bufferSize; i++) {
    if (buffer[i] < 0x10)
      Serial.print("0");
    Serial.print(String(buffer[i], HEX));
  }
}
