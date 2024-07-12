﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models.BaseModels
{
    public abstract class BaseModel
    {
        public string Name = "";
        public int Level = 0;
        public int Count = 0;
        public Combat CombatStats = new Combat();
        public HealthBar Health = new HealthBar(5);
        public String StringReturnCheckLevel(String StringReturn)
        {
            if (Level < 1)
            {
                return " ";
            }
            else
            {
                return StringReturn;
            }
        }
        public abstract bool DoDamage(int Damage, ref int DamageDone);
        public abstract String GetButtonLabel();
        public abstract void SetInitDetails();
    }
}
