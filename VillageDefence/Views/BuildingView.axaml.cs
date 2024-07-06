using Avalonia.Controls;
using Avalonia.Interactivity;
using VillageDefence.Models;
using VillageDefence.Models.Structures;

namespace VillageDefence.Views
{
    public partial class BuildingView : UserControl
    {
        public Game myGame;
        public Structure myBuilding;
        public BuildingView(Game SetGame, Structure SetBuilding)
        {
            InitializeComponent();
            myGame = SetGame;
            myBuilding = SetBuilding;
            Refresh();
        }
        public void Refresh()
        {
            LabelName.Content = myBuilding.Name;
            LabelA.Content = myBuilding.CreateLabelA();
            LabelAValue.Content = myBuilding.CreateLabelAValue();
            LabelB.Content = myBuilding.CreateLabelB();
            LabelBValue.Content = myBuilding.CreateLabelBValue();
            LabelC.Content = myBuilding.CreateLabelC();
            LabelCValue.Content = myBuilding.CreateLabelCValue();
            LabelD.Content = myBuilding.CreateLabelD();
            LabelDValue.Content = myBuilding.CreateLabelDValue();
            LabelLevelValue.Content=myBuilding.Level;
            LabelUpgradeValue.Content = myBuilding.UpgradeCost;

            FuncAButton.Content = myBuilding.CreateTextFuncA();
            FuncAButton.IsVisible = !(FuncAButton.Content.ToString() == " ");

            FuncBButton.Content = myBuilding.CreateTextFuncB();
            FuncBButton.IsVisible = !(FuncBButton.Content.ToString() == " ");
        }
        public void UpgradeButtonClicked(object source, RoutedEventArgs args)
        {
            myGame.myVillage.UpgradeBuilding(myBuilding);
            Refresh();
        }
        public void FuncAButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncA())
            {
                Refresh();
            }            
        }
        public void FuncBButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncB())
            {
                Refresh();
            }
        }
    }
}
