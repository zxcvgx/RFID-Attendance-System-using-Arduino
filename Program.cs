using System;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using OfficeOpenXml;

namespace AECA
{
    class Program
    {
        private static int users_option = 0;
        private static string excelFilePath = @"";

        public static void Main(string[] args)
        {
            Console.Title = "Arduino To Excel Communication App (AECA)   |   MENU";

            // Check if a file was dragged and dropped
            if (args.Length > 0)
            {
                excelFilePath = args[0];
            }

            // Set up the serial port to communicate with Arduino
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            SerialPort serialPort = new SerialPort("COM6", 9600);
            serialPort.DataReceived += SerialPort_DataReceived;

            bool exitProgram = false;

            while (!exitProgram)
            {
                Console.Clear();
                Console.Title = "Arduino To Excel Communication App (AECA)   |   MENU";
                Console.WriteLine(" \n MENU");
                Console.WriteLine(" (1) Read Card / Tag UID");
                Console.WriteLine(" (2) Log Data");
                Console.WriteLine(" (3) Open Logs");
                Console.WriteLine(" (4) Exit");

                var option = Console.ReadKey().KeyChar.ToString();
                Console.Clear();

                switch (option)
                {
                    case "1":
                        Console.Title = "Arduino To Excel Communication App (AECA)   |   MENU >  Read Card/Tag UID";
                        users_option = 1;
                        serialPort.Open();
                        Console.WriteLine(" \n Scan your card!\n");
                        Console.ReadKey();
                        serialPort.Close();
                        break;

                    case "2":
                        Console.Title = "Arduino To Excel Communication App (AECA)   |   MENU >  Log Data";
                        users_option = 2;
                        serialPort.Open();
                        Console.WriteLine(" \n Scan your card!\n");
                        Console.ReadKey();
                        serialPort.Close();
                        break;

                    case "3":
                        Console.Title = "Arduino To Excel Communication App (AECA)   |   MENU >  Open Logs";
                        Console.WriteLine(" \n Opening Logs!\n");
                        Process.Start(excelFilePath);
                        Console.ReadKey();
                        break;

                    case "4":
                        exitProgram = true;
                        serialPort.Close();
                        break;

                    default:
                        Console.WriteLine(" \n Invalid option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Read the data received from Arduino
            SerialPort serialPort = (SerialPort)sender;
            string receivedData = serialPort.ReadLine();

            // Find the row and column in Excel with the received UID
            string uid = receivedData.Trim();

            if (users_option == 1)
            {
                Console.WriteLine(" UID: " + uid);
                System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                player.SoundLocation = @"C:\Users\JeanC\Music\achive-sound-132273.wav";
                player.Play();
                player.Dispose();
            }
            else if (users_option == 2)
            {
                using (ExcelPackage package = new ExcelPackage(new FileInfo(excelFilePath)))
                {
                    foreach (ExcelWorksheet worksheet in package.Workbook.Worksheets)
                    {
                        ExcelRangeBase range = worksheet.Cells[worksheet.Dimension.Address];
                        ExcelRangeBase uidCell = range.FirstOrDefault(cell => cell.Value != null && cell.Value.ToString() == uid);

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
                            Console.WriteLine($"\n Data logged and written successfully! \n {rowDataString}");
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                            player.SoundLocation = @"C:\Users\JeanC\Music\achive-sound-132273.wav";
                            player.Play();
                            player.Dispose();
                        }
                    }

                    // Save the changes to the Excel file
                    package.Save();
                }
            }
        }
    }
}
