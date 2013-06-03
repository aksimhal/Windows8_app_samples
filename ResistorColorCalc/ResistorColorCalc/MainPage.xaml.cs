/** Anish Simhal
 * Resistor Color Calculator 
 * 5-26-13
 * */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ResistorColorCalc
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public int toogleState = 0; //tolerance switch; 0 is 5%, 1 is 10% 
        //Brushes to fill in rectangles 
        SolidColorBrush silverBrush = new SolidColorBrush(Colors.Silver);
        SolidColorBrush goldBrush = new SolidColorBrush(Colors.Gold);
        SolidColorBrush blackBrush = new SolidColorBrush(Colors.Black);
        SolidColorBrush brownBrush = new SolidColorBrush(Colors.Brown);
        SolidColorBrush redBrush = new SolidColorBrush(Colors.Red);
        SolidColorBrush orangeBrush = new SolidColorBrush(Colors.Orange);
        SolidColorBrush yellowBrush = new SolidColorBrush(Colors.Yellow);
        SolidColorBrush greenBrush = new SolidColorBrush(Colors.Green);
        SolidColorBrush blueBrush = new SolidColorBrush(Colors.Blue);
        SolidColorBrush violetBrush = new SolidColorBrush(Colors.Violet);
        SolidColorBrush grayBrush = new SolidColorBrush(Colors.Gray);
        SolidColorBrush whiteBrush = new SolidColorBrush(Colors.White);

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


        /** Event Handler for when content in the input box is modified 
         * */
        private void onUserInput(object sender, TextChangedEventArgs e)
        {
            string userinput = userInput.Text.Trim();
            bool proceed = isStringAnInteger(userinput);
            if (proceed)
            {
                debugBlock.Text = "";
                selectThirdBox(userinput.Length); 

                selectColorBand(userinput[0], 0);
                if (userinput.Length == 1)
                {
                    secondColorLabel.Text = "Black";
                    secondBox.Fill = blackBrush;
                }
                else
                {
                    selectColorBand(userinput[1], 1);
                }

            }

        }

        public void selectThirdBox (int length) 
        {
            length--; 
            char charLength = length.ToString()[0];
            //debugBlock.Text = charLength.ToString();
            selectColorBand(charLength, 2);
        }

        /** Manipulates first two rectangle UI elements 
         * @param input Character to determine color 
         * @param pos Index of rectangle (starting at 1) 
         * */ 
        public void selectColorBand(char input, int pos)
        {
            switch (input)
            {
                case '0':
                if (pos == 0)
                    {
                        firstBox.Fill = blackBrush;
                        firstColorLabel.Text = "Black"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = blackBrush;
                        secondColorLabel.Text = "Black"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = blackBrush;
                        thirdColorLabel.Text = "Black";
                    }
                    break;
                case '1':
                    if (pos == 0)
                    {
                        firstBox.Fill = brownBrush;
                        firstColorLabel.Text = "Brown"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = brownBrush;
                        secondColorLabel.Text = "Brown"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = brownBrush;
                        thirdColorLabel.Text = "Brown";
                    }
                    
                    break;
                case '2': 
                    if (pos == 0)
                    {
                        firstBox.Fill = redBrush;
                        firstColorLabel.Text = "Red"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = redBrush;
                        secondColorLabel.Text = "Red"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = redBrush;
                        thirdColorLabel.Text = "Red";
                    }
                    break;
                case '3':
                    if (pos == 0)
                    {
                        firstBox.Fill = orangeBrush;
                        firstColorLabel.Text = "Orange"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = orangeBrush;
                        secondColorLabel.Text = "Orange"; 
                    }
                    if (pos == 1)
                    {
                        thirdBox.Fill = orangeBrush;
                        thirdColorLabel.Text = "Orange";
                    }
                    break;
                case '4':
                    if (pos == 0)
                    {
                        firstBox.Fill = yellowBrush;
                        firstColorLabel.Text = "Yellow"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = yellowBrush;
                        secondColorLabel.Text = "Yellow"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = yellowBrush;
                        thirdColorLabel.Text = "Yellow";
                    }
                    break;
                case '5':
                    if (pos == 0)
                    {
                        firstBox.Fill = greenBrush;
                        firstColorLabel.Text = "Green"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = greenBrush;
                        secondColorLabel.Text = "Green"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = greenBrush;
                        thirdColorLabel.Text = "Green";
                    }
                    break;
                case '6':
                    if (pos == 0)
                    {
                        firstBox.Fill = blueBrush;
                        firstColorLabel.Text = "Blue"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = blueBrush;
                        secondColorLabel.Text = "Blue"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = blueBrush;
                        thirdColorLabel.Text = "Blue";
                    }
                    break;
                case '7':
                    if (pos == 0)
                    {
                        firstBox.Fill = violetBrush;
                        firstColorLabel.Text = "Violet"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = violetBrush;
                        secondColorLabel.Text = "Violet"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = violetBrush;
                        thirdColorLabel.Text = "Violet";
                    }
                    break;
                case '8':
                    if (pos == 0)
                    {
                        firstBox.Fill = grayBrush;
                        firstColorLabel.Text = "Gray"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = grayBrush;
                        secondColorLabel.Text = "Gray"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = grayBrush;
                        thirdColorLabel.Text = "Gray";
                    }
                    break;
                case '9':
                    if (pos == 0)
                    {
                        firstBox.Fill = whiteBrush;
                        firstColorLabel.Text = "White"; 
                    }
                    if (pos == 1)
                    {
                        secondBox.Fill = whiteBrush;
                        secondColorLabel.Text = "White"; 
                    }
                    if (pos == 2)
                    {
                        thirdBox.Fill = whiteBrush;
                        thirdColorLabel.Text = "White";
                    }
                    break;
                
            }
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


        /** EventHandler for when a toggle is selected.  
         * 'toogleState holds the previous state
         * 0 --> 5% ; 1 --> 10%
         * */
        private void togglePress(object sender, RoutedEventArgs e)
        {
            if (toogleState == 0)
            {
                toleranceBox.Fill = silverBrush;
                toleranceColorLabel.Text = "Silver";
                toogleState = 1;
            }
            else
            {
                toleranceBox.Fill = goldBrush;
                toleranceColorLabel.Text = "Gold";
                toogleState = 0;
            }

        }





    }
}
