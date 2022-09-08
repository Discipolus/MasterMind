using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MasterMind.objects;

namespace MasterMind
{

    public partial class form_MasterMind : Form
    {
        public static readonly int AnzahlFelder = 4;
        private Engine eng;

        #region initializing playing field
        public form_MasterMind()
        {
            InitializeComponent();
            InitialiseButtonsAndPanels();
        }
        private void InitialiseButtonsAndPanels()
        {
            for (int i = 0; i < 12; i++)
            {
                int ypos = 20 + 30 * i;
                int xpos = 20;
                int xDiffButton = 5 + PlayButton.Groesse.Width;
                Point[] panelpositionen = {
                    new Point(20, ypos),
                    new Point(34, ypos),
                    new Point(20, 14+ypos),
                    new Point(34, 14+ypos)
                };
                for (int j = 0; j < AnzahlFelder; j++)
                {
                    PlayButton btn = new PlayButton("btn_" + i + "_" + j);
                    btn.MouseClick += new MouseEventHandler(this.btn_color_Click);
                    btn.Location = new Point(xpos + xDiffButton * j, ypos);
                    btn.BackColor = PlayButton.Farbreihenfolge[0];
                    this.gB_Spiel.Controls.Add(btn);                    

                    Panel panel = new Panel();
                    panel.Name = "p_" + i + "_" + j;
                    panel.Size = new Size(8, 8);
                    panel.Location = panelpositionen[j]; //j0 = (20, 20) j1 = (10, 30), j2 = (20, 
                    panel.BackColor = Color.RoyalBlue;
                    this.gB_hints.Controls.Add(panel);
                }
            }
            eng = new Engine();
            eng.StartGame();
            foreach (PlayButton b in gB_Spiel.Controls)
            {
                if (b.Name.Contains("btn_0_"))
                {
                    b.Enabled = true;
                }
            }
            gB_Spiel.Controls[0].Refresh();
        }
        #endregion

        #region game control
        private void Win(KeyValuePair<int, List<PlayButton>> activeButtons)
        {
            EndGame(activeButtons, true);
        }
        private void Loose(KeyValuePair<int, List<PlayButton>> activeButtons)
        {
            EndGame(activeButtons, false);
        }
        private void NextRound(KeyValuePair<int, List<PlayButton>> activeButtons, Marker[] markers)
        {
            ActivateNextButtonLine(activeButtons);
        }
        private void EndGame(KeyValuePair<int, List<PlayButton>> activeButtons, bool won)
        {
            foreach (PlayButton Pb in activeButtons.Value)
            {
                Pb.Enabled = false;
            }
            DialogResult dr;
            if (won)
            {
                dr = MessageBox.Show("Nice one.", "New Game?", MessageBoxButtons.YesNo);
            }
            else
            {
                dr = MessageBox.Show("Weakness disgusts me.", "New Game?", MessageBoxButtons.YesNo);
            }             
            if (DialogResult.Yes == dr)
            {
                ResetGUI();
                eng = new Engine();
                eng.StartGame();
            }
            else
            {
                this.Close();
            }
        }
        #endregion

        #region event handling
        private void btn_check_Click(object sender, EventArgs e)
        {
            //get active Row of Buttons
            KeyValuePair<int, List<PlayButton>> activeButtons = GetActiveRow();

            //check if all available buttons were set with a color
            bool allButtonsSet = true;
            foreach (PlayButton b in activeButtons.Value)
            {
                if (!b.BackgroudColorSet())
                {
                    allButtonsSet = false;
                }
            }

            //Continue if all Buttons were set.
            if (allButtonsSet)
            {
                //get all guessed colors in right order
                Farben[] gerateneFarben = new Farben[AnzahlFelder];
                foreach (PlayButton pB in activeButtons.Value)
                {
                    gerateneFarben[helper.GetIndexFromName(pB.Name).X] = pB.GetFarbe();
                }

                //check if Code was correct
                //Marker[] m = Engine.CheckColors(eng.GetCorrectCode(), gerateneFarben);
                Marker[] m = eng.CheckRound(gerateneFarben);
                bool won = Engine.CheckWin(m);
                SetHintsPanels(activeButtons, m);
                if (won) //Wincondition: max 12 guesses and one guess was correct.
                {
                    Win(activeButtons);
                }
                else if (activeButtons.Key == 11) //Continue if not win.
                {
                    Loose(activeButtons);
                }
                else
                {
                    NextRound(activeButtons, m);
                }

            }
        }
        private void btn_color_Click(object sender, MouseEventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            PlayButton btn = (PlayButton)sender;
            if (me.Button == MouseButtons.Left)
            {
                btn.NextColor();
            }
            if (me.Button == MouseButtons.Right)
            {
                btn.PreviousColor();
            }
        }
        #endregion

        #region helper methods for GUI
        private void ResetGUI()
        { 
            gB_hints.Controls.Clear();
            gB_Spiel.Controls.Clear();
            InitialiseButtonsAndPanels();
        }        
        private void SetHintsPanels(KeyValuePair<int, List<PlayButton>> activeButtons, Marker[] marker)
        {
            Panel[] correspondingPanels = new Panel[AnzahlFelder];
            foreach (Panel p in gB_hints.Controls)
            {
                Point index = helper.GetIndexFromName(p.Name);
                if (index.Y == activeButtons.Key)
                {
                    correspondingPanels[index.X] = p;
                }
            }
            for (int i = 0; i < AnzahlFelder; i++)
            {
                correspondingPanels[i].BackColor = helper.GetColorFromMarker(marker[i]);
            }

        }
        private void ActivateNextButtonLine(KeyValuePair<int, List<PlayButton>> activeButtons)
        {
            foreach (PlayButton pB in activeButtons.Value)
            {
                pB.Enabled = false;
            }
            foreach (PlayButton pB in gB_Spiel.Controls)
            {
                Point index = helper.GetIndexFromName(pB.Name);
                if (index.Y == activeButtons.Key+1)
                {
                    pB.Enabled = true;
                }
            }
        }        
        private KeyValuePair<int, List<PlayButton>> GetActiveRow()
        {
            List<PlayButton> activeButtons = new List<PlayButton>();
            int index = -1;
            for (int i = 0; i < gB_Spiel.Controls.Count; i++)// Button b in gB_Spiel.Controls)
            {
                if (gB_Spiel.Controls[i].GetType().Equals(typeof(PlayButton)))
                {
                    PlayButton activeB = (PlayButton)gB_Spiel.Controls[i];
                    if (activeB.Enabled)
                    {
                        activeButtons.Add(activeB);
                        try
                        {
                            index = Convert.ToInt32(activeB.Name.Split('_')[1]);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Die aktive Zeile konnte nicht ermittelt werden.");
                            Console.WriteLine(ex.Message);
                            return new KeyValuePair<int, List<PlayButton>>();
                        }
                    }
                }
            }
            return new KeyValuePair<int, List<PlayButton>>(index, activeButtons);
        }
        #endregion
    }
}

