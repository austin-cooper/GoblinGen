using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace GoblinGen
{

    //***********************************************************************************************************
    // Skill class used to define a skill object. A skill consists of the skill name, the attribute that is used
    // with the skill, and whether or not it can be used untrained and whether an armor check penalty applies. T
    // This also includes type of object, URL of data, and source for the material
    //***********************************************************************************************************

    class Skill
    {

        public String type { get; set; }
        public String name { get; set; }
        public String url { get; set; }
        public String attribute { get; set; }
        public String source { get; set; }
        public bool trained_only { get; set; }
        public bool armor_check_penalty { get; set; }



        //constructor
        public Skill()
        {

        }

        //ToString override
        public override string ToString()
        {
            String s = this.name + "\t+\t" + attribute + "\t";
            if (this.trained_only)
            {
                s += "Trained Only\t";
            }
            else
            {
                s += "Can Be Used Untrained\t";
            }

            return s;
        }



        public List<SqlParameter> GetSQLParameters()
        {
            //builds an SQL parameter of all attributes for object
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            SqlParameter param = new SqlParameter("@SkillName", SqlDbType.VarChar, 50);
            sqlParams.Add(param);
            param.Value = this.name;

            param = new SqlParameter("@SkillAttribute", SqlDbType.VarChar, 50);
            sqlParams.Add(param);
            param.Value = this.attribute;

            param = new SqlParameter("@TrainedOnly", SqlDbType.Bit);
            sqlParams.Add(param);
            param.Value = this.trained_only;

            param = new SqlParameter("@ArmorCheckPenalty", SqlDbType.Bit);
            sqlParams.Add(param);
            param.Value = this.armor_check_penalty;

            param = new SqlParameter("@URL", SqlDbType.VarChar );
            sqlParams.Add(param);
            param.Value = this.url;

            param = new SqlParameter("@Type", SqlDbType.VarChar);
            sqlParams.Add(param);
            param.Value = this.type;

            param = new SqlParameter("@Source", SqlDbType.VarChar);
            sqlParams.Add(param);
            param.Value = this.source;


            return sqlParams;
        }
    }
}
