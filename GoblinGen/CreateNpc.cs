using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace GoblinGen
{
    class CreateNpc
    {
        public static void Main(String[] args) => ImportDataAndStore.ImportAndStore("\\skill",
                "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\trae.cooper\\source\\repos\\GoblinGen"
                + "\\GoblinGen\\PFDataStore.mdf; Integrated Security = True; Connect Timeout = 30",
                "INSERT INTO dbo.Skills(SkillName, SkillAttribute, TrainedOnly, ArmorCheckPenalty) " +
                "VALUES(@SkillName, @SkillAttribute, @TrainedOnly, @ArmorCheckPenalty )", typeof(Skill));



      

    }

    
    



}
