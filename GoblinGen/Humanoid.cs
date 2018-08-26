using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinGen
{
    public abstract class Humanoid : Npc
    {
        private String npcCreatureType;
        public String HumanoidHitDie;
        public String HumanoidBabProgression;
        public int HumanoidBaseSkillPts;
        public bool HumanoidMustBreathe = true;
        public bool HumanoidMustEat = true;
        public bool HumanoidMustSleep = true;
        //TODO add weapon and armor proficiency objects

        //default class skills for humanoid without class levels
        //using a dictionary for now, will improve later, since all boolean values
        //are true, probably will create skill list class that has a full list
        //property 
        public Dictionary<String, bool> HumanoidClassSkills = new Dictionary<String, bool>()
        {
            {"Climb", true },
            {"Craft", true },
            {"Handle Animal", true },
            {"Heal", true },
            {"Profession", true },
            {"Ride", true },
            {"Survival", true }
        };
        public String NpcCreatureType { get => npcCreatureType; set => npcCreatureType = "Humanoid"; }
    }
}
