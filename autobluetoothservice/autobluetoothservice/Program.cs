using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace autobluetoothservice
{
    static class Program
    {
        /// <summary>
        /// Check Bluetooth device is nearby and Change to lock screen service.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new CheckBTD()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
