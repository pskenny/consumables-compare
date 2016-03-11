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

using System.Collections;

using Windows.UI.Popups;

namespace Consumables_Compare
{
    public sealed partial class ListPage : Page
    {
        private List<GenericListItem> ListItems;

        public string Mode = "";

        public ListPage()
        {
            this.InitializeComponent();

            ListItems = new List<GenericListItem>();
            ListBox.DataContext = ListItems;
        }

        private bool CheckLastPage(Type desiredPage)
        {
            //  Taken from http://stackoverflow.com/questions/25725144/how-to-know-which-was-my-last-page-in-windows-phone-8-1
            var lastPage = Frame.BackStack.LastOrDefault();
            return (lastPage != null && lastPage.SourcePageType.Equals(desiredPage)) ? true : false;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            
            //check if navigated to from MainPage or ItemDetails
            if (CheckLastPage(typeof(MainPage)))
            {
                // clear elements
                ListItems.Clear();
                // check if size, weight or weight and change title and mode appropriately
                string val = e.Parameter as string;
                Mode = val;

                switch (val)
                {
                    case Util.SIZE:
                        title.Text = "Size";
                        break;
                    case Util.WEIGHT:
                        title.Text = "Weight";
                        break;
                    case Util.VOLUME:
                        title.Text = "Volume";
                        break;
                    default:
                        break;
                }
            } else if(CheckLastPage(typeof(ItemDetails)))
            {
                // add element if not null (meaning cancelled), sort list
                GenericListItem val = e.Parameter as GenericListItem;
                if (val != null)
                {
                    ListItems.Add(val);
                    ListItems.Sort();
                }
            }            
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ItemDetails), Mode);
        }
    }
}
