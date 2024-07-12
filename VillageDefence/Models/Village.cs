using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageDefence.Models.Structures;
using VillageDefence.Models.Units;

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
        public ConstructionStructure Barracks = new ConstructionStructure(1);
        public ConstructionStructure Archery = new ConstructionStructure(2);

        public MeleeUnit MeleeUnits = new MeleeUnit();
        public RangeUnit RangeUnits = new RangeUnit();

        private int CoinsInc = 2;
        private int FoodInc = 1;

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
            return CoinsInc + CoinsA.ResourceInc + CoinsB.ResourceInc;
        }
        public int FoodPerTurn()
        {
            return FoodInc + FarmA.ResourceInc + FarmB.ResourceInc;
        }
        public void NewGame()
        {
            MeleeUnits.SetInitDetails();
            RangeUnits.SetInitDetails();

            //Upgrade to set intial values
            TowerA.SetInitDetails();
            TowerB.SetInitDetails();
            GateA.SetInitDetails();
            GateB.SetInitDetails();
            Barracks.SetInitDetails();
            Archery.SetInitDetails();
            CoinsA.SetInitDetails();
            CoinsB.SetInitDetails();
            FarmA.SetInitDetails();
            FarmB.SetInitDetails();

            //Add some units
            MeleeUnits.Count = 4;
            RangeUnits.Count = 2;
        }
    }
}
