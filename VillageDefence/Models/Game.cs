using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageDefence.Models
{
    public class Game
    {
        public int Turn = 0;
        public bool StartBattle=false;
        public Village myVillage = new Village();
        public Battle myBattle = new Battle();

        public void NextTurn()
        {
            myVillage.NextTurn();
            Turn++;
            if (SpinBattle())
            {
                myBattle.SetupBattle(myVillage, Turn);
                StartBattle = true;
            }else
            {
                StartBattle = false;
            }
           
        }

        public bool IsStartBattle()
        {
            return StartBattle;
        }

        public void NewGame()
        {
            myVillage = new Village();
            myVillage.NewGame();
            Turn = 0;
        }
        private bool SpinBattle()
        {
            //1 in 5 chance of battle
            Random rnd = new Random();
            int Value = rnd.Next(1, 5);
            if (Value == 1)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
