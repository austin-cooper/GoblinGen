using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
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
        public JArray sections;
        public String source { get; set; }
        public JObject feat_types;
        public String type { get; set; }
        public String description { get; set; }

        //fields needed to be derived from sections
        public IEnumerable<string> prerequisites;
        public IEnumerable<string> benefits;
        public IEnumerable<string> normal;
        public IEnumerable<string> special;
        



        //constructor
        public Feat()
        {

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
