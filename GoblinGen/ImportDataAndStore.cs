using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace GoblinGen
{
    class ImportDataAndStore
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
        static IEnumerable ImportJSON(Type type, string directory)
        {
            var ImportObject = Activator.CreateInstance(type);
            var StartPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            DirectoryInfo d = new DirectoryInfo(StartPath + directory);
            List<object> objList = new List<object>();


            foreach (var file in d.GetFiles("*.json"))
            {
                using (StreamReader r = File.OpenText(file.FullName))
                {
                    String json = r.ReadToEnd();
                    ImportObject = Convert.ChangeType(JsonConvert.DeserializeObject<Object>(json), type);
                    objList.Add(ImportObject);
                }
            }


            return objList;
        }

        static void WriteToDB(string connectionString, string dbStatement, IEnumerable data, Type type)
        {
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
                tempObj = Convert.ChangeType(dataObj, type);
                //check to see if the method exists in Type type
                var methodInfo = type.GetMethod("GetSQLParameters");
                if (methodInfo == null)
                {
                    //throw some exception
                }

                command.Parameters.Add(methodInfo.Invoke(tempObj, null));
                command.ExecuteNonQuery();
            }
        }
    }
}

