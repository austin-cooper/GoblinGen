using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GoblinGen
{
    internal static class ImportDataAndStore
    {

        public static void ImportAndStore(string directory, string connectionString,
            string dbStatement, Type type)
        {
            IEnumerable<String> enumerable = ImportJSON(directory);
            WriteToDB(connectionString, dbStatement, enumerable, type);
        }


        //helper method that uses reflection, the JSON.net reference to read in a JSON file
        //from a passed in directory, to convert that stream into a string and store it
        // in a collection IEnumberable<string> for later use
        private static IEnumerable<string> ImportJSON(string directory)
        {
            //var ImportObject =  Activator.CreateInstance(type);
            var StartPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            DirectoryInfo d = new DirectoryInfo(StartPath + directory);
            List<String> stringList = new List<String>();


            foreach (var file in d.GetFiles("*.json"))
            {
                using (StreamReader r = File.OpenText(file.FullName))
                {
                    String json = r.ReadToEnd();
                    stringList.Add(json);
                   
                }
            }


            return stringList;
        }

        private static void WriteToDB(string connectionString, string dbStatement, IEnumerable<String> jsonStrings, Type type)
        {

            //tries to create and open a connection to the database
            SqlConnection connection = new SqlConnection(connectionString);


            try
            {
                connection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            //creates an Sqlcommand object for sending INSERT commands later
            SqlCommand command = new SqlCommand(dbStatement, connection);


            //parses each json formatted string into Type type using reflection
            //gets the SQL parameters from the Type using reflection
            foreach (var jsonString in jsonStrings)
            {
                var tempObj = Activator.CreateInstance(type);
                tempObj = Convert.ChangeType(JsonConvert.DeserializeObject(jsonString, type), type);
                

                //check to see if the method exists in Type type
                MethodInfo methodInfo = type.GetMethod("GetSQLParameters");
                if (methodInfo == null)
                {
                    throw new Exception("Method not found");
                }

                //invoke the GetSQLParameters() method from object
                Object o = methodInfo.Invoke(tempObj , null);
                
                //build a parameter for insert for each field in the object
                foreach (var sqlParam in o as IEnumerable<SqlParameter>)
                {
                    command.Parameters.Add(sqlParam);
                    
                }

                command.ExecuteNonQuery();
                command.Parameters.Clear();
            }

            //close open connections
            if (connection != null && connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
    }
}

