using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

namespace GoblinGen
{
    class CreateNpc
    {
        public static void Main(String[] args)
        {
            Feat featTest;
            ////Import Skills
            //ImportDataAndStore.ImportAndStore("\\skill",
            //    "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\trae.cooper\\source\\repos\\GoblinGen"
            //    + "\\GoblinGen\\PFDataStore.mdf; Integrated Security = True; Connect Timeout = 30",
            //    "INSERT INTO dbo.Skills(SkillName, SkillAttribute, TrainedOnly, ArmorCheckPenalty, URL, Type, Source) " +
            //    "VALUES(@SkillName, @SkillAttribute, @TrainedOnly, @ArmorCheckPenalty, @URL, @Type, @Source )", typeof(Skill));

            using (StreamReader r = new StreamReader("C:\\Program Files (x86)\\Sources\\repos\\PSRD-Data\\core_rulebook\\feat\\deadly_aim.json"))
           {
                string json = r.ReadToEnd();
                featTest =  JsonConvert.DeserializeObject<Feat>(json);

            }


        }
    }

    
    



}
