using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace GoblinGen
{
    class CreateNpc
    {
        public static void Main(String[] args)
        {
            //using this main to import my datasets
            //var Skills = new List<SkillScrape>();
            //var StartPath = System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
            //DirectoryInfo d = new DirectoryInfo(StartPath + @"\\JsonSkills\\");
            //string stmt = "INSERT INTO dbo.Skills(SkillName, SkillAttribute, TrainedOnly, ArmorCheckPenalty) " +
              //  "VALUES(@SkillName, @SkillAttribute, @TrainedOnly, @ArmorCheckPenalty )";
            //string conString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = C:\\Users\\trae.cooper\\source\\repos\\GoblinGen\\GoblinGen\\Skills.mdf; Integrated Security = True";
            //SqlConnection con = new SqlConnection(conString);

            //try 
            //{
            //    con.Open();
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.ToString());
            //}

            //SqlCommand cmd = new SqlCommand(stmt, con);
            //cmd.Parameters.Add("@SkillName", SqlDbType.VarChar, 50);
            //cmd.Parameters.Add("@SkillAttribute", SqlDbType.VarChar, 50);
            //cmd.Parameters.Add("@TrainedOnly", SqlDbType.Bit);
            //cmd.Parameters.Add("@ArmorCheckPenalty", SqlDbType.Bit);

           // foreach (var file in d.GetFiles("*.json"))
            //{
                //using (StreamReader r = File.OpenText(file.FullName))
                //{
                    //String json = r.ReadToEnd();
                    //SkillScrape TempSkillScrape = JsonConvert.DeserializeObject<SkillScrape>(json);
                    //Skills.Add(TempSkillScrape);
                //}
            //}

            //foreach (var skill in Skills)
            //{
                //cmd.Parameters["@SkillName"].Value = skill.name;
                //cmd.Parameters["@SkillAttribute"].Value = skill.attribute;
                //cmd.Parameters["@TrainedOnly"].Value = skill.trained_only;
                //cmd.Parameters["@ArmorCheckPenalty"].Value = skill.armor_check_penalty;

                //cmd.ExecuteNonQuery();
            //}
            //SkillScrape TestSkill = LoadJson();

            //Console.WriteLine(TestSkill);
            Console.ReadLine();
        }

        //public static SkillScrape LoadJson(String s)
        //{
        //    using (StreamReader r = new StreamReader("JsonSkills\\acrobatics.json"))
        //    {
        //        string json = r.ReadToEnd();
        //        SkillScrape SkillRead = JsonConvert.DeserializeObject<SkillScrape>(json);
        //        return SkillRead;
        //    }
            

        //}
    }

    //class SkillScrape 
    //{
    //    public String type { get; set; }
    //    public String name { get; set; }
    //    public String url { get; set; }
    //    public String attribute { get; set; }
    //    public String source { get; set; }
    //    public bool trained_only { get; set; }
    //    public bool armor_check_penalty { get; set; }

    //    public override string ToString()
    //    {
    //        String s = this.type + " " + this.name + " " + this.attribute + " " + this.trained_only;
    //        return s;
    //    }

    }

    
