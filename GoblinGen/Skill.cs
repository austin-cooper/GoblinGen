using System;

namespace GoblinGen
{

    //***********************************************************************************************************
    // Skill class used to define a skill object. A skill consists of the skill name, the attribute that is used
    // with the skill, and whether or not it can be used untrained and whether an armor check penalty applies
    //***********************************************************************************************************

    class Skill
    {
        //attributes
        protected String SkillName { get; set; }
        protected String SkillAttribUsed { get; set; }
        protected bool IsTrainedOnly { get; set; }
        protected bool SkillArmorCheckPenalty { get; set; }


        //constructor with null checks
        public Skill(string skillName, string skillAttribUsed, bool isTrainedOnly, bool skillArmorCheckPenalty)
        {
            SkillName = skillName ?? throw new ArgumentNullException(nameof(skillName));
            SkillAttribUsed = skillAttribUsed ?? throw new ArgumentNullException(nameof(skillAttribUsed));
            IsTrainedOnly = isTrainedOnly;
            SkillArmorCheckPenalty = skillArmorCheckPenalty;
        }

        //ToString override
        public override string ToString()
        {
            String s = this.SkillName + "\t+\t" + SkillAttribUsed\t";
            if (DoesArmorCheckApply())
            {
                s += "Trained Only\t";
            }
            else
            {
                s += "Can Be Used Untrained\t";
            }

            return s;
        }


        //Determines whether the skill both has an armor check penalty and whether it uses
        // Str or Dex. This should be redundant but is a layer of error checking for mismatched data

        public bool DoesArmorCheckApply()
        {
            if (SkillArmorCheckPenalty && (SkillAttribUsed.Equals("Dex") || SkillAttribUsed.Equals("Str")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
