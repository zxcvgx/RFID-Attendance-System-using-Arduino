# Attendance-System
School Based Attendance System using Arduino Uno R3 and RC522 Module

==============================================================

UPDATE: New controls and features were added to the Console Application!
1. Read Card / Tag option can allow you to read the UID from the RFID Card / Tag.
2. Log Data option allows you to log the date with the provided excel file.
3. Open Logs will open your provided excel file to check and see the changes made.
4. Exit will allow you to exit the application safely.

==============================================================

How does it work?
1. Our Arduino Uno R3 prints the UID of the scanned card.
2. The Console Application then recieves that data and try to search in the third row for the column that has the same UID in your worksheets, after that it then proceeds to write a log entry on the next column, next to the UID

Note: the Name, Section, and UID are already provded in excel.

![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/0199b1e3-e4a9-4ff8-a45c-c218c15f9b51)
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/f692329d-25a2-4335-b640-7cb8a5b7229e)

==============================================================

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




==============================================================

WIRING:

![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/8adb99fb-c6dc-4244-986d-fa38283b9639)



==============================================================

MUST:
1. Don't forget to change the file path where your excel file resides.
2. Don't forget to Download the MFRC522 library in your Aruino IDE
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/e2c55229-8f02-44b8-b115-d2e0fef2cc6d)




