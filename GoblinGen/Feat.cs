using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GoblinGen
{

    //***********************************************************************************************************
    // Feat object
    //***********************************************************************************************************

    class Feat
    {

        //fields populated by feat json
        public String name { get; set; }
        public String url { get; set; }
        public JArray sections {get; set;}
        public String source { get; set; }
        public JObject feat_types { get; set; }
        public String type { get; set; }
        public String description { get; set; }

        //fields needed to be derived from sections
        public List<string> prerequisites { get; set; } = new List<string>();
        public IEnumerable<string> benefits { get; set; }
        public IEnumerable<string> normal { get; set; }
        public IEnumerable<string> special { get; set; }
        public IEnumerable<string> featTypeList { get; set; }

        private List<Dictionary<string, string>> SubSections = new List<Dictionary<string, string>>();
        private Dictionary<string, string> SubFeatTypes = new Dictionary<string, string>();
        
        



        //constructor
        public Feat()
        {
            

        }

        internal void InitializeFeat()
        {
            //adding the nested jarray objects to a dictionary for easier access
            foreach(var section in sections)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(JsonConvert.DeserializeObject<Dictionary<string, string>>(section.ToString()));
                SubSections.Add(keyValuePairs);
                foreach(var kvp in keyValuePairs)
                {
                    switch (kvp.Value.Trim().ToLower())
                    {
                        case "prerequisites":
                            string value = keyValuePairs["description"];
                            if (value.Contains(","))
                            {
                                string parsing = value.Trim().ToLower();
                                int CurrentIndex = 0;
                                while (parsing.Contains(","))
                                {
                                    string token = parsing.Substring(CurrentIndex, parsing.IndexOf(","));
                                    prerequisites.Add(token);
                                    CurrentIndex = parsing.IndexOf(",") + 1;
                                    parsing = parsing.Substring(CurrentIndex);
                                    
                                }
                                prerequisites.Add(parsing.Trim('.'));
                            } else
                            {
                                prerequisites.Add(keyValuePairs["description"]);
                            }
                            
                            
                            break;
                        default:
                            break;
                    }
                }
                
            }

            //adding the nested jobject objects to a dictionary for easier access
            foreach (var subFeat in feat_types)
            {
                SubFeatTypes = JsonConvert.DeserializeObject<Dictionary<string, string>>(feat_types.ToString());
            }

  


        }

        ////ToString override
        //public override string ToString()
        //{
        //    String s = this.name + "\t+\t" + attribute + "\t";
        //    if (this.trained_only)
        //    {
        //        s += "Trained Only\t";
        //    }
        //    else
        //    {
        //        s += "Can Be Used Untrained\t";
        //    }

        //    return s;
        //}



        //public List<SqlParameter> GetSQLParameters()
        //{
        //    //builds an SQL parameter of all attributes for object
        //    List<SqlParameter> sqlParams = new List<SqlParameter>();

        //    SqlParameter param = new SqlParameter("@SkillName", SqlDbType.VarChar, 50);
        //    sqlParams.Add(param);
        //    param.Value = this.name;

        //    param = new SqlParameter("@SkillAttribute", SqlDbType.VarChar, 50);
        //    sqlParams.Add(param);
        //    param.Value = this.attribute;

        //    param = new SqlParameter("@TrainedOnly", SqlDbType.Bit);
        //    sqlParams.Add(param);
        //    param.Value = this.trained_only;

        //    param = new SqlParameter("@ArmorCheckPenalty", SqlDbType.Bit);
        //    sqlParams.Add(param);
        //    param.Value = this.armor_check_penalty;

        //    param = new SqlParameter("@URL", SqlDbType.VarChar);
        //    sqlParams.Add(param);
        //    param.Value = this.url;

        //    param = new SqlParameter("@Type", SqlDbType.VarChar);
        //    sqlParams.Add(param);
        //    param.Value = this.type;

        //    param = new SqlParameter("@Source", SqlDbType.VarChar);
        //    sqlParams.Add(param);
        //    param.Value = this.source;


        //    return sqlParams;
        //}
    }
}
