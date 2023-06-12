using System;
using System.IO;
using System.IO.Ports;
using System.Linq;
using OfficeOpenXml;

namespace AECA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Arduino To Excel Communication App (AECA)";
            // Set up the serial port to communicate with Arduino
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            SerialPort serialPort = new SerialPort("COM6", 9600);
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();

            Console.WriteLine("Waiting for data from Arduino...");

            Console.ReadLine();
            serialPort.Close();
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read the data received from Arduino
            SerialPort serialPort = (SerialPort)sender;
            string receivedData = serialPort.ReadLine();

            // Find the row and column in Excel with the received UID
            string uidToFind = receivedData.Trim();
	    //Make sure to add the UID to the 3rd column
            string excelFilePath = @"C:\Users\JeanC\source\repos\Arduino To Excel Communication\bin\Release\Book1.xlsx";

            using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
            {
                foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                {
                    ExcelRangeBase range = worksheet.Cells[worksheet.Dimension.Address];
                    ExcelRangeBase uidCell = range.FirstOrDefault(cell => cell.Value != null && cell.Value.ToString() == uidToFind);

                    if (uidCell != null)
                    {
                        // Get the row number of the found UID cell
                        int rowToWriteIndex = uidCell.Start.Row;

                        // Write the current date and time next to the found column
                        int columnToWriteIndex = uidCell.Start.Column + 1;  // write in the next column

                        ExcelRangeBase cellToWrite = worksheet.Cells[rowToWriteIndex, columnToWriteIndex];

                        // Get the current date and time in the desired format
                        string currentDate = DateTime.Now.ToString("dddd, MMMM d, yyyy - h:mm tt");

                        cellToWrite.Value = currentDate;

                        // Retrieve the data in the row and print it
                        object[] rowData = worksheet.Cells[rowToWriteIndex, 1, rowToWriteIndex, worksheet.Dimension.Columns].Select(cell => cell.Value).ToArray();
                        string rowDataString = string.Join(" | ", rowData);

                        // Print the data in the row along with the date and time
                        Console.WriteLine($"\nData written successfully \n{rowDataString}");
                    }
                }

                // Save the changes to the Excel file
                package.Save();
            }
        }
    }
}
