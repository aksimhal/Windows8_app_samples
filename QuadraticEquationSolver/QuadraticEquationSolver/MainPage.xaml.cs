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

namespace QuadraticEquationSolver
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
                    outputBlock.Text = "Invalid Input, please enter an integer";
                    result = false;
                }
            }
            return result;
        }

        public void quadraticSolver()
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
           
             //Calculating a discriminant/
            double d = Convert.ToDouble(bInput.Text) * Convert.ToDouble(bInput.Text) - 4 * Convert.ToDouble(aInput.Text) * Convert.ToDouble(cInput.Text);
            double x1 = 0; double x2 = 0; 
            if (d == 0)
            {
                x1 = x2 = -(Convert.ToDouble(bInput.Text)) / (2 * Convert.ToDouble(aInput.Text));
                outputBlock.Text = "The only solution is x = " + x1.ToString();

            }
            else if (d < 0) //If d<0, no solutions are possible/
            { 
               outputBlock.Text = "There are no possible solutions";
               
            }
            else //If d>0, there are two possible solutions/
            {
                x1 = (-(Convert.ToDouble(bInput.Text)) - Math.Sqrt(d)) / (2 * Convert.ToDouble(aInput.Text));
                x2 = (-(Convert.ToDouble(bInput.Text)) + Math.Sqrt(d)) / (2 * Convert.ToDouble(aInput.Text));
                outputBlock.Text = "x = " + x1.ToString() + " and x = " + x2.ToString();
                
            }

        }

        private void onAInput(object sender, TextChangedEventArgs e)
        {
            quadraticSolver(); 
        }

        private void onBInput(object sender, TextChangedEventArgs e)
        {
            quadraticSolver(); 
        }

        private void onCInput(object sender, TextChangedEventArgs e)
        {
            quadraticSolver(); 
        }




    }
}
