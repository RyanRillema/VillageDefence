using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using VillageDefence.Models;
using VillageDefence.Models.Structures;

namespace VillageDefence.Views;

public partial class MainView : UserControl
{
    public Game myGame;
    BuildingView myBuildingView;
    BattleView myBattleView;
    public MainView()
    {
        myGame = new Game();
        myGame.NewGame();
        InitializeComponent();
        myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.TowerA);
    }
    public void LoadMainView()
    {
        MainGrid.IsVisible = true;
        MainLabel.IsVisible = false;

        Refresh();
    }
    public void ShowHome(bool Hide)
    {
        HomeButton.IsVisible = Hide;
    }
    public void ShowNext(bool Hide)
    {
        NextTurnButton.IsVisible = Hide;
    }
    public void BuildButtonClicked(object source, RoutedEventArgs args)
    {
        if (source.Equals(BuildA1))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.TowerA);
        }
        if (source.Equals(BuildA2))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.GateA);
        }
        if (source.Equals(BuildA3))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.GateB);
        }
        if (source.Equals(BuildA4))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.TowerB);
        }
        if (source.Equals(BuildB1))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.Archery);
        }
        if (source.Equals(BuildB2))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.Barracks);
        }
        if (source.Equals(BuildB3))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.Forge);
        }
        if (source.Equals(BuildB4))
        {

        }
        if (source.Equals(BuildC1))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.CoinsA);
        }
        if (source.Equals(BuildC2))
        {

        }
        if (source.Equals(BuildC3))
        {

        }
        if (source.Equals(BuildC4))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.CoinsB);
        }
        if (source.Equals(BuildD1))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.FarmA);
        }
        if (source.Equals(BuildD2))
        {

        }
        if (source.Equals(BuildD3))
        {

        }
        if (source.Equals(BuildD4))
        {
            myBuildingView = new BuildingView(myGame.myVillage, myGame.myVillage.FarmB);
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
        FoodPerTurnLabel.Content = "(+" + myGame.myVillage.FoodPerTurn() + ")";
        MeleeLabel.Content = "Melee: " + myGame.myVillage.MeleeUnits.Count;
        RangeLabel.Content = "Range: " + myGame.myVillage.RangeUnits.Count;
        TankLabel.Content = "Tanks: " + myGame.myVillage.TankUnits.Count;
    }
    private void RefreshBuildings()
    {
        Structure RefreshBase;

        RefreshBase = myGame.myVillage.TowerA;
        BuildA1.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.GateA;
        BuildA2.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.GateB;
        BuildA3.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.TowerB;
        BuildA4.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.Archery;
        BuildB1.Content = RefreshBase.GetButtonLabel();
        RefreshBase = myGame.myVillage.Barracks;
        BuildB2.Content = RefreshBase.GetButtonLabel();
        RefreshBase = myGame.myVillage.Forge;
        BuildB3.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.CoinsA;
        BuildC1.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.CoinsB;
        BuildC4.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.FarmA;
        BuildD1.Content = RefreshBase.GetButtonLabel();

        RefreshBase = myGame.myVillage.FarmB;
        BuildD4.Content = RefreshBase.GetButtonLabel();

    }
    public void NextTurnButtonClicked(object source, RoutedEventArgs args)
    {
        myGame.NextTurn();
        MainLabel.IsVisible = false;
        MainGrid.IsVisible = true;
        if (myGame.IsStartBattle())
        {
            myBattleView = new BattleView(this);
            MainLabel.Content = myBattleView;

            MainGrid.IsVisible = false;
            MainLabel.IsVisible = true;
        }
        Refresh();
    }
    public void HomeButtonClicked(object source, RoutedEventArgs args)
    {
        MainLabel.IsVisible = false;
        MainGrid.IsVisible = true;
        NextTurnButton.IsVisible = true;
        Refresh();
    }
    public void NewGameButtonClicked(object source, RoutedEventArgs args)
    {
        myGame.NewGame();
        HomeButtonClicked(source, args);
    }
    public void FormLoad(object source, RoutedEventArgs args)
    {        
        Refresh();
    }
    public void ExitButtonClicked(object source, RoutedEventArgs args)
    {

    }
}
