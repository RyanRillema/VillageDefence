using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Structures;

namespace VillageDefence.Models
{
    public class Village
    {
        public int Coins = 0;
        public int Food = 0;
        public DefenseStructure TowerA = new DefenseStructure(1);
        public DefenseStructure TowerB = new DefenseStructure(1);
        public DefenseStructure GateA = new DefenseStructure(2);
        public DefenseStructure GateB = new DefenseStructure(2);
        public ResourceStructure CoinsA = new ResourceStructure(1);
        public ResourceStructure CoinsB = new ResourceStructure(1);
        public ResourceStructure FarmA = new ResourceStructure(2);
        public ResourceStructure FarmB = new ResourceStructure(2);

        public void NextTurn()
        {
            Coins += CoinsPerTurn();
            Food += FoodPerTurn();
        }
        public void UpgradeBuilding(Structure Building)
        {
            int UpgradeCost = Building.UpgradeCost;

            if (Coins >= UpgradeCost)
            {
                if (Building.Upgrade())
                {
                    Coins -= UpgradeCost;
                }               
            }
        }
        public int CoinsPerTurn()
        {
            return CoinsA.ResourceInc+CoinsB.ResourceInc;
        }
        public int FoodPerTurn()
        {
            return FarmA.ResourceInc+FarmB.ResourceInc;
        }
        public void NewGame()
        {
            //Upgrade to set intial values
            TowerA.Upgrade();
            TowerB.Upgrade();
            GateA.Upgrade();
            GateB.Upgrade();
            CoinsA.Upgrade();
            CoinsB.Upgrade();
            FarmA.Upgrade();
            FarmB.Upgrade();

            //Upgrade coins to get started
            CoinsA.Upgrade();
        }
    }
}
