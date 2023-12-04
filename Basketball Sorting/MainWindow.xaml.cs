using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Windows.Media.Animation;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace Basketball_Sorting {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        struct Players {
            public string Name;
            public string Team;
            public decimal Rookie;
            public decimal Rating;
            public decimal Games;
            public decimal MinutePG;
            public decimal PointsPG;
            public decimal ReboundsPG;
            public decimal AssistsPG;
            public decimal ShotPercentage;
            public decimal FreethrowPercentage;
            public decimal PointsPerMinutePrius;
            public decimal PointsPerMinuteGG;
            public decimal FreethrowPerA;
           
        }//end struct

        Players[] globalPlayersData;
        

        public MainWindow() {
           InitializeComponent();
        }

        #region EVENTS
        private void muiOpen_Click(object sender, RoutedEventArgs e) {

            //Create An Open Dialog 
            OpenFileDialog ofd = new OpenFileDialog();

            //Waiting For The User To Click
            bool fileSelected = (bool) ofd.ShowDialog();

            //The Things It Will Do When The User Make A Selection
            if (fileSelected) {

                //Make The ComboBox Visible When File Is Selected
                cmbAwards.Visibility = Visibility.Visible;

                //Store The Number Of Rocords Counted
                int record = RecordCount(ofd.FileName, true);

                //Store the PlayerData In The Struct
                globalPlayersData = ProcessPlayersData(ofd.FileName, record, true);

               
            }//end if 

        }//end event

        #region DROP BOX EVENTS    
        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e) {

            

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;

           

            //Get The Player That Has The More Points With Less Time
            Players priusAward = PriusAwardsData(globalPlayersData);

            //Display Player
            lblAwardName.Content = "Prius Award";
            txtName.Text                = priusAward.Name;
            txtTeam.Text                = priusAward.Team;
            txtRookie.Text              = priusAward.Rookie.ToString();
            txtRating.Text              = priusAward.Rating.ToString();
            txtGames.Text               = priusAward.Games.ToString();
            txtMinutePG.Text            = priusAward.MinutePG.ToString();
            txtPointsPG.Text            = priusAward.PointsPG.ToString();
            txtReboundsPG.Text          = priusAward.ReboundsPG.ToString();
            txtAssistsPG.Text           = priusAward.AssistsPG.ToString();
            txtShotPercentage.Text      = priusAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = priusAward.FreethrowPercentage.ToString();
        }//end event
        
        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e) {

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;

            Players gasGuzzlerAward = GasGuzzlerAward(globalPlayersData);
       
            lblAwardName.Content = "Gas Guzzler Award";
            txtName.Text = gasGuzzlerAward.Name;
            txtTeam.Text = gasGuzzlerAward.Team;
            txtRookie.Text = gasGuzzlerAward.Rookie.ToString();
            txtRating.Text = gasGuzzlerAward.Rating.ToString();
            txtGames.Text = gasGuzzlerAward.Games.ToString();
            txtMinutePG.Text = gasGuzzlerAward.MinutePG.ToString();
            txtPointsPG.Text = gasGuzzlerAward.PointsPG.ToString();
            txtReboundsPG.Text = gasGuzzlerAward.ReboundsPG.ToString();
            txtAssistsPG.Text = gasGuzzlerAward.AssistsPG.ToString();
            txtShotPercentage.Text = gasGuzzlerAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = gasGuzzlerAward.FreethrowPercentage.ToString();
        }//end event

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e)  {

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;

            Players foulTargetAward = FoulTargetAward(globalPlayersData);

            lblAwardName.Content = "Foul Target Award";
            txtName.Text = foulTargetAward.Name;
            txtTeam.Text = foulTargetAward.Team;
            txtRookie.Text = foulTargetAward.Rookie.ToString();
            txtRating.Text = foulTargetAward.Rating.ToString();
            txtGames.Text = foulTargetAward.Games.ToString();
            txtMinutePG.Text = foulTargetAward.MinutePG.ToString();
            txtPointsPG.Text = foulTargetAward.PointsPG.ToString();
            txtReboundsPG.Text = foulTargetAward.ReboundsPG.ToString();
            txtAssistsPG.Text = foulTargetAward.AssistsPG.ToString();
            txtShotPercentage.Text = foulTargetAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = foulTargetAward.FreethrowPercentage.ToString();

        }//end event
        
        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e) {
            //Makes the Slider Visible
            sldRecordCB.Visibility = Visibility.Visible;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Visible;
            string filePath = "C:\\Users\\MCA\\Desktop\\Basketball Sorting\\bin\\Debug\\net6.0-windows\\images\\Charle Brown\\BetterLuckNextTimeAwards.png";

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordCB.Value;
            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            Players charleBrownAward = CharleBrownAwards(globalPlayersData, sliderInt);

            lblAwardName.Content = "Charle Brown Award";
            LoadImage(filePath);
            txtName.Text = charleBrownAward.Name;
            txtTeam.Text = charleBrownAward.Team;
            txtRookie.Text = charleBrownAward.Rookie.ToString();
            txtRating.Text = charleBrownAward.Rating.ToString();
            txtGames.Text = charleBrownAward.Games.ToString();
            txtMinutePG.Text = charleBrownAward.MinutePG.ToString();
            txtPointsPG.Text = charleBrownAward.PointsPG.ToString();
            txtReboundsPG.Text = charleBrownAward.ReboundsPG.ToString();
            txtAssistsPG.Text = charleBrownAward.AssistsPG.ToString();
            txtShotPercentage.Text = charleBrownAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = charleBrownAward.FreethrowPercentage.ToString();
        }//end event
      
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e) {

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;

            Players onTheFenceAward = OnTheFenceAward(globalPlayersData);

            lblAwardName.Content = "On The Fence Award";
            txtName.Text = onTheFenceAward.Name;
            txtTeam.Text = onTheFenceAward.Team;
            txtRookie.Text = onTheFenceAward.Rookie.ToString();
            txtRating.Text = onTheFenceAward.Rating.ToString();
            txtGames.Text = onTheFenceAward.Games.ToString();
            txtMinutePG.Text = onTheFenceAward.MinutePG.ToString();
            txtPointsPG.Text = onTheFenceAward.PointsPG.ToString();
            txtReboundsPG.Text = onTheFenceAward.ReboundsPG.ToString();
            txtAssistsPG.Text = onTheFenceAward.AssistsPG.ToString();
            txtShotPercentage.Text = onTheFenceAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = onTheFenceAward.FreethrowPercentage.ToString();

        }//end event
        
        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e) {

            //Makes the Slider Visible
            sldRecordOA.Visibility = Visibility.Visible;
            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Visible;

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordOA.Value;

            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            lblAwardName.Content = "OverAchiever Award";

           OverachieverAward(globalPlayersData, sliderInt);

           

        }//end event

        private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e) {

            //Makes the Slider Visible
            sldRecordTU.Visibility = Visibility.Visible;
            sldRecordOA.Visibility= Visibility.Hidden;
            sldRecordCB.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Visible;
            string filePath = "C:\\Users\\MCA\\Desktop\\Basketball Sorting\\bin\\Debug\\net6.0-windows\\images\\Tiger Uppercut\\BasketballAwardWinners.png";

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordTU.Value;
            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();
            LoadImage(filePath);

            Players tigerUppercut = TigerUppercutAwards(globalPlayersData, sliderInt);

        }//end event

        private void ComboBoxItem_Selected_7(object sender, RoutedEventArgs e) {
          
            //Makes the Slider Visible
            sldRecordUA.Visibility = Visibility.Visible;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordCB.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Visible;

            txtPlayer.Visibility = Visibility.Hidden;

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordOA.Value;

            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            lblAwardName.Content = "Underachiever Award";

            UnderachieverAward(globalPlayersData, sliderInt);


        }//end event

        private void ComboBoxItem_Selected_8(object sender, RoutedEventArgs e) {

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;

            Players bangForYourBuckAward = BangForYourBuckAward(globalPlayersData);

            lblAwardName.Content = "Bang For Your Buck Award";
            txtName.Text = bangForYourBuckAward.Name;
            txtTeam.Text = bangForYourBuckAward.Team;
            txtRookie.Text = bangForYourBuckAward.Rookie.ToString();
            txtRating.Text = bangForYourBuckAward.Rating.ToString();
            txtGames.Text = bangForYourBuckAward.Games.ToString();
            txtMinutePG.Text = bangForYourBuckAward.MinutePG.ToString();
            txtPointsPG.Text = bangForYourBuckAward.PointsPG.ToString();
            txtReboundsPG.Text = bangForYourBuckAward.ReboundsPG.ToString();
            txtAssistsPG.Text = bangForYourBuckAward.AssistsPG.ToString();
            txtShotPercentage.Text = bangForYourBuckAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = bangForYourBuckAward.FreethrowPercentage.ToString();

        }//end event

        private void ComboBoxItem_Selected_9(object sender, RoutedEventArgs e) {

            sldRecordCB.Visibility = Visibility.Hidden;
            sldRecordOA.Visibility = Visibility.Hidden;
            sldRecordTU.Visibility = Visibility.Hidden;
            sldRecordUA.Visibility = Visibility.Hidden;
            txtPlayer.Visibility = Visibility.Hidden;
            lblPlayerIndex.Visibility = Visibility.Hidden;
            sldRecordGG.Visibility = Visibility.Visible;

            lblAwardName.Content = "Gordon Gekko Award";

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordGG.Value;
            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            GordonGekkoAward(globalPlayersData, sliderInt);

        }//end event

        #endregion

        #region SLIDER EVENTS
        private void sldRecordCB_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            //Makes the Slider Visible
            sldRecordCB.Visibility = Visibility.Visible;
            lblPlayerIndex.Visibility = Visibility.Visible;
           



                txtPlayer.Visibility = Visibility.Visible;

                //Create The Slider In Whole Numbers
                int sliderInt = (int)sldRecordCB.Value;
                //Display The Number Of The Slider
                lblPlayerIndex.Content = (sliderInt + 1).ToString();

            Players charleBrownAward = CharleBrownAwards(globalPlayersData, sliderInt);

            lblAwardName.Content = "Charle Brown Award";
            
            txtName.Text = charleBrownAward.Name;
            txtTeam.Text = charleBrownAward.Team;
            txtRookie.Text = charleBrownAward.Rookie.ToString();
            txtRating.Text = charleBrownAward.Rating.ToString();
            txtGames.Text = charleBrownAward.Games.ToString();
            txtMinutePG.Text = charleBrownAward.MinutePG.ToString();
            txtPointsPG.Text = charleBrownAward.PointsPG.ToString();
            txtReboundsPG.Text = charleBrownAward.ReboundsPG.ToString();
            txtAssistsPG.Text = charleBrownAward.AssistsPG.ToString();
            txtShotPercentage.Text = charleBrownAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = charleBrownAward.FreethrowPercentage.ToString();

        }//end event

        private void sldRecordTU_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            //Makes the Slider Visible
            sldRecordTU.Visibility = Visibility.Visible;
            lblPlayerIndex.Visibility = Visibility.Visible;
            sldRecordCB.Visibility = Visibility.Hidden;


            txtPlayer.Visibility = Visibility.Visible;

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordTU.Value;
            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            Players tigerUppercutAward = TigerUppercutAwards(globalPlayersData, sliderInt);

            lblAwardName.Content = "Tiger Uppercut Award";
            txtName.Text = tigerUppercutAward.Name;
            txtTeam.Text = tigerUppercutAward.Team;
            txtRookie.Text = tigerUppercutAward.Rookie.ToString();
            txtRating.Text = tigerUppercutAward.Rating.ToString();
            txtGames.Text = tigerUppercutAward.Games.ToString();
            txtMinutePG.Text = tigerUppercutAward.MinutePG.ToString();
            txtPointsPG.Text = tigerUppercutAward.PointsPG.ToString();
            txtReboundsPG.Text = tigerUppercutAward.ReboundsPG.ToString();
            txtAssistsPG.Text = tigerUppercutAward.AssistsPG.ToString();
            txtShotPercentage.Text = tigerUppercutAward.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = tigerUppercutAward.FreethrowPercentage.ToString();

        }//end event

        private void sldRecordGG_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            //Makes the Slider Visible
            sldRecordGG.Visibility = Visibility.Visible;
            lblPlayerIndex.Visibility = Visibility.Visible;
            txtPlayer.Visibility = Visibility.Visible;

            //Create The Slider In Whole Numbers

            int sliderInt = (int)sldRecordGG.Value;

            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            GordonGekkoAward(globalPlayersData, sliderInt);

        }//end event

        private void sldRecordOA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            //Makes the Slider Visible
            sldRecordOA.Visibility = Visibility.Visible;
            lblPlayerIndex.Visibility = Visibility.Visible;
            txtPlayer.Visibility = Visibility.Hidden;

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordOA.Value;

            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            lblAwardName.Content = "OverAchiever Award";

            OverachieverAward(globalPlayersData, sliderInt);

        }//end event

        private void sldRecordUA_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            //Makes the Slider Visible
            sldRecordUA.Visibility = Visibility.Visible;
            lblPlayerIndex.Visibility = Visibility.Visible;
            txtPlayer.Visibility = Visibility.Hidden;

            //Create The Slider In Whole Numbers
            int sliderInt = (int)sldRecordUA.Value;

            //Display The Number Of The Slider
            lblPlayerIndex.Content = (sliderInt + 1).ToString();

            lblAwardName.Content = "UnderAchiever Award";

            UnderachieverAward(globalPlayersData, sliderInt);

        }//end event
        #endregion
        

        #endregion

        #region FUNCTIONS

        int RecordCount(string filePath, bool skipHeader) {

            //Variable
            int record = 0;

            //Opening the File 
            StreamReader infile = new StreamReader(filePath);

            //If There Is A Header You Can Skip It
            if (skipHeader) {
                infile.ReadLine();
            }//end if

            //Will Make A Loop To Count The Records
            while(infile.EndOfStream == false) {
                infile.ReadLine();
                record++;
            }//end while

            //Close The File
            infile.Close();

            //Return The Numbers Of Records Counted
            return record;

        }//end function

        Players[] ProcessPlayersData(string filepath, int recordCount, bool skipHeader) {

            //Variables
            Players[] playersData = new Players[recordCount];
            int currentCount = 0;

            //Open The File 
            StreamReader infile = new StreamReader(filepath);

            if (skipHeader) { 
                infile.ReadLine();
            }//end if

            

            while(infile.EndOfStream == false && currentCount < recordCount) {
               
                //reading the record line
                string record = infile.ReadLine();
                string[] field = record.Split(",");


                playersData[currentCount].Name                = field[0];
                playersData[currentCount].Team                = field[1];
                playersData[currentCount].Rookie              = PlayerParse(field[2]);
                playersData[currentCount].Rating              = PlayerParse(field[3]);
                playersData[currentCount].Games               = PlayerParse(field[4]);
                playersData[currentCount].MinutePG            = PlayerParse(field[5]);
                playersData[currentCount].PointsPG            = PlayerParse(field[6]);
                playersData[currentCount].ReboundsPG          = PlayerParse(field[7]);
                playersData[currentCount].AssistsPG           = PlayerParse(field[8]);
                playersData[currentCount].ShotPercentage      = PlayerParse(field[9]);
                playersData[currentCount].FreethrowPercentage = PlayerParse(field[10]);

                currentCount++;

            }//end while

            //Close The File
            infile.Close();

            return playersData;

        }//end function

        #region PRIUS AWARD
        Players PriusAwardsData(Players[] globalPlayersData) { 

            for (int index = 0; index < globalPlayersData.GetLength(0); index++) {
                decimal pointsPerMin = 0;

                if (globalPlayersData[index].PointsPG != 0) {

                    pointsPerMin = (globalPlayersData[index].PointsPG * globalPlayersData[index].Games) / (globalPlayersData[index].MinutePG * globalPlayersData[index].Games);
                   
                    globalPlayersData[index].PointsPerMinutePrius = pointsPerMin;

                }//end if

            }//end for

            Players[] array = PriusBubbleSort(globalPlayersData);

            Players priusAward = array[0];

            return priusAward;
        }//end function

        Players[] PriusBubbleSort(Players[] globalPlayersData) {
            Players[] playerInfo = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = playerInfo.GetLength(0) - 1;
           

            while (swappedNumber) {

                swappedNumber = false;

                for (int index = 0; index < playerInfo.GetLength(0) - 1; index++) {

                        if ( globalPlayersData[index].PointsPerMinutePrius < globalPlayersData[index + 1].PointsPerMinutePrius) {
                            //Store The Right Value 
                            Players placeHolder = playerInfo[index + 1];

                            //Move The Left Value To The Right
                            playerInfo[index + 1] = playerInfo[index];

                            //Move PlaceHolder To Right
                            playerInfo[index] = placeHolder;

                            //To Loop Through Again
                            swappedNumber = true;


                        }//end if 

                    


                }//end for

                maxPosition = maxPosition - 1;

            }//end while

            

            return playerInfo;
        }//end function
        #endregion

        #region GAS GUZZLER AWARD
        Players GasGuzzlerAward(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.GetLength(0); index++) {
                decimal pointsPerMin = 0;

                if (globalPlayersData[index].PointsPG == 0) {

                    pointsPerMin =(globalPlayersData[index].MinutePG * globalPlayersData[index].Games);

                    globalPlayersData[index].PointsPerMinuteGG = pointsPerMin;

                }else if (globalPlayersData[index].PointsPG != 0) {

                    pointsPerMin = (globalPlayersData[index].PointsPG * globalPlayersData[index].Games) / (globalPlayersData[index].MinutePG * globalPlayersData[index].Games);

                    globalPlayersData[index].PointsPerMinuteGG = pointsPerMin;

                }
            }//end for 

            //Sorting Through The Bubble Sort Function
            Players[] array = GasGuzzlerBubbleSort(globalPlayersData);


            Players gasGuzzlerAward = array[0];

            return gasGuzzlerAward;
        }//end function

        Players[] GasGuzzlerBubbleSort(Players[] globalPlayersData) {
            Players[] playerInfo = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = playerInfo.GetLength(0) - 1;


            while (swappedNumber) {

                swappedNumber = false;

                for (int index = 0; index < playerInfo.GetLength(0) - 1; index++) {

                    if (globalPlayersData[index].PointsPerMinuteGG < globalPlayersData[index + 1].PointsPerMinuteGG) {
                        //Store The Right Value 
                        Players placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 




                }//end for

                maxPosition = maxPosition - 1;

            }//end while



            return playerInfo;
        }//end function
        #endregion

        #region FOUL TARGET AWARD
        Players FoulTargetAward(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.GetLength(0); index++) {
                decimal percentage = 0;

                if (globalPlayersData[index].FreethrowPercentage != 0 && globalPlayersData[index].ShotPercentage != 0) {

                    percentage = (globalPlayersData[index].FreethrowPercentage * globalPlayersData[index].Games) / (globalPlayersData[index].ShotPercentage * globalPlayersData[index].Games);

                    globalPlayersData[index].FreethrowPerA = percentage;
                    
                }else if (globalPlayersData[index].FreethrowPercentage == 0 && globalPlayersData[index].ShotPercentage == 0) {

                    percentage = globalPlayersData[index].FreethrowPercentage * globalPlayersData[index].Games;

                    globalPlayersData[index].FreethrowPerA = percentage;

                }//end if

            }//end for

            Players[] array =  FoulTargetBubbleSort(globalPlayersData);

            Players foulTargetAward = array[0];

            return foulTargetAward;
        }//end function

        Players[] FoulTargetBubbleSort(Players[] globalPlayersData) {

            //Variables 
            Players[] playerInfo = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = playerInfo.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0;  index < maxPosition; index++) {

                    if (globalPlayersData[index].FreethrowPerA < globalPlayersData[index + 1].FreethrowPerA) {
                        //Store The Right Value 
                        Players placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 




                }//end for 

                maxPosition--;
            }//end while 

            return playerInfo;
        }//end function
        #endregion

        #region OVER AND UNDER ACHIEVEMENT AWARDS
        void OverachieverAward(Players[] globalPlayersData, int playerIndex) {

            Players[] aboveAverage = new Players[globalPlayersData.Length];
            decimal sum = 0;
            decimal average;


            for (int index = 0; index < globalPlayersData.Length; index++) {
                sum += globalPlayersData[index].Rating;

            }//end for

            average = sum / (decimal)globalPlayersData.Length;

            Players[] array = AchieverBubbleSort(globalPlayersData);

            average = Math.Round(average, 2);

            for (int index = 0; index < globalPlayersData.Length; index++) {

                if (array[index].Rating > average) {
                    aboveAverage[index] = array[index];
                }//end if
            }//end for

            UpdateAwards(playerIndex, aboveAverage);

        }//end function

        void UnderachieverAward(Players[] globalPlayersData, int playerIndex) {

            Players[] belowAverage = new Players[globalPlayersData.Length];
            decimal sum = 0;
            decimal average;


            for (int index = 0; index < globalPlayersData.Length; index++) {
                sum += globalPlayersData[index].Rating;

            }//end for

            average = sum / (decimal)globalPlayersData.Length;

            Players[] array = AchieverBubbleSort(globalPlayersData);
            Array.Reverse(array);

             average = Math.Round(average, 2);

            for (int index = 0; index < globalPlayersData.Length; index++) {

                if (array[index].Rating < average) {
                    belowAverage[index] = array[index];
                }//end if
            }//end for

            UpdateAwards(playerIndex, belowAverage);

        }//end function

        Players[] AchieverBubbleSort(Players[] globalPlayersData) {

            Players[] playerInfo = globalPlayersData;
            
            bool swappedNumber = true;
            int maxPosition = playerInfo.Length - 1;
           
            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {


                  
                    if (globalPlayersData[index].Rating < globalPlayersData[index + 1].Rating) {
                        //Store The Right Value 
                        Players placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 




                }//end for 

                maxPosition--;
            }//end while 

           

            return playerInfo;
        }//end function
        #endregion

        #region ON THE FENCE AWARD
        Players OnTheFenceAward(Players[] globalPlayersData) {

            Players[] array = OnTheFenceBubbleSort(globalPlayersData);

            Players onTheFenceAward = array[219];

            return onTheFenceAward;


        }//end function

        Players[] OnTheFenceBubbleSort(Players[] globalPlayersData) {

            Players[] playerInfo = globalPlayersData;
            int maxPosition = playerInfo.Length - 1;
            bool swappedNumber = true;




            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].Rating < globalPlayersData[index + 1].Rating) {
                        //Store The Right Value 
                        Players placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }// end for  
                maxPosition--;
            }//end while

            return playerInfo;
        }//end function

        #endregion

        #region BANG FOR YOUR BUCK
        Players BangForYourBuckAward(Players[] globalPlayersData) {

            Players[] rookies = new Players[globalPlayersData.Length];

            for (int index = 0; index < globalPlayersData.Length; index++) {

                if (globalPlayersData[index].Rookie == 1) {
                    rookies[index] = globalPlayersData[index];
                }//end if

            }//end for

            Players[] array = BangForYourBuckBubbleSort(rookies);

            Players bangForYourBuckAward = array[0];

            return bangForYourBuckAward;


        }//end function

        Players[] BangForYourBuckBubbleSort(Players[] rookies) {

            Players[] playerInfo = rookies;
            int maxPosition = playerInfo.Length - 1;
            bool swappedNumber = true;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {


                    //Needs To Be Finished
                    if ((playerInfo[index].MinutePG * playerInfo[index].Games) < (playerInfo[index + 1].MinutePG * playerInfo[index + 1].Games)) {
                        //Store The Right Value 
                        Players placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 




                }//end for 

                maxPosition--;
            }//end while 

            return playerInfo;
        }//end function
        #endregion

        #region GORDON GEKKO AWARD

        void GordonGekkoAward(Players[] globalPlayersData, int counter) {

            //NE - BOS, BKN, NY, PHI, TOR
            //NW - MIN, OKC, POR, DEN, UTA
            //SE - CHA, ATL, MIA, ORL, WAS 
            //SW - HOU, DAL, SA, MEM, NO


            //CENTRAL - CHI, CLE, DET, IND, MIL
            //PACIFIC - GS, LAC, LAL, PHX, SAC

            string[] northERegion = { "BOS", "BKN", "NY", "PHI", "TOR" };
            string[] northWRegion = { "MIN", "OKC", "POR", "DEN", "UTA" };
            string[] southERegion = { "CHA", "ATL", "MIA", "ORL", "WAS" };
            string[] southWRegion = { "HOU", "DAL", "SA", "MEM", "NO" };
            string[] Centrl       = { "CHI", "CLE", "DET", "IND", "MIL" };
            string[] Pacifc       = { "GS", "LAC", "LAL", "PHX", "SAC" };

            Players[] northE = new Players[globalPlayersData.Length];
            Players[] northW = new Players[globalPlayersData.Length]; 
            Players[] southE = new Players[globalPlayersData.Length];
            Players[] southW = new Players[globalPlayersData.Length];
            Players[] centrl = new Players[globalPlayersData.Length];
            Players[] pacifc = new Players[globalPlayersData.Length];

            decimal neSum = 0;
            decimal nwSum = 0;
            decimal seSum = 0;
            decimal swSum = 0;
            decimal ceSum = 0;
            decimal pfSum = 0;


            for (int index = 0; index < globalPlayersData.Length; index++) {

                if (northERegion.Contains(globalPlayersData[index].Team)) {
                     neSum += globalPlayersData[index].PointsPG;
                    northE[index] = globalPlayersData[index];

                } else if (northWRegion.Contains(globalPlayersData[index].Team)) {
                    nwSum += globalPlayersData[index].PointsPG;
                    northW[index] = globalPlayersData[index];

                } else if (southERegion.Contains(globalPlayersData[index].Team )) {
                    seSum += globalPlayersData[index].PointsPG;
                    southE[index] = globalPlayersData[index];

                } else if (southWRegion.Contains(globalPlayersData[index].Team)) {
                    swSum += globalPlayersData[index].PointsPG;
                    southW[index] = globalPlayersData[index];

                } else if (Centrl.Contains(globalPlayersData[index].Team)) {
                    ceSum += globalPlayersData[index].PointsPG;
                    centrl[index] = globalPlayersData[index];

                } else if (Pacifc.Contains(globalPlayersData[index].Team)) {
                    pfSum += globalPlayersData[index].PointsPG;
                    pacifc[index] = globalPlayersData[index];

                }//end if


            }//end for

            decimal[] pointsRegion = {neSum, nwSum, seSum, swSum, ceSum, pfSum};
            Players[] gordonGekkoAwards = new Players [globalPlayersData.Length];

           //Sorting Through The Bubble Sort Function
            decimal[] array = GordonGekkoBubbleSort(pointsRegion);

            
            if (array[0] == neSum) {
               gordonGekkoAwards = northE;
                txtPlayer.Text = "North East Region";
            }else if (array[0] == nwSum) {
                gordonGekkoAwards = northW;
                txtPlayer.Text = "North West Region";
            }else if (array[0] == seSum) {
                gordonGekkoAwards = southE;
                txtPlayer.Text = "South East Region";
            }else if (array[0] == swSum) {
                gordonGekkoAwards = southW;
                txtPlayer.Text = "South West Region";
            }else if (array[0] == ceSum) {
                gordonGekkoAwards = centrl;
                txtPlayer.Text = "Centrel Region";
            }else if (array[0] == pfSum) {
                gordonGekkoAwards = pacifc;
                txtPlayer.Text = "Pacific Region";
            }// end if

           


            UpdateAwards(counter, gordonGekkoAwards);
            

            
        }//end function

        decimal[] GordonGekkoBubbleSort(decimal[] points) {
            
            decimal[] playerInfo = points;
            bool swappedNumber = true;
            int maxPosition = points.GetLength(0) - 1;


            while (swappedNumber) {

                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (playerInfo[index] < playerInfo[index + 1]) {
                        //Store The Right Value 
                        decimal placeHolder = playerInfo[index + 1];

                        //Move The Left Value To The Right
                        playerInfo[index + 1] = playerInfo[index];

                        //Move PlaceHolder To Right
                        playerInfo[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 




                }//end for

                maxPosition = maxPosition - 1;

            }//end while


           

            return playerInfo;
        }//end function

        #endregion

        #region CHARLE BROWN AWARD
        Players CharleBrownAwards(Players[] globalPlayersData, int counter) {

           

            Players currentplayer = LeastRating(globalPlayersData);
         
            if(counter == 0) {
                currentplayer = LeastRating(globalPlayersData);
                txtPlayer.Text = "Least Rating";
            }else if (counter == 1) {
                currentplayer = LeastGames(globalPlayersData);
                txtPlayer.Text = "Least Games";
            }else if (counter == 2) {
                currentplayer = LeastMinutes(globalPlayersData);
                txtPlayer.Text = "Least Minutes";
            } else if(counter == 4) {
                currentplayer = LeastPoints(globalPlayersData);
                txtPlayer.Text = "Least Points";
            } else if(counter == 5) {
                currentplayer = LeastRebounds(globalPlayersData);
                txtPlayer.Text = "Least Rebounds";
            } else if(counter == 6) {
                currentplayer = LeastAssists(globalPlayersData);
                txtPlayer.Text = "Least Assists";
            } else if(counter == 7) {
                currentplayer =LeastShotPercentage(globalPlayersData);
                txtPlayer.Text = "Least Shot Percentage";
            } else if(counter == 8) {
                currentplayer = LeastFreethrowPercentage(globalPlayersData);
                txtPlayer.Text = "Least Freethrow Percentage";
            }




            

            return currentplayer; 
        
        }//end function
        #region Functions For Charle Brown
        Players LeastRating(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < array.GetLength(0) - 1; index++) {

                    if (globalPlayersData[index].Rating < globalPlayersData[index + 1].Rating) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  
            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastGames(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].Games == 0) {
                   
                    globalPlayersData[index].Games = 900000000;

                }//end if

            }//end for

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].Games < globalPlayersData[index + 1].Games) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].Games == 900000000) {

                    globalPlayersData[index].Games = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastMinutes(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].MinutePG == 0) {

                    globalPlayersData[index].MinutePG = 900000000;

                }//end if

            }//end for

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].MinutePG < globalPlayersData[index + 1].MinutePG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].MinutePG == 900000000) {

                    globalPlayersData[index].MinutePG = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastPoints(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].PointsPG == 0) {

                    globalPlayersData[index].PointsPG = 900000000;

                }//end if

            }//end for


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].PointsPG < globalPlayersData[index + 1].PointsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].PointsPG == 900000000) {

                    globalPlayersData[index].PointsPG = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastRebounds(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].ReboundsPG == 0) {

                    globalPlayersData[index].ReboundsPG = 900000000;

                }//end if

            }//end for


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].ReboundsPG < globalPlayersData[index + 1].ReboundsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].ReboundsPG == 900000000) {

                    globalPlayersData[index].ReboundsPG = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastAssists(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].AssistsPG == 0) {

                    globalPlayersData[index].AssistsPG = 900000000;

                }//end if

            }//end for


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].AssistsPG < globalPlayersData[index + 1].AssistsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].AssistsPG == 900000000) {

                    globalPlayersData[index].AssistsPG = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastShotPercentage(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].ShotPercentage == 0) {

                    globalPlayersData[index].ShotPercentage = 900000000;

                }//end if

            }//end for


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].ShotPercentage < globalPlayersData[index + 1].ShotPercentage) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].ShotPercentage == 900000000) {

                    globalPlayersData[index].ShotPercentage = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players LeastFreethrowPercentage(Players[] globalPlayersData) {

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].FreethrowPercentage == 0) {

                    globalPlayersData[index].FreethrowPercentage = 900000000;

                }//end if

            }//end for


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].FreethrowPercentage < globalPlayersData[index + 1].FreethrowPercentage) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            for (int index = 0; index < globalPlayersData.Length; index++) {
                if (globalPlayersData[index].FreethrowPercentage == 900000000) {

                    globalPlayersData[index].FreethrowPercentage = 0;

                }//end if

            }//end for

            Array.Reverse(array);
            Players playerInfo = array[0];

            return playerInfo;

        }//end function
        #endregion
        #endregion

        #region TIGER UPPERCUT AWARD
        Players TigerUppercutAwards(Players[] globalPlayersData, int counter) {



            Players currentplayer = BestRating(globalPlayersData);

            if (counter == 0) {
                currentplayer = BestRating(globalPlayersData);
                txtPlayer.Text = "Best Rating";
            } else if (counter == 1) {
                currentplayer = BestGames(globalPlayersData);
                txtPlayer.Text = "Best Games";
            } else if (counter == 2) {
                currentplayer = BestMinutes(globalPlayersData);
                txtPlayer.Text = "Best Minutes";
            } else if (counter == 4) {
                currentplayer = BestPoints(globalPlayersData);
                txtPlayer.Text = "Best Points";
            } else if (counter == 5) {
                currentplayer = BestRebounds(globalPlayersData);
                txtPlayer.Text = "Best Rebounds";
            } else if (counter == 6) {
                currentplayer = BestAssists(globalPlayersData);
                txtPlayer.Text = "Best Assists";
            } else if (counter == 7) {
                currentplayer = BestShotPercentage(globalPlayersData);
                txtPlayer.Text = "Best Shot Percentage";
            } else if (counter == 8) {
                currentplayer = BestFreethrowPercentage(globalPlayersData);
                txtPlayer.Text = "Best Freethrow Percentage";
            }//end if






            return currentplayer;

        }//end function
        #region Function For Tiger Uppercut
        Players BestRating(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < array.GetLength(0) - 1; index++) {

                    if (globalPlayersData[index].Rating < globalPlayersData[index + 1].Rating) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  
            
            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestGames(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].Games < globalPlayersData[index + 1].Games) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestMinutes(Players[] globalPlayersData) {


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].MinutePG < globalPlayersData[index + 1].MinutePG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestPoints(Players[] globalPlayersData) {


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].PointsPG < globalPlayersData[index + 1].PointsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestRebounds(Players[] globalPlayersData) {


            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].ReboundsPG < globalPlayersData[index + 1].ReboundsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestAssists(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].AssistsPG < globalPlayersData[index + 1].AssistsPG) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players  BestShotPercentage(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].ShotPercentage < globalPlayersData[index + 1].ShotPercentage) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        Players BestFreethrowPercentage(Players[] globalPlayersData) {

            //Variables 
            Players[] array = globalPlayersData;
            bool swappedNumber = true;
            int maxPosition = globalPlayersData.Length - 1;

            while (swappedNumber) {
                swappedNumber = false;

                for (int index = 0; index < maxPosition; index++) {

                    if (globalPlayersData[index].FreethrowPercentage < globalPlayersData[index + 1].FreethrowPercentage) {
                        //Store The Right Value 
                        Players placeHolder = array[index + 1];

                        //Move The Left Value To The Right
                        array[index + 1] = array[index];

                        //Move PlaceHolder To Right
                        array[index] = placeHolder;

                        //To Loop Through Again
                        swappedNumber = true;


                    }//end if 


                }//end for

                maxPosition--;
            }//end while  

            Players playerInfo = array[0];

            return playerInfo;

        }//end function

        #endregion
        #endregion


        void UpdateAwards(int playersIndex, Players[] achievements) {


            //Get the Global Data For The Player
           
            Players currentPlayerInfo = achievements[playersIndex];
            

            //Put The Labels And Data Together
            txtName.Text = currentPlayerInfo.Name;
            txtTeam.Text = currentPlayerInfo.Team;
            txtRookie.Text = currentPlayerInfo.Rookie.ToString();
            txtRating.Text = currentPlayerInfo.Rating.ToString();
            txtGames.Text = currentPlayerInfo.Games.ToString();
            txtMinutePG.Text = currentPlayerInfo.MinutePG.ToString();
            txtPointsPG.Text = currentPlayerInfo.PointsPG.ToString();
            txtReboundsPG.Text = currentPlayerInfo.ReboundsPG.ToString();
            txtAssistsPG.Text = currentPlayerInfo.AssistsPG.ToString();
            txtShotPercentage.Text = currentPlayerInfo.ShotPercentage.ToString();
            txtFreethrowPercentage.Text = currentPlayerInfo.FreethrowPercentage.ToString(); 

        }//end function

       public void LoadImage(string imageFilepath) {
       
            
            if (File.Exists(imageFilepath) == false) {
                return;
            }//end
       
            //Create The Bitmap
            BitmapImage bmpImage = new BitmapImage();
       
            //Set BitMap For Editing
            bmpImage.BeginInit();
            bmpImage.UriSource = new Uri(imageFilepath); //Load The Image
            bmpImage.EndInit();
       
            //Set The Source Of The Image Control To THe Bitmap
            imgMain.Source = bmpImage;
       
       }//end function
      
        decimal PlayerParse(string playerData) {
            decimal parsedValue = 0;
            bool parsed = false;

            parsed = decimal.TryParse((playerData), out parsedValue);

            return parsedValue;
        }//end function

        #endregion



    }//end class

}//end namespace
