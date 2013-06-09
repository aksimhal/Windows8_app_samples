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

namespace triviaTemplate
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        /* Contains all the lines read from the text file */ 
        public string[] lines;
        /* Contains all the questions */ 
        public string[] questions;
        /* Contains all the possible answers */ 
        public string[] possibleAnswers;
        /* Contains all the correct answers */ 
        public string[] answer;
        /*Contains the current position in the question array */ 
        public int currentState = 0;
        public int numCorrect = 0;
        public int numWrong = 0; 
        /* Contains the correct answer to increment the current state */ 
        public string theAnswer; 
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

        /** This function sets up a question for the user
         * */ 

        public void setUpQuestion()
        {
            int numofquestion = questions.Length;

            if (currentState >= numofquestion)
            {
                questionBlock.Text = "Game Over, thanks for playing!";
                return; 
            }

                questionBlock.Text = questions[currentState];
                q1Block.Text = possibleAnswers[currentState * 4 + 0];
                q2Block.Text = possibleAnswers[currentState * 4 + 1];
                q3Block.Text = possibleAnswers[currentState * 4 + 2];
                q4Block.Text = possibleAnswers[currentState * 4 + 3];

                theAnswer = answer[currentState];
                theAnswer = theAnswer.Trim();
                //debug.Text = theAnswer;
                //currentQuesNumBlock.Text = "Current Question #: " + (currentState + 1).ToString();
                numRight.Text = "Correct: " + numCorrect.ToString();
                numIncorrect.Text = "Wrong: " + numWrong.ToString(); 

        }

        /* This function splits up the lines read from a file into three categories: 
         * Questions
         * Possible Answers
         * Answers
         * */ 
        public void sortLines()
        {
            List<string> listQuestions = new List<string>();
            List<string> listAnswers = new List<string>();
            List<string> listAns = new List<string>();  

            for (int i = 0; i < lines.Length; i=i+6)
            {
                if (i % 6 == 0)
                {
                    listQuestions.Add(lines[i]);
                    listAnswers.Add(lines[i + 1]);
                    listAnswers.Add(lines[i + 2]);
                    listAnswers.Add(lines[i + 3]);
                    listAnswers.Add(lines[i + 4]);
                    listAns.Add(lines[i + 5]);
                }
                

            }
            questions = listQuestions.ToArray();
            possibleAnswers = listAnswers.ToArray();
            answer = listAns.ToArray();
            totalNumOfQ.Text = totalNumOfQ.Text + questions.Length.ToString(); 
            setUpQuestion(); 
        }

        /* Reads text file into one giant string 
         * */ 
        public async void getfile()
        {
            // settings
            var _Path = @"Assets\trivia.txt";
            var _Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;



            // acquire file
            var _File = await _Folder.GetFileAsync(_Path);
            
            // read content
            var _ReadThis = await Windows.Storage.FileIO.ReadTextAsync(_File);

            string pickupline = _ReadThis;
            parseString(pickupline);

        }

        /** Parses input string into an array of lines
         * @param fullString
         * @return lineArray
         * */
        string[] parseString(string fullString)
        {

            string[] lineArray = fullString.Split('\n');
            List<string> strings = new List<string>();

            foreach (string s in lineArray)
            {
                if (s.Trim() != "")
                    strings.Add(s);

            }
            lineArray = strings.ToArray();

            lines = lineArray;
            sortLines(); 
            return lineArray;
        }

        /* Callback from the first radio button
         * If this is the right option, the program tells the user and increments to the next state
         * */ 
        private void onQ1(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("1"))
            {
                questionStatusBlock.Text = "Good Job!";
                currentState++;
                setUpQuestion(); 
            }
            else
            {
                questionStatusBlock.Text = "Whoops, try again!"; 
            }

        }

        /** Callback from the second radio button
         * */ 
        private void onQ2(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("2"))
            {
                questionStatusBlock.Text = "Good Job!";
                currentState++;
                setUpQuestion(); 
            }
            else
            {
                questionStatusBlock.Text = "Whoops, try again!";
            }
        }

        private void onQ3(object sender, RoutedEventArgs e)
        {
            /** Callback from the third radio button
         * */ 
            if (theAnswer.Equals("3"))
            {
                questionStatusBlock.Text = "Good Job!";
                currentState++;
                setUpQuestion(); 
            }
            else
            {
                questionStatusBlock.Text = "Whoops, try again!";
            }
        }

        /** Callback from the fourth radio button
         * */ 
        private void onQ4(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("4"))
            {
                questionStatusBlock.Text = "Good Job!";
                currentState++;
                setUpQuestion(); 
            }
            else
            {
                questionStatusBlock.Text = "Whoops, try again!";
            }
        }

        private void onOptionA(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("1"))
            {
                questionStatusBlock.Text = "Good Job!";
                numCorrect++; 
                
            }
            else
            {
                questionStatusBlock.Text = "Whoops, correct ans: " + theAnswer;
                numWrong++; 
            }

            currentState++;
            setUpQuestion();
        }

        private void onOptionB(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("2"))
            {
                questionStatusBlock.Text = "Good Job!";
                numCorrect++;

            }
            else
            {
                questionStatusBlock.Text = "Whoops, correct ans: " + theAnswer;
                numWrong++;
            }

            currentState++;
            setUpQuestion();
        }

        private void onOptionC(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("3"))
            {
                questionStatusBlock.Text = "Good Job!";
                numCorrect++;

            }
            else
            {
                questionStatusBlock.Text = "Whoops, correct ans: " + theAnswer;
                numWrong++;
            }

            currentState++;
            setUpQuestion();
        }

        private void onOptionD(object sender, RoutedEventArgs e)
        {
            if (theAnswer.Equals("4"))
            {
                questionStatusBlock.Text = "Good Job!";
                numCorrect++;

            }
            else
            {
                questionStatusBlock.Text = "Whoops, correct ans: " + theAnswer;
                numWrong++;
            }

            currentState++;
            setUpQuestion();
        }
    }
}
