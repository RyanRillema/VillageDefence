using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using VillageDefence.Models;
using VillageDefence.Models.Units;

namespace VillageDefence.Views
{
    public partial class BattleView : UserControl
    {
        public MainView myParent;
        public Battle myBattle;
        public BattleView(MainView SetParent)
        {
            InitializeComponent();
            myParent = SetParent;
            myBattle = new Battle(this);
            myBattle.SetupBattle(myParent.myGame.myVillage, myParent.myGame.Turn);
            Refresh();
            myBattle.NextTurn();
            myParent.ShowHome(false);
            myParent.ShowNext(false);
        }        
        public void CloseButtonClicked(object source, RoutedEventArgs args)
        {
            myParent.ShowHome(true);
            myParent.LoadMainView();
        }
        public void ButtonClicked(object source, RoutedEventArgs args)
        {
            if (source.Equals(AttackMeleeButton))
            {
                myBattle.DefendUnit = myBattle.AttackMelee;
            }
            else if (source.Equals(AttackRangeButton))
            {
                myBattle.DefendUnit = myBattle.AttackRange;
            }
            else
            {
                myBattle.AddOutput("Dont attack yourself");
                Refresh();
                return;
            }
            myBattle.Attack();
            myBattle.NextTurn();
        }        
        public void Refresh()
        {
            AttackMeleeButton.Content = myBattle.AttackMelee.Name + "\nAttack: " + myBattle.AttackMelee.CombatStats.DamageValue
                + "\nDefence: " + myBattle.AttackMelee.CombatStats.ArmourValue
                + "\nCount: " + myBattle.AttackMelee.Count
                + "\nHealth: " + myBattle.AttackMelee.Health.CurrentHealth + " / "+ myBattle.AttackMelee.Health.TotalHealth;
            if (myBattle.AttackMelee.Count < 1)
            {
                AttackMeleeButton.IsEnabled = false;
            }
            else
            {
                AttackMeleeButton.IsEnabled = true;
            }

            AttackRangeButton.Content = myBattle.AttackRange.Name + "\nAttack: " + myBattle.AttackRange.CombatStats.DamageValue
                + "\nDefence: " + myBattle.AttackRange.CombatStats.ArmourValue
                + "\nCount: " + myBattle.AttackRange.Count
                + "\nHealth: " + myBattle.AttackRange.Health.CurrentHealth + " / " + myBattle.AttackRange.Health.TotalHealth;
            if (myBattle.AttackRange.Count < 1)
            {
                AttackRangeButton.IsEnabled = false;
            }
            else
            {
                AttackRangeButton.IsEnabled = true;
            }

            MyMeleeButton.Content = myBattle.MyMelee.Name + "\nAttack: " + myBattle.MyMelee.CombatStats.DamageValue
                + "\nDefence: " + myBattle.MyMelee.CombatStats.ArmourValue
                + "\nCount: " + myBattle.MyMelee.Count
                + "\nHealth: " + myBattle.MyMelee.Health.CurrentHealth + " / " + myBattle.MyMelee.Health.TotalHealth;
            if (myBattle.MyMelee.Count < 1)
            {
               MyMeleeButton.IsEnabled = false;
            }
            else
            {
                MyMeleeButton.IsEnabled = true;
            }

            MyRangeButton.Content = myBattle.MyRange.Name + "\nAttack: " + myBattle.MyRange.CombatStats.DamageValue
                + "\nDefence: " + myBattle.MyRange.CombatStats.ArmourValue
                + "\nCount: " + myBattle.MyRange.Count
                + "\nHealth: " + myBattle.MyRange.Health.CurrentHealth + " / " + myBattle.MyRange.Health.TotalHealth;
            if (myBattle.MyRange.Count < 1)
            {
                MyRangeButton.IsEnabled = false;
            }
            else
            {
                MyRangeButton.IsEnabled = true;
            }

            OutputLabelA.Content = myBattle.OutputA + "\n" + myBattle.OutputB + "\n" + myBattle.OutputC;
            OutputLabelB.Content = myBattle.OutputD + "\n" + myBattle.OutputE + "\n" + myBattle.OutputF;
        }
        public void ClearButtonHighlight()
        {
            MyMeleeButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyRangeButton.BorderThickness = Avalonia.Thickness.Parse("0");
        }

    }
}
