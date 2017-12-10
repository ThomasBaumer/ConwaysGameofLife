using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace GameOfLife
{
    /// <summary>
    /// The Game of Life view and controller.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Stores the "world" of Game of Life in a 2d Boolean array.
        /// </summary>
        private Boolean[,] space;

        /// <summary>
        /// The label which contains the output of the program.
        /// </summary>
        private Label displayArea;

        /// <summary>
        /// The time for automatic ticking.
        /// </summary>
        private Timer timer;

        /// <summary>
        /// Main entrance of the Game of Life form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            start();
        }

        /// <summary>
        /// Triggers the setup and prints the initial space.
        /// </summary>
        private void start()
        {
            setup(GameConfig.Default.rows, GameConfig.Default.cols);
            printSpace(true);
        }

        /// <summary>
        /// Setup of the game. 
        /// Defines and fills the space with random values.
        /// Setup of the display area.
        /// </summary>
        /// <param name="rows">The size of rows which the space will get.</param>
        /// <param name="columns">The size of cols which the space will get.</param>
        private void setup(int rows, int columns)
        {
            //setup space
            space = new Boolean[rows, columns];
            randomizeSpace();

            //setup the area where the output will be shown.
            Control control = this.Controls["LabelOutput"];
            displayArea = (Label)control;
        }

        /// <summary>
        /// Fills the values of the space array with random values.
        /// </summary>
        private void randomizeSpace()
        {
            //Built in random generator
            Random random = new Random();

            for (int rows=0; rows<space.GetLength(0); rows++)
            {
                for(int cols=0; cols<space.GetLength(1); cols++)
                {
                    //decision
                    if (random.NextDouble() > 0.5)
                    {
                        space[rows, cols] = true;
                    }
                }
            }
        }

        /// <summary>
        /// A method for printing out the space. 
        /// If the game is over (nothing changes anymore) the changed parameter has to be false and a 'game is closed' tag will be printed.
        /// It also prints out on the console.
        /// </summary>
        /// <param name="changed">Decides wheter the endscreen or the next generation will be shown.</param>
        private void printSpace(Boolean changed)
        {
            String output = "";
            if (changed)
            {
                for (int rows = 0; rows < space.GetLength(0); rows++)
                {
                    String row = "";
                    for (int cols = 0; cols < space.GetLength(1); cols++)
                    {
                        String token = "";
                        if (space[rows, cols])
                        {
                            //"X"
                            token = Strings.Default.tokenPositve;
                        }
                        else
                        {
                            //"O"
                            token = Strings.Default.tokenNegative;
                        }
                        //" | "
                        row = row + Strings.Default.separator + token;
                    }
                    output = output + " \n" + row + Strings.Default.separator;
                }
            }
            else
            {
                if (timer != null)
                {
                    //stop auto-tick
                    timer.Stop();
                }
                output = "The god was bored. He left.";
            }

            //write the output
            displayArea.Text = output;
            Console.WriteLine(output);
        }

        /// <summary>
        /// Updates the alive status of the space and returns whether it changed by updating or not.
        /// </summary>
        /// <returns>Returns whether the space changed during the update.</returns>
        private Boolean updateSpace()
        {
            //clone
            Boolean[,] outputSpace = space.Clone() as Boolean[,];

            //iterate over every cell and decide its fate
            for (int rows = 0; rows < space.GetLength(0); rows++)
            {
                for (int cols = 0; cols < space.GetLength(1); cols++)
                {
                    //updates the alive status of the specific cell
                    outputSpace[rows, cols] = playGod(rows, cols);
                }
            }

            //a token for deciding whether the space changed
            Boolean equal =
                space.Rank == outputSpace.Rank &&
                Enumerable.Range(0, space.Rank).All(dimension => space.GetLength(dimension) == outputSpace.GetLength(dimension)) &&
                space.Cast<Boolean>().SequenceEqual(outputSpace.Cast<Boolean>());

            //returns whether the space changed
            if (equal)
            {
                return false;
            } else
            {
                space = outputSpace;
                return true;
            }
            
        }

        /// <summary>
        /// Decides the fate of a single cell and returns true for alive or false for dead.
        /// </summary>
        /// <param name="row">Defines the row coordinate of the current cell.</param>
        /// <param name="col">Defines the column coordinate of the current cell.</param>
        /// <returns>true for alive and false for dead</returns>
        private Boolean playGod(int row, int col)
        {
            int neighboursAlive = 0;
            int shiftRow = 0;
            int shiftCol = 0;

            //check in every direction


            //--------------------------------------
            // up, down, left, right
            //left
            shiftCol = col - 1;
            if (shiftCol == -1)
            {
                shiftCol = space.GetLength(1)-1;
            }
            if (space[row, shiftCol])
            {
                neighboursAlive++;
            }
            //right
            shiftCol = col + 1;
            if (shiftCol == space.GetLength(1))
            {
                shiftCol = 0;
            }
            if (space[row, shiftCol])
            {
                neighboursAlive++;
            }
            //up
            shiftRow = row - 1;
            if (shiftRow == -1)
            {
                shiftRow = space.GetLength(0)-1;
            }
            if (space[shiftRow, col])
            {
                neighboursAlive++;
            }
            //down
            shiftRow = row + 1;
            if (shiftRow == space.GetLength(0))
            {
                shiftRow = 0;
            }
            if (space[shiftRow, col])
            {
                neighboursAlive++;
            }

            //------------------------------------
            //left up, left down, right up, right down
            //left up
            shiftCol = col - 1; //left
            shiftRow = row - 1; //up
            if (shiftCol == -1)
            {
                shiftCol = space.GetLength(1) - 1;
            }
            if (shiftRow == -1)
            {
                shiftRow = space.GetLength(0) - 1;
            }
            if (space[shiftRow, shiftCol])
            {
                neighboursAlive++;
            }

            //left down
            shiftCol = col - 1; //left
            shiftRow = row + 1; //down
            if (shiftCol == -1)
            {
                shiftCol = space.GetLength(1) - 1;
            }
            if (shiftRow == space.GetLength(0))
            {
                shiftRow = 0;
            }
            if (space[shiftRow, shiftCol])
            {
                neighboursAlive++;
            }

            //right up
            shiftCol = col + 1; //right
            shiftRow = row - 1; //up
            if (shiftCol == space.GetLength(1))
            {
                shiftCol = 0;
            }
            if (shiftRow == -1)
            {
                shiftRow = space.GetLength(0) - 1;
            }
            if (space[shiftRow, shiftCol])
            {
                neighboursAlive++;
            }

            //right down
            shiftCol = col + 1; //right
            shiftRow = row + 1; //down
            if (shiftCol == space.GetLength(1))
            {
                shiftCol = 0;
            }
            if (shiftRow == space.GetLength(0))
            {
                shiftRow = 0;
            }
            if (space[shiftRow, shiftCol])
            {
                neighboursAlive++;
            }

            //check the state and play god
            if (space[row, col]) //init state "alive"
            {
                if (neighboursAlive < 2)
                {
                    //kill this cell, too few friends :( ...
                    return false;
                }
                else if (neighboursAlive == 2 || neighboursAlive == 3)
                {
                    //stays alive (next line is for readablilty, actually not neccessary)
                    return true;
                }
                else if (neighboursAlive > 3)
                {
                    //kill because of overpopulation
                    return false;
                } 
                else
                {
                    //don't change a thing
                    return space[row, col];
                }
            }
            else //init state "dead"
            {
                if (neighboursAlive == 3) 
                {
                    //resurrect that cell
                    return true;
                }
                else
                {
                    //don't change a thing
                    return space[row, col];
                }
            }
        }


        //--------------------------------------------------
        // Methods for handling the buttons are below.
        //--------------------------------------------------


        /// <summary>
        /// Handles the event if the "Tick" button was clicked.
        /// Updates the space array and prints out the solution.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void BTNTick_Click(object sender, EventArgs e)
        {
            Boolean changed = updateSpace();
            printSpace(changed);
        }

        /// <summary>
        /// Handles the event if the "Auto Tick" button was clicked.
        /// Sets up the timer for ticking every two seconds.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void BTNAutoTick_Click(object sender, EventArgs e)
        {
            timer = new Timer();
            timer.Interval = 2000; // 2 seconds
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        /// <summary>
        /// Handles the event when a tick is neccessary.
        /// Performs like the "Tick" button.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void timer_Tick(object sender, EventArgs e)
        {
            BTNTick_Click(null, null);
        }

        /// <summary>
        /// Handles the event if the "Output" label was clicked.
        /// Performs like the ´"Tick" button.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void LabelOutput_Click(object sender, EventArgs e)
        {
            BTNTick_Click(null, null);
        }

        /// <summary>
        /// Handles the event if the "Reset" button was clicked.
        /// Resets the space, fills in new random values and prints the new space array.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void BTNReset_Click(object sender, EventArgs e)
        {
            space = new Boolean[space.GetLength(0), space.GetLength(1)];
            randomizeSpace();
            printSpace(true);
        }

        /// <summary>
        /// Handles the event if the "Exit" button was clicked.
        /// Exits the program.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void BTNExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Handles the event if the "OK" button was clicked.
        /// Updates the size of the space according to the user input.
        /// Restarts the game.
        /// </summary>
        /// <param name="sender">Inherited</param>
        /// <param name="e">Inherited</param>
        private void BTNOk_Click(object sender, EventArgs e)
        {
            try
            {
                //get the control elements
                Control controlRow = this.Controls["CBRow"];
                Control controlCol = this.Controls["CBCol"];

                //cast the control elements to ComboBoxes
                ComboBox cbRow = (ComboBox)controlRow;
                ComboBox cbCol = (ComboBox)controlCol;

                //update the configuration of the space (rows and columns)
                GameConfig.Default.rows = Int32.Parse(cbRow.SelectedItem.ToString());
                GameConfig.Default.cols = Int32.Parse(cbCol.SelectedItem.ToString());

                start();
            }
            catch (Exception)
            {
                //something went wrong by getting the new size of the space
                Console.Out.WriteLine("Parsing error by ComboBox!");
            }
        }
    }
}
