using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
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
            SetupBattle();
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
            Button DefendButton;
            if (source.Equals(AttackMeleeButton))
            {
                myBattle.DefendUnit = myBattle.AttackMeleeA;
                DefendButton = AttackMeleeButton;
            }
            else if (source.Equals(AttackRangeButton))
            {
                myBattle.DefendUnit = myBattle.AttackRangeA;
                DefendButton = AttackRangeButton;
            }
            else
            {
                myBattle.AddOutput("Dont attack yourself");
                Refresh();
                return;
            }
            myBattle.Attack(DefendButton, false);
            myBattle.NextTurn();
        }        
        public void Refresh()
        {
            RefreshButton(AttackMeleeButton, myBattle.AttackMeleeA);
            RefreshButton(AttackRangeButton, myBattle.AttackRangeA);

            RefreshButton(MyTowerAButton, myBattle.MyTowerA);
            RefreshButton(MyTowerBButton, myBattle.MyTowerB);
            RefreshButton(MyGateAButton, myBattle.MyGateA);
            RefreshButton(MyGateBButton, myBattle.MyGateB);
            RefreshButton(MyMeleeButton, myBattle.MyMelee);
            RefreshButton(MyRangeButton, myBattle.MyRange);
            RefreshButton(MyTankButton, myBattle.MyTank);

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
        private void SetupBattle()
        {
            SetupBattleButton(AttackMeleeButton, myBattle.AttackMeleeA);
            SetupBattleButton(AttackRangeButton, myBattle.AttackRangeA);

            SetupBattleButton(MyTowerAButton, myBattle.MyTowerA);
            SetupBattleButton(MyTowerBButton, myBattle.MyTowerB);
            SetupBattleButton(MyGateAButton, myBattle.MyGateA);
            SetupBattleButton(MyGateBButton, myBattle.MyGateB);
            SetupBattleButton(MyMeleeButton, myBattle.MyMelee);
            SetupBattleButton(MyRangeButton, myBattle.MyRange);
            SetupBattleButton(MyTankButton, myBattle.MyTank);
        }
        private void SetupBattleButton(Button RefreshButton, BaseModel RefreshUnit)
        {
            if (RefreshUnit.Count < 1)
            {
                RefreshButton.IsVisible = false;
            }
            else 
            {
                RefreshButton.IsVisible = true;
            }
        }
        public void ClearButtonHighlight()
        {
            MyMeleeButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyRangeButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyTankButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyTowerAButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyTowerBButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyGateAButton.BorderThickness = Avalonia.Thickness.Parse("0");
            MyGateBButton.BorderThickness = Avalonia.Thickness.Parse("0");
        }
        public void AttackAnimation(Button AttackButton)
        {
            var animation = (Animation)this.Resources["AttackAnimation"];

            animation.RunAsync(AttackButton);
        }
        public void KillAnimation(Button AttackButton)
        {
            var animation = (Animation)this.Resources["KillAnimation"];

            animation.RunAsync(AttackButton);
            AttackButton.Opacity = 0.4;
        }
    }
}
