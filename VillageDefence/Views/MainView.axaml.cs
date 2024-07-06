using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using VillageDefence.Models;
using VillageDefence.Models.BaseModels;
using VillageDefence.Models.Structures;

namespace VillageDefence.Views;

public partial class MainView : UserControl
{
    public Game myGame;
    BuildingView myBuildingView;
    public MainView()
    {
        myGame = new Game();
        InitializeComponent();
        myBuildingView = new BuildingView(myGame, myGame.myVillage.TowerA);
    }
    public void BuildButtonClicked(object source, RoutedEventArgs args)
    {
        if (source.Equals(BuildA1))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.TowerA);
        }
        if (source.Equals(BuildA2))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.GateA);
        }
        if (source.Equals(BuildA3))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.GateB);
        }
        if (source.Equals(BuildA4))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.TowerB);
        }
        if (source.Equals(BuildB1))
        {

        }
        if (source.Equals(BuildB2))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.Barracks);
        }
        if (source.Equals(BuildB3))
        {

        }
        if (source.Equals(BuildB4))
        {

        }
        if (source.Equals(BuildC1))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.CoinsA);
        }
        if (source.Equals(BuildC2))
        {

        }
        if (source.Equals(BuildC3))
        {

        }
        if (source.Equals(BuildC4))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.CoinsB);
        }
        if (source.Equals(BuildD1))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.FarmA);
        }
        if (source.Equals(BuildD2))
        {

        }
        if (source.Equals(BuildD3))
        {

        }
        if (source.Equals(BuildD4))
        {
            myBuildingView = new BuildingView(myGame, myGame.myVillage.FarmB);
        }

        MainLabel.Content = myBuildingView;

        MainGrid.IsVisible = false;
        MainLabel.IsVisible = true;

        Refresh();
    }
    public void Refresh()
    {
        RefreshStats();
        RefreshBuildings();
    }
    private void RefreshStats()
    {
        TurnLabel.Content = "Turn: " + myGame.Turn;
        CoinsLabel.Content = "Coins: " + myGame.myVillage.Coins;
        CoinsPerTurnLabel.Content = "(+" + myGame.myVillage.CoinsPerTurn() + ")";
        FoodLabel.Content = "Food: " + myGame.myVillage.Food;
        FoodPerTurnLabel.Content = "(" + myGame.myVillage.FoodPerTurn() + ")";
        MeleeLabel.Content = "Army: " + myGame.myVillage.MeleeUnits.Count;
        RangeLabel.Content = "Range: " + myGame.myVillage.RangeUnits.Count;
    }
    private void RefreshBuildings()
    {
        Structure RefreshBase;

        RefreshBase = myGame.myVillage.TowerA;
        BuildA1.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nDamage: " + myGame.myVillage.TowerA.Combat.DamageValue
            + "\nArmour: " + myGame.myVillage.TowerA.Combat.ArmourValue
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.GateA;
        BuildA2.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nDamage: " + myGame.myVillage.GateA.Combat.DamageValue
            + "\nArmour: " + myGame.myVillage.GateA.Combat.ArmourValue
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.GateB;
        BuildA3.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nDamage: " + myGame.myVillage.GateB.Combat.DamageValue
            + "\nArmour: " + myGame.myVillage.GateB.Combat.ArmourValue
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.TowerB;
        BuildA4.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nDamage: " + myGame.myVillage.TowerB.Combat.DamageValue
            + "\nArmour: " + myGame.myVillage.TowerB.Combat.ArmourValue
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.Barracks;
        BuildB2.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.CoinsA;
        BuildC1.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nCoins: " + myGame.myVillage.CoinsA.ResourceInc
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.CoinsB;
        BuildC4.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nCoins: " + myGame.myVillage.CoinsB.ResourceInc
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.FarmA;
        BuildD1.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nCoins: " + myGame.myVillage.FarmA.ResourceInc
            + "\n(" + RefreshBase.UpgradeCost + ")";

        RefreshBase = myGame.myVillage.FarmB;
        BuildD4.Content = RefreshBase.Name + "\nLevel: " + RefreshBase.Level
            + "\nCoins: " + myGame.myVillage.FarmB.ResourceInc
            + "\n(" + RefreshBase.UpgradeCost + ")";

    }
    public void NextTurnButtonClicked(object source, RoutedEventArgs args)
    {
        myGame.NextTurn();
        Refresh();
    }
    public void HomeButtonClicked(object source, RoutedEventArgs args)
    {
        Refresh();
        MainLabel.IsVisible = false;
        MainGrid.IsVisible = true;
    }
    public void NewGameButtonClicked(object source, RoutedEventArgs args)
    {
        myGame.NewGame();
        Refresh();
    }
    public void FormLoad(object source, RoutedEventArgs args)
    {
        myGame.NewGame();
        Refresh();
    }
    public void ExitButtonClicked(object source, RoutedEventArgs args)
    {

    }
}
