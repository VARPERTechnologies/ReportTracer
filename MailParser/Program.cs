using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.IO;
using MimeKit.Text;
using Newtonsoft.Json;
using System.Diagnostics;
using MySql.Data.MySqlClient;

//using EAGetMail;

namespace MailParser
{
    class Program
    {

        static void Main(string[] args)
        {
            int arguments = args.Length;

            string
                strFileContent = "",
                argument = "",
                leftOperand = "",
                rightOperand = "",
                strDirectory = "",
                strServer = "",
                strPort = "",
                strDB = "",
                strUser = "",
                strPass = "",
                strTable = "";

            string[] files = new string[] { };

            //Firs read, list and normalize all arguments
            for (int i = 0; i < arguments; i++)
            {
                if(args[i].StartsWith("--"))
                {
                    argument = args[i].Remove(0, 2);

                    leftOperand = argument.Split(new char[] { '=' })[0].ToLower();
                    rightOperand = argument.Split(new char[] { '=' })[1];
                    
                    if(leftOperand == "path")
                    {
                        strDirectory = rightOperand;
                    }
                    else if(leftOperand == "host")
                    {
                        strServer = rightOperand;
                    }
                    else if (leftOperand == "port")
                    {
                        strPort = rightOperand;
                    }
                    else if (leftOperand == "db")
                    {
                        strDB = rightOperand;
                    }
                    else if (leftOperand == "user")
                    {
                        strUser = rightOperand;
                    }
                    else if (leftOperand == "password")
                    {
                        strPass = rightOperand;
                    }
                    else if (leftOperand == "table")
                    {
                        strTable = rightOperand;
                    }
                    else
                    {
                        LogError("Invalid argument: " + leftOperand);
                        return;
                    }
                }
            }
            
            //Check the correct argument settings. 
            if(strDirectory == "")
            {
                System.Console.Error.WriteLine("The directory to scan is empty. Specify a directory to scan"); 
                return;
            }
            
            if(strServer == "")
            {
                System.Console.Error.WriteLine("You must specify a host to connect to");
                return;
            }

            if (strPort == "")
            {
                System.Console.Error.WriteLine("You must specify a port to openo");
                return;
            }

            if (strDB == "")
            {
                System.Console.Error.WriteLine("You must specify a db to connect to");
                return;
            }

            if (strUser == "")
            {
                System.Console.Error.WriteLine("You must specify a valid user to connect the database");
                return;
            }

            if (strPass == "")
            {
                System.Console.Error.WriteLine("You must specify a user password");
                return;
            }

            if (strTable == "")
            {
                System.Console.Error.WriteLine("You must specify a table in the database");
                return;
            }
                       
            //Read all files in the specified directory
            try
            {
                files = Directory.GetFiles(strDirectory);
                if (files.Length == 0) return; //If no files just exit
            }
            catch(Exception e)
            {
                LogError(e);
                return;
            }

            TracertDemo.JSONReport report;

            string
                connectionString = "SERVER=" + strServer + ";PORT=" + strPort + ";" + "DATABASE=" + strDB + ";" + "UID=" + strUser + ";" + "PASSWORD=" + strPass + ";",
                strQuery;

            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch(Exception e)
            {
                LogError(e);
                return;
            }

            foreach(string file in files)
            {
                string ext = Path.GetExtension(file);

                if(ext == ".eml")
                {
                    strFileContent = System.IO.File.ReadAllText(file);
                    MimeKit.MimeParser mp = new MimeKit.MimeParser(StringToStream(strFileContent), MimeKit.MimeFormat.Default);
                    MimeKit.MimeMessage mm = mp.ParseMessage();

                    string
                        subject = mm.Subject,
                        body = mm.TextBody;

                    try
                    {
                        string
                            backupDir = strDirectory + "\\backup",
                            fileName = Path.GetFileName(file);

                        report = JsonConvert.DeserializeObject<TracertDemo.JSONReport>(body); //With this we can validate if email's body is a JSON object. If not it throws a exception. 
                        strQuery = "insert into " + strTable + " values (null, 0,'" + report.ORIdentifier + "', now(), '" + JsonConvert.SerializeObject(report) + "', '" + file.Replace("\\", "\\\\") + "');";

                        MySqlCommand myCommand = new MySqlCommand(strQuery, connection);

                        myCommand.ExecuteNonQuery();
                        
                        if (!Directory.Exists(backupDir))
                        {
                            Directory.CreateDirectory(backupDir);
                        }
                        File.Move(file, backupDir + "\\" + fileName);
                    }
                    catch (Exception e)
                    {
                        LogError(e);
                    }
                }
            }
        }
        
        /// <summary>
        /// Converts a string to a stream.
        /// </summary>
        /// <param name="s">The string to convert</param>
        /// <returns>The Stream equivalent object.</returns>
        public static Stream StringToStream(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        /// <summary>
        /// Log errors in all possible outputs. 
        /// This means the error stream, the common console and debug console if Debugging.
        /// </summary>
        /// <param name="e">The exception to log.</param>
        private static void LogError(Exception e)
        {
            string logFile = "";
            //Try to create a log file to report the errors.
            try
            {
                logFile = Directory.GetCurrentDirectory() + "\\log.txt";
                if (!File.Exists(logFile))
                {
                    File.Create(logFile);
                }

                File.AppendAllText(logFile, DateTime.Now.ToString() + ":\r\n" + e.Message);
                Console.Error.WriteLine(DateTime.Now.ToString() + ":\r\n" + e.Message);
                Debug.WriteLine(e.Message);
            }
            catch (Exception ex)
            {

                //If can not create the log file the applications must be stopped.
                Console.Error.WriteLine("Can not create the log file: " + logFile);
                Console.Error.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Log string in all possible outputs. 
        /// This means the error stream, the common console and debug console if Debugging, and finally the log file.
        /// </summary>
        /// <param name="e">String to log</param>
        private static void LogError(string e)
        {
            string logFile = "";

            //Try to create a log file to report the errors.
            try
            {
                logFile = Environment.GetEnvironmentVariable("USERPROFILE") + "\\AppData\\Roaming\\MailParser\\log.txt";
                if (!File.Exists(logFile))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(logFile));
                    FileStream fs = File.Create(logFile);
                    fs.Close();
                }

                File.AppendAllText(logFile, "\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Console.WriteLine("\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Console.Error.WriteLine("\r\n" + DateTime.Now.ToString() + ":\r\n" + e);
                Debug.WriteLine(e);
            }
            catch (Exception ex)
            {
                //if (!EventLog.SourceExists("MailParser"))
                //{
                //    //An event log source should not be created and immediately used.
                //    //There is a latency time to enable the source, it should be created
                //    //prior to executing the application that uses the source.
                //    //Execute this sample a second time to use the new source.
                //    EventLog.CreateEventSource("MailParser", "MailParserEventLog");
                //    //Console.WriteLine("CreatedEventSource");
                //    //Console.WriteLine("Exiting, execute the application a second time to use the source.");
                //    // The source is created.  Exit the application to allow it to be registered.
                //    System.Threading.Thread.Sleep(3000);
                //}

                //If can not create the log file the applications must be stopped.
                //EventLog el = new EventLog("MailParserEventLog");

                Console.WriteLine("Can not create the log file: " + logFile);
                Console.Error.WriteLine("Can not create the log file: " + logFile);
                Console.Error.WriteLine(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
