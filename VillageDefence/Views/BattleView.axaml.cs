using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using VillageDefence.Models;
using VillageDefence.Models.BaseModels;
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
            RefreshButton(AttackMeleeButton, myBattle.AttackMelee);
            RefreshButton(AttackRangeButton, myBattle.AttackRange);

            RefreshButton(MyTowerAButton, myBattle.MyTowerA);
            RefreshButton(MyTowerBButton, myBattle.MyTowerB);
            RefreshButton(MyMeleeButton, myBattle.MyMelee);
            RefreshButton(MyRangeButton, myBattle.MyRange);

            OutputLabelA.Content = myBattle.OutputA + "\n" + myBattle.OutputB + "\n" + myBattle.OutputC;
            OutputLabelB.Content = myBattle.OutputD + "\n" + myBattle.OutputE + "\n" + myBattle.OutputF;
        }
        private void RefreshButton(Button RefreshButton, BaseModel RefreshUnit)
        {
            RefreshButton.Content = RefreshUnit.GetButtonLabel();
            if (RefreshUnit.Count < 1)
            {
                RefreshButton.IsEnabled = false;
            }
            else
            {
                RefreshButton.IsEnabled = true;
            }
        }
        public void ClearButtonHighlight()
        {
            MyMeleeButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyRangeButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyTowerAButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyTowerBButton.BorderThickness = Avalonia.Thickness.Parse("0");
        }

    }
}
