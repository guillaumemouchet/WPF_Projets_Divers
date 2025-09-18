using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media;

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        private MarkType[] mResults;

        /// <summary>
        /// Player 1 is Cross (true) and player 2 is Circle (false)
        /// </summary>
        private bool mPlayer1Turn;
        private bool mGameEnded;
        #endregion

        #region Constructor
        /// <summary>
        /// Default constuctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion


        private void NewGame()
        {
            mResults = new MarkType[9]; //Create a empty array full of Free.
            for (var i = 0; i < mResults.Length; i++)
            {
                mResults[i] = MarkType.Free;         
            }

            //Make player 1 the first player
            mPlayer1Turn = true;

            //Iterate all button on the Grid
            Container.Children.Cast<Button>().ToList().ForEach(btn => { 

                //Change background, forground and default value
                btn.Content = String.Empty;
                btn.Background = Brushes.White;
                btn.Foreground = Brushes.Blue;
            });

            mGameEnded = false;

        }

        /// <summary>
        /// andles a button clieck event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Start a newGame if old was was finished
            if(mGameEnded)
            {
                NewGame();
                return;
            }

            //Cast the sender as a button
            Button button = (Button)sender;

            //Find buttons in an Array
            int column = Grid.GetColumn(button);
            int row = Grid.GetRow(button);

            int index = column + (3 * row);


            //Cell already used, don't do anything.
            if (mResults[index]!=MarkType.Free)
            {
                return;
            }

            //Change the cell value
            mResults[index] = mPlayer1Turn ? MarkType.Cross : MarkType.Circle;
            button.Content = mPlayer1Turn ? "X" : "O";

            //Change Color type
            if(!mPlayer1Turn)
            {
                button.Foreground = Brushes.Red;
            }

                mPlayer1Turn ^= true; //Bit invertor

            //Check for a Winner
            CheckForWinner();
        }


        /// <summary>
        /// Check for a Winner in 3 ligne strait or diagonale
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void CheckForWinner()
        {
            //Check could be optimised if button where stored in a grid

            #region Horizontal win
            //Check for horizontal wins
            //Row 0
            // Its not free and                 This checks thoses are all the same
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[1] & mResults[2]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button0_0.Background =Button1_0.Background = Button2_0.Background = Brushes.Green;
            }

            //Row 1
            // Its not free and                 This checks thoses are all the same
            if (mResults[3] != MarkType.Free && (mResults[3] & mResults[4] & mResults[5]) == mResults[3])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;
            }


            //Row 2
            // Its not free and                 This checks thoses are all the same
            if (mResults[6] != MarkType.Free && (mResults[6] & mResults[7] & mResults[8]) == mResults[6])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion

            #region Vertical win
            //Check for Vertical wins
            //Column 0
            // Its not free and                 This checks thoses are all the same
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[3] & mResults[6]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;
            }
            //Column 1
            // Its not free and                 This checks thoses are all the same
            if (mResults[1] != MarkType.Free && (mResults[1] & mResults[4] & mResults[7]) == mResults[1])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;
            }
            //Column 2
            // Its not free and                 This checks thoses are all the same
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[5] & mResults[8]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;
            }
            #endregion

            #region Diagonals win
            //Check for Diaganals wins
            //Diag 0
            // Its not free and                 This checks thoses are all the same
            if (mResults[0] != MarkType.Free && (mResults[0] & mResults[4] & mResults[8]) == mResults[0])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;
            }

            //Diag 1
            // Its not free and                 This checks thoses are all the same
            if (mResults[2] != MarkType.Free && (mResults[2] & mResults[4] & mResults[6]) == mResults[2])
            {
                mGameEnded = true;

                //Highlight the winning cells
                Button2_0.Background = Button1_1.Background = Button0_2.Background = Brushes.Green;
            }
            #endregion
            
            if (!mResults.Any(f => f == MarkType.Free) && !mGameEnded) //No space left to play
            {
                //Game is a draw
                mGameEnded = true;

                // Show its a draw
                Container.Children.Cast<Button>().ToList().ForEach(btn => {

                    //Change background
                    btn.Background = Brushes.Orange;
                });
            }

           

           
        }
    }
}