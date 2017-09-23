using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
namespace listbluetoothdevice
{
    class Program
    {
        private static string encryptDecrypt(string input)
        {
            char[] key = { 'E', 'X', 'I', 'T', 'H', 'O' }; //Any chars will work, in an array of any size
            char[] output = new char[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = (char)(input[i] ^ key[i % key.Length]);
            }

            return new string(output);

        }
        static void Main(string[] args)
        {
            BluetoothDeviceInfo[] devices;

            BluetoothClient sdp = new BluetoothClient();

            devices = sdp.DiscoverDevices(255, true, true, false, false);

            Console.WriteLine("Bluetooth Auto Login");
            Console.Write("Please enter the password of this User : ");
            var password = Console.ReadLine();
            Console.WriteLine();

            int i = 1;

            foreach (BluetoothDeviceInfo deviceInfo in devices)
            {
                Console.Write("{0} : ",i);
                Console.WriteLine(deviceInfo.DeviceName);
                i++;                
            }

            Console.Write("Select Device : ");

            int selD = Convert.ToInt32(Console.ReadLine());

            if (selD > devices.Length || selD < 1)
            {
                Console.WriteLine("Input Correct Number");
                Environment.Exit(0);
            }
            
            string encryptedPass = encryptDecrypt(password);
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\confirm.txt", false);
            sw.WriteLine(encryptedPass);
            sw.WriteLine(encryptDecrypt(Convert.ToString(devices[selD - 1].DeviceAddress.ToInt64()))); //Encrypted seID
            sw.Flush();
            sw.Close();
        }
    }
}
