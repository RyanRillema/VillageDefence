using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.BaseModels
{
    public class Unit
    {
        public String Name = "";
        public int Level = 0;
        public Combat CombatStats = new Combat();
        public HealthBar Health = new HealthBar();

    }
}
