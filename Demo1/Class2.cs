using GlobalKeyLogger;
using System;
using System.IO;

namespace Demo1
{
    internal class Program2
    {
        public static void Main2()
        {
            // Specify the path where you want to save the file
            string folderPath = @"D:\logs";
            string filePath = Path.Combine(folderPath, "KeyPressLog.txt");

            // Create the directory if it doesn't exist
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            Console.WriteLine("Press any key to start recording. Press 'Esc' to stop.");

            using (StreamWriter writer = new StreamWriter(filePath, true)) // Append to the file
            {
                while (true)
                {
                    var keyInfo = Console.ReadKey(true); // true to intercept the key (no output)
                    if (keyInfo.Key == ConsoleKey.Escape) // Break the loop on 'Esc' key
                    {
                        break;
                    }
                    OnKeyPressed(writer, keyInfo); // Pass the writer to the method
                }
            }

            Console.WriteLine("Key logging stopped. Press any key to exit.");
            Console.ReadKey();
        }

        public static void OnKeyPressed(StreamWriter writer, ConsoleKeyInfo keyInfo)
        {
            string logEntry = $"{DateTime.Now}: Key Pressed: {keyInfo.KeyChar}"; // Log character pressed
            Console.WriteLine(logEntry);
            writer.WriteLine(logEntry); // Write to the log file
        }
    }
}
