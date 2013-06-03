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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NerdyPickUpLines
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public string[] lines; 

        public MainPage()
        {
            getfile();

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

        public async void getfile()
        {
            // settings
            //var _Name = "test.txt";
            // settings
            var _Path = @"Assets\pickup.txt";
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;



            // acquire file
            var _File = await _Folder.GetFileAsync(_Path);
            //Assert.IsNotNull(_File, "Acquire file");
            //message.Text += "Reading...";

            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
            //Assert.AreEqual(_WriteThis, _ReadThis, "Contents match");
            string pickupline = _ReadThis;
            parseString(pickupline); 

        }

        /** Parses input string into an array of lines
         * @param fullString
         * @return lineArray
         * */
        string[] parseString(string fullString)
        {
            //string[] lineArray = new string[50];
            string[] lineArray = fullString.Split('\n');
            List<string> strings = new List<string>();

            foreach (string s in lineArray)
            {
                if (s.Trim() != "")
                    strings.Add(s);
            
            }
            lineArray = strings.ToArray();

            lines = lineArray; 

            //TitleBox.Text = lineArray.Length.ToString();  

            //TitleBox.Text = fullString.Length.ToString();
            //TitleBox.Text = fullString.IndexOf('\n').ToString();
            //TitleBox.Text += fullString;
            return lineArray;
        }


        public void spin(int degrees)
        {
            DoubleAnimation d = new DoubleAnimation();
            d.From = 0;
            d.To = 120;
            d.Duration = new Duration(new TimeSpan(0, 0, 0, 0, 500));
            d.RepeatBehavior = new RepeatBehavior(1);

            TimelineCollection v = Storyboard1.Children;
            foreach (var vv in v)
            {
                DoubleAnimationUsingKeyFrames dauks = (DoubleAnimationUsingKeyFrames)vv;
                var v3 = dauks.KeyFrames[1].Value = degrees;
            }

            Storyboard1.Begin();
        }

        public void Button_Tapped_Spin(object sender, TappedRoutedEventArgs e)
        {
            Tuple<int, int> result = SpinCalculator.run(8);
            spin(result.Item1);
            int num = randomNumber(49);
            TitleBox.Text = lines[num]; 
        }

        /**
         * Returns a random number between 0 and the given value
         * @param outerBound Outer bound 
         * @return result Random Number 
         * */
        private int randomNumber(int outerBound)
        {
            int result = 0;
            Random rnd = new Random();
            result = rnd.Next(0, 49); 
            return result;
        } 

    }

    public class SpinCalculator
    {
        public static Tuple<int, int> run(int numDivisions)
        {
            Random rand = new Random();
            int beginningAngle = rand.Next(360);
            int rotations = rand.Next(1, 11);
            int finalAngle = beginningAngle + (360 * rotations);
            double anglePerDivision = 360 / numDivisions;
            double preciseDiv = beginningAngle / anglePerDivision;
            int divSelected = (int)preciseDiv;
            return Tuple.Create<int, int>(finalAngle, divSelected);
        }


    }

}
