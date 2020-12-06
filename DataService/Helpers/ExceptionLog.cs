using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PointOfSale.DataService.Helpers
{
    public static class ExceptionLog
    {
        public static void Log(Exception ex)
        {
            try
            {
                string filePath = Directory.GetCurrentDirectory() + @"assets/Logs.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                    writer.WriteLine();
                }

            }
            catch (Exception e)
            {
                e.ToString();

            }
        }
    }
}
