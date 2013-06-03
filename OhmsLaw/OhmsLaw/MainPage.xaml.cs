using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace OhmsLaw
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
        public bool isStringAnInteger(string input)
        {
            
            if (input == "")
            {
                return false;
            }
           /* for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]) == false)
                {
                    debugBlock.Text = "Invalid Input, please enter an integer";
                    result = false;
                }
            } */
            double d = 0;
            if (Double.TryParse(input, out d))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void onVoltage(object sender, RoutedEventArgs e)
        {
            if (isStringAnInteger(iBlock.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(rBlock.Text) == false)
            {
                return;
            }

            vBlock.Text = (Convert.ToDouble(iBlock.Text) * Convert.ToDouble(rBlock.Text)).ToString(); 
        }

        private void onCurrent(object sender, RoutedEventArgs e)
        {
            if (isStringAnInteger(vBlock.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(rBlock.Text) == false)
            {
                return;
            }

            iBlock.Text = (Convert.ToDouble(vBlock.Text) / Convert.ToDouble(rBlock.Text)).ToString(); 
        }

        private void onResistance(object sender, RoutedEventArgs e)
        {
            if (isStringAnInteger(vBlock.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(iBlock.Text) == false)
            {
                return;
            }

            rBlock.Text = (Convert.ToDouble(vBlock.Text) / Convert.ToDouble(iBlock.Text)).ToString(); 

        }



    }
}
