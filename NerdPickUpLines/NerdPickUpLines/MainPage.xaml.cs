using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NerdPickUpLines
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            parseFile(); 
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
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

        private void Button_Tapped_Spin(object sender, TappedRoutedEventArgs e)
        {
            Tuple<int, int> result = SpinCalculator.run(8);
            spin(result.Item1);
        }

        /** Read a file, return an array of lines; reads every other line 
         * @param fileName Location of the file 
         * @param lineNum number of lines in the file 
         * @return array of lines 
         * */ 
        private string[] parseFile()
        {
            string[] lines = new string[5];
            //string wholeSet = 
            string fileName = @"Assets/pickup.txt";
            TitleBox.Text = "out1";
            //StreamReader reader = new StreamReader(fileName); 

            //var file = Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(fileName);
            //var stream =  file.OpenReadAsync();
            //var rdr = new StreamReader(stream.AsStream());

            //Task.Run(() =>
            //{
            //    var contents = rdr.ReadToEnd();
            //});
            
            
            //string file = line.ToString();
            TitleBox.Text = "t";
            getfile(); 
  
            return lines; 
        }

        /** Reads a file fron the "Assets" Folder 
        * @return a string of the entire file
        * */

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
            TitleBox.Text += _ReadThis;
        }
        
        
       
        
        /**
         * Returns a random number between 0 and the given value
         * @param outerBound Outer bound 
         * @return result Random Number 
         * */
        private int randomNumber(int outerBound)
        {
            int result = 0;
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
