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

namespace QuadraticEquationExpander
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




        /** Checks to see if input is valid 
         * @param input user given string
         * @return true if input is an integer, false otherwise
         * */
        public bool isStringAnInteger(string input)
        {
            bool result = true;
            if (input == "")
            {
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsDigit(input[i]) == false)
                {
                    debugBlock.Text = "Invalid Input, please enter an integer";
                    result = false;
                }
            }
            return result;
        }

        public void foilequation()
        {
            //Validate all inputs 
            if (isStringAnInteger(aInput.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(bInput.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(cInput.Text) == false)
            {
                return;
            }
            if (isStringAnInteger(dInput.Text) == false)
            {
                return;
            }

            double a = Convert.ToDouble(aInput.Text) * Convert.ToDouble(cInput.Text);
            double b = (Convert.ToDouble(aInput.Text) * Convert.ToDouble(dInput.Text)) + (Convert.ToDouble(bInput.Text) * Convert.ToDouble(cInput.Text));
            double c = Convert.ToDouble(bInput.Text) * Convert.ToDouble(dInput.Text);
            debugBlock.Text = ""; 
            aOuput.Text = a.ToString();
            bOutput.Text = b.ToString();
            cOutput.Text = c.ToString(); 


        }

        private void onAInput(object sender, TextChangedEventArgs e)
        {
            foilequation(); 
        }

        private void onBInput(object sender, TextChangedEventArgs e)
        {
            foilequation(); 
        }

        private void onCInput(object sender, TextChangedEventArgs e)
        {
            foilequation(); 
        }

        private void onDInput(object sender, TextChangedEventArgs e)
        {
            foilequation(); 
        }

    }
}
