using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Threading;

namespace OAKey_
{
    class Program
    {
        static int Main(string[] args)
        {
            int returnValue = 0;
            Console.WriteLine("");
            Console.WriteLine("Microsoft Windows Original Equipment Manufacturer Key Finder");
            Console.WriteLine("(c) 2024");
            Console.WriteLine("");
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM SoftwareLicensingService");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    
                    /*                   
                    if (queryObj["OA3xOriginalProductKeyDescription"] != null)
                    {
                        Console.WriteLine( 
                            ( (string) queryObj["OA3xOriginalProductKeyDescription"]=="" ? "NO PRODUCT KEY FOUND" : "ORIGINAL PRODUCT DESCRIPTION:"+ queryObj["OA3xOriginalProductKeyDescription"]));
                    }
                    */
                    if (queryObj["OA3xOriginalProductKey"] != null)
                    {
                        if ((string)queryObj["OA3xOriginalProductKey"] != "")
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write( "ORIGINAL WINDOWS ACTIVATION KEY FOUND: {0}", queryObj["OA3xOriginalProductKey"]);
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                            returnValue = 1;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("NO ORIGINAL WINDOWS KEY FOUND IN BIOS");
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    
                }
                Console.WriteLine("\n\nClosing!");
                Thread.Sleep(5000);
                return returnValue;
            }
            catch (ManagementException e)
            {
                if (e.Message == "Not found")
                {
                    Console.WriteLine("No WMI data found.");
                }
                else
                {
                    Console.WriteLine("An error occurred while querying for WMI data: " + e.Message);
                }
                return returnValue;
            }
        }
    }
}
