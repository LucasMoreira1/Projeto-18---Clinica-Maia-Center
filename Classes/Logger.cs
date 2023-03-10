using System.Configuration;
using System.IO;
using System;

namespace Projeto_18___Clinica_Maia_Center
{
    public static class Logger
    {


        public static void WriteLog(string path, string message, string nomeLogin)
        {
            //string logPath = ConfigurationManager.AppSettings["logPath"];


            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine($"{DateTime.Now} | {nomeLogin.ToUpper()} | {message.ToUpper()}");
            }
        }

    }
}
