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
            IEnumerable enumerable = ImportJSON(type, directory);
            WriteToDB(connectionString, dbStatement, enumerable, type);
        }


        //helper method that uses reflection, the JSON.net reference to read in a JSON file
        //from a passed in directory, to convert that stream into the type of variable type
        //and add it to a List<object> returning the list
        private static IEnumerable ImportJSON(Type type, string directory)
        {
            var ImportObject =  Activator.CreateInstance(type);
            var StartPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            DirectoryInfo d = new DirectoryInfo(StartPath + directory);
            List<object> objList = new List<object>();


            foreach (var file in d.GetFiles("*.json"))
            {
                using (StreamReader r = File.OpenText(file.FullName))
                {
                    String json = r.ReadToEnd();
                    //ImportObject = Convert.ChangeType(JsonConvert.DeserializeObject<Object>(json), type);
                    ImportObject = JsonConvert.DeserializeObject<Object>(json);
                    objList.Add(ImportObject);
                }
            }


            return objList;
        }

        private static void WriteToDB(string connectionString, string dbStatement, IEnumerable data, Type type)
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

            SqlCommand command = new SqlCommand(dbStatement, connection);

            foreach (var dataObj in data)
            {
                var tempObj = Activator.CreateInstance(type);
                //tempObj = dataObj;
                //tempObj = Convert.ChangeType(dataObj, type);
               
                //check to see if the method exists in Type type
                MethodInfo methodInfo = type.GetMethod("GetSQLParameters");
                if (methodInfo == null)
                {
                    //throw some exception
                }

                //IEnumerable<SqlParameter> sqlParameters = new List<SqlParameter>();
                Object o = methodInfo.Invoke(tempObj , null);
               
                //methodInfo.Invoke(tempObj, null)
                foreach (var sqlParam in o as IEnumerable<SqlParameter>)
                {
                    command.Parameters.Add(sqlParam);
                }

                command.ExecuteNonQuery();
            }
        }
    }
}

