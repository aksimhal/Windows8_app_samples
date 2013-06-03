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

namespace USATime
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


        private void cCheck(double c, string zone)
        {
            outputBlock.Text = c.ToString(); 

            bool flag = false; 
            if (c <= 0)
            {
                cstHour.Text = (c + 12).ToString();
                flag = true; 
            }
            else if (c >= 13)
            {
                cstHour.Text = (c - 12).ToString();
                flag = true;
            }
            else
            {
                cstHour.Text = c.ToString();
                cstZone.Text = zone; 
            }

            if (flag) 
            {
                if (cstZone.Text.Equals(zone))
                {
                    cstZone.Text = "AM"; 
                }
                else {
                    cstZone.Text = "PM"; 
                }
            }


        }

        private void onEstHour(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(estHour.Text))
            {
                double time = Convert.ToDouble(estHour.Text);
                cCheck(time - 1, estZone.Text); 
                //cstHour.Text = (time - 1).ToString();
                mstHour.Text = (time - 2).ToString();
                pstHour.Text = (time - 3).ToString();
                astHour.Text = (time - 4).ToString();
                hstHour.Text = (time - 6).ToString(); 
            }
        }

        private void onCstHour(object sender, TextChangedEventArgs e)
        {

        }

        private void onMstHour(object sender, TextChangedEventArgs e)
        {

        }

        private void onPstHour(object sender, TextChangedEventArgs e)
        {

        }

        private void onAstHour(object sender, TextChangedEventArgs e)
        {
           
        }

        private void onHstHour(object sender, TextChangedEventArgs e)
        {

        }

        private void onAMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(aMin.Text))
            {
                bMin.Text = aMin.Text;
                cMin.Text = aMin.Text;
                dMin.Text = aMin.Text;
                eMin.Text = aMin.Text;
                fMin.Text = aMin.Text;
            }

        }

        private void OnBMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(bMin.Text))
            {
                aMin.Text = bMin.Text;
                cMin.Text = bMin.Text;
                dMin.Text = bMin.Text;
                eMin.Text = bMin.Text;
                fMin.Text = bMin.Text;
            }
        }

        private void OnCMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(cMin.Text))
            {
                aMin.Text = cMin.Text;
                bMin.Text = cMin.Text;
                dMin.Text = cMin.Text;
                eMin.Text = cMin.Text;
                fMin.Text = cMin.Text;
            }
        }

        private void onDMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(dMin.Text))
            {
                aMin.Text = dMin.Text;
                cMin.Text = dMin.Text;
                bMin.Text = dMin.Text;
                eMin.Text = dMin.Text;
                fMin.Text = dMin.Text;
            }
        }

        private void onEMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(eMin.Text))
            {
                aMin.Text = eMin.Text;
                cMin.Text = eMin.Text;
                dMin.Text = eMin.Text;
                bMin.Text = eMin.Text;
                fMin.Text = eMin.Text;
            }
        }

        private void onFMin(object sender, TextChangedEventArgs e)
        {
            if (isStringAnInteger(fMin.Text))
            {
                aMin.Text = fMin.Text;
                cMin.Text = fMin.Text;
                dMin.Text = fMin.Text;
                eMin.Text = fMin.Text;
                bMin.Text = fMin.Text;
            }
        }


    }
}
