using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using AutoBlue.ProcessExtensions;
using System.IO;

namespace autobluetoothservice
{

    public partial class CheckBTD : ServiceBase //Not all iDisposable members are properly disposed. Call Dispose when disposing CheckBTD
    {
        private Timer timer = null;
        private string[] str = null;
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
        public CheckBTD()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer = new Timer();
            str = new string[3];    //str[0] = password, str[1] = 
            this.timer.Interval = 15000; //every 15 secs
            this.timer.Elapsed += new System.Timers.ElapsedEventHandler(this.BluetoothCon);
            timer.Enabled = true;
        }

        private void BluetoothCon(object sender, ElapsedEventArgs e)
        {
            BluetoothDeviceInfo[] devices;

            BluetoothClient sdp = new BluetoothClient();

            devices = sdp.DiscoverDevices(255, true, true, false, false);

            try
            {
                using (StreamReader sr = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\confirm.txt", false))
                {

                    int index = 0;

                    while ((str[index] = sr.ReadLine()) != null) 
                    {
                        index++;
                    }
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(ex.Message);
            }

            foreach (BluetoothDeviceInfo deviceInfo in devices)
            {
                if (deviceInfo.DeviceAddress.ToInt64() == Convert.ToInt64(encryptDecrypt(str[1])))//decrypt
                {
                    bool pairResult = BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, null);

                    if (!pairResult)
                    {
                        ProcessExtensions.StartProcessAsCurrentUser(AppDomain.CurrentDomain.BaseDirectory + "\\Lockworkstation.bat");
                    }
                }
               
            }
        }

        protected override void OnStop()
        {
            timer.Enabled = false;
        }
    }
}
