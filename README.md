# Attendance-System
School Based Attendance System using Arduino Uno R3 and RC522 Module

Make sure to create an excel file using Excel and putting the UID on the third row or change the row number 3 to whatever row you desire.

The Excel file should be prepared (created) with the format NAME OF THE STUDENT(1st row)  |  SECTION(2nd row)   | UID(3rd row) | SYSTEM LOG(4th row)

MUST:
Don't forget to change the file path where your excel file resides.
Don't forget to Download the MFRC522 library in your Aruino IDE

How does it work?
1. Our Arduino Uno R3 prints the UID of the scanned card.
2. The Console Application then recieves that data and try to search in the third row for the column that has the same UID in your worksheets, after that it then proceeds to write a log entry on the next column, next to the UID

Note: the Name, Section, and UID are already provdied in excel.
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/d81590fd-d44b-41ea-a177-5eba538735df)
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/8adb99fb-c6dc-4244-986d-fa38283b9639)
![image](https://github.com/zxcvgx/Attendance-System/assets/97776436/94df25f1-5d02-459e-b4af-ec87d99ab6e3)
