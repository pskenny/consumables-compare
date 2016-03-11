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

namespace Consumables_Compare
{
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            sizeButton.Click += SizeButton_Click;
            weightButton.Click += WeightButton_Click;
            volumeButton.Click += VolumeButton_Click;
        }

        private void SizeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListPage), Util.SIZE);
        }

        private void WeightButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListPage), Util.WEIGHT);
        }
        
        private void VolumeButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ListPage), Util.VOLUME);
        }
    }
}
