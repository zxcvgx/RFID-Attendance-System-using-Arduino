# Attendance-System
School Based Attendance System using Arduino Uno R3 and RC522 Module

MATERIALS NEEDED:

![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/94df25f1-5d02-459e-b4af-ec87d99ab6e3)

1. Arduino Uno USB Connector
2. Arduino Uno R3
3. RFID-RC522 Module
4. Multicolored Male to Male Jumpers
5. Breadboard
6. Soldering Pen
7. Solder Wire
8. Computer
9. RFID Card / MIFARE Classic 1K Card
10. RFID Tag



WIRING:

![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/8adb99fb-c6dc-4244-986d-fa38283b9639)

MUST:
1. Don't forget to change the file path where your excel file resides.
2. Don't forget to Download the MFRC522 library in your Aruino IDE
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/e2c55229-8f02-44b8-b115-d2e0fef2cc6d)

How does it work?
1. Our Arduino Uno R3 prints the UID of the scanned card.
2. The Console Application then recieves that data and try to search in the third row for the column that has the same UID in your worksheets, after that it then proceeds to write a log entry on the next column, next to the UID

Note: the Name, Section, and UID are already provdied in excel.
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/c7d770f0-1469-4b55-a247-7361982c13bf)

![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/d81590fd-d44b-41ea-a177-5eba538735df)


