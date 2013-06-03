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

namespace quotesTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //This is the class member which stores all the quotes.  Populated when the program reads the textfile
        public string[] lines; 
        //This function loads the main app page
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
        //reads a text file 
        public async void getfile()
        {
            //this should be the path where the text file is located
            //remember to add the text file to the solution explorer first
            var _Path = @"Assets\pickup.txt";
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;



            // acquire file
            var _File = await _Folder.GetFileAsync(_Path);
           
            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);
            //This string contains all the lines in the file 
            string allLinesInTheFile = _ReadThis;
            //This function parses the entire file. 
            parseString(allLinesInTheFile);

        }

        /** Parses input string into an array of lines
         * @param fullString
         * @return lineArray
         * */
        string[] parseString(string fullString)
        {
            //This function seperates the string by a delimeter
            //currently, delimeter is \n, which means it splits by the new line character 
            string[] lineArray = fullString.Split('\n');
            List<string> strings = new List<string>();

            foreach (string s in lineArray)
            {
                if (s.Trim() != "")
                    strings.Add(s);

            }
            lineArray = strings.ToArray();
            
            //populates a class member with all the lines 
            lines = lineArray;

            return lineArray;
        }

        //function callback for when the user taps the image 
        public void Button_Tapped_Spin(object sender, TappedRoutedEventArgs e)
        {
            TitleBox.Text = lines.Length.ToString(); 
            int num = randomNumber(lines.Length);
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
            result = rnd.Next(0, outerBound);
            return result;
        } 
    }
}
