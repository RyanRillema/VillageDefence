using Avalonia.Controls;
using Avalonia.Interactivity;
using VillageDefence.Models;
using VillageDefence.Models.Structures;

namespace VillageDefence.Views
{
    public partial class BuildingView : UserControl
    {
        public Village myVillage;
        public Structure myBuilding;
        public BuildingView(Village SetVillage, Structure SetBuilding)
        {
            InitializeComponent();
            myVillage = SetVillage;
            myBuilding = SetBuilding;
            Refresh();
        }
        public void Refresh()
        {
            // Labels
            LabelName.Content = myBuilding.Name;
            LabelA.Content = myBuilding.CreateLabelA();
            LabelAValue.Content = myBuilding.CreateLabelAValue(myVillage);
            LabelB.Content = myBuilding.CreateLabelB();
            LabelBValue.Content = myBuilding.CreateLabelBValue(myVillage);
            LabelC.Content = myBuilding.CreateLabelC();
            LabelCValue.Content = myBuilding.CreateLabelCValue();
            LabelD.Content = myBuilding.CreateLabelD();
            LabelDValue.Content = myBuilding.CreateLabelDValue();
            LabelLevelValue.Content=myBuilding.Level;
            LabelUpgradeValue.Content = myBuilding.UpgradeCost;

            // Buttons
            FuncAButton.Content = myBuilding.CreateTextFuncA(myVillage);
            FuncAButton.IsVisible = !(FuncAButton.Content.ToString() == " ");
            FuncBButton.Content = myBuilding.CreateTextFuncB(myVillage);
            FuncBButton.IsVisible = !(FuncBButton.Content.ToString() == " ");
            FuncCButton.Content = myBuilding.CreateTextFuncC(myVillage);
            FuncCButton.IsVisible = !(FuncCButton.Content.ToString() == " ");
            FuncDButton.Content = myBuilding.CreateTextFuncD(myVillage);
            FuncDButton.IsVisible = !(FuncDButton.Content.ToString() == " ");
            FuncEButton.Content = myBuilding.CreateTextFuncE(myVillage);
            FuncEButton.IsVisible = !(FuncEButton.Content.ToString() == " ");
            FuncFButton.Content = myBuilding.CreateTextFuncF(myVillage);
            FuncFButton.IsVisible = !(FuncFButton.Content.ToString() == " ");
            UpgradeButton.IsVisible = myBuilding.CanUpgrade();
        }
        public void UpgradeButtonClicked(object source, RoutedEventArgs args)
        {
            myVillage.UpgradeBuilding(myBuilding);
            Refresh();
        }
        public void FuncAButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncA(myVillage))
            {
                Refresh();
            }            
        }
        public void FuncBButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncB(myVillage))
            {
                Refresh();
            }
        }
        public void FuncCButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncC(myVillage))
            {
                Refresh();
            }
        }
        public void FuncDButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncD(myVillage))
            {
                Refresh();
            }
        }
        public void FuncEButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncC(myVillage))
            {
                Refresh();
            }
        }
        public void FuncFButtonClicked(object source, RoutedEventArgs args)
        {
            if (myBuilding.FuncD(myVillage))
            {
                Refresh();
            }
        }
    }
}
