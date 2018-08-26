using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoblinGen
{
    public abstract class Npc
    {

        //TODO : Design abstract class to contain all 
        // data points shared for all possible NPC types

        public Dictionary<String, int> NpcAttribDictionary { get; set; }
        public Dictionary<String, int> NpcSkillDictionary { get; set; }
        
        //TODO implement Item Object Class
        public Dictionary<String, Object> NpcEquippedDictionary {get; set;}
        public Dictionary<String, Object> NpcOtherEquipmentDictonary { get; set; }


        public List<String> NpcFeatList { get; set; }
        public int MoveSpeed { get; set; }
        public String Size { get; set; }
        public String CreatureType { get; set; }
        public String CreatureSubType { get; set; }


    }
}
