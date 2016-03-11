using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;

namespace Consumables_Compare
{
    public sealed partial class ItemDetails : Page
    {
        private string Mode = "";
        public ItemDetails()
        {
            this.InitializeComponent();
        }

       protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string val = e.Parameter as string;

            // Use different title and unit depending on if size, weight or volume and set Mode for returning object later
            switch (val)
            {
                case Util.SIZE:
                    UnitText.Text = "Size (diameter in " + GenericListItem.CENTIMETER + ")";
                    Mode = GenericListItem.CENTIMETER;
                    break;
                case Util.WEIGHT:
                    UnitText.Text = "Weight (" + GenericListItem.GRAM + ")";
                    Mode = GenericListItem.GRAM;
                    break;
                case Util.VOLUME:
                    UnitText.Text = "Volume (" + GenericListItem.MILLILITRE + ")";
                    Mode = GenericListItem.MILLILITRE;
                    break;
                default:
                    break;
            }
        }

        private bool CheckValidInput()
        {
            // taken from StackOverflow, editted to suit context
            // check name not empty, price is number and unit value is number
            float flo;
            return (NameBox.Text.Equals("") & !float.TryParse(PriceBox.Text, out flo) &
                !float.TryParse(ValueBox.Text, out flo)) ? false : true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if(!CheckValidInput())
            {
                //open message box saying needs different input
                new MessageDialog("None of the values can be empty").ShowAsync();
                return;
            }

            //go back to ListPage and return a GenericItem
            GenericListItem item = new GenericListItem(NameBox.Text, float.Parse(PriceBox.Text), 
                float.Parse(ValueBox.Text), Mode);

            Frame.Navigate(typeof(ListPage), item);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //go back to ListPage
            Frame.Navigate(typeof(ListPage), null);
        }
    }
}
