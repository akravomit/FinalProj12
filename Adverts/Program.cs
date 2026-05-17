using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Adverts
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            AdvertismentDB ADB = new AdvertismentDB();
            while (true)
            {
                Console.ReadLine();
                Console.WriteLine(await ADB.GetRandomAdvertisement());
            }
        }
    }
}
