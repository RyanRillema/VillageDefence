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

        public void NextTurn()
        {
            myVillage.NextTurn();
            Turn++;
            if (SpinGenerator.SpinBattle())
            {
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
            myVillage.Coins = 2;
            myVillage.Coins = 2000;
        }
    }
}
