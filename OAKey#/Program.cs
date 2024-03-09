using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace OAKey_
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM SoftwareLicensingService");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Console.WriteLine(queryObj.ToString());
                    
                    if (queryObj["OA3xOriginalProductKeyDescription"] != null)
                    {
                        Console.WriteLine("OA3xOriginalProductKeyDescription: {0}", queryObj["OA3xOriginalProductKeyDescription"]);
                    }
                    if (queryObj["OA3xOriginalProductKey"] != null)
                    {
                           Console.WriteLine("OA3xOriginalProductKey: {0}", ( (string) queryObj["OA3xOriginalProductKey"]=="" ?  "NO PRODUCT KEY FOUND": "ORIGINAL KEY FOUND"+ queryObj["OA3xOriginalProductKey"]));    
                    }
                    
                }
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
            }
        }
    }
}
