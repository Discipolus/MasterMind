using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MasterMind.objects;


namespace MasterMind
{
    internal class Engine
    {
        private GameElement[,] playground = new GameElement[form_MasterMind.AnzahlFelder,12];
        private Farben[] correctOrder;
        private int currentRound;

        public void StartGame()
        {
            SetRandomCode();
            currentRound = 0;
            InitializePlayground();
        }
        public Farben[] GetCorrectCode()
        {
            return correctOrder;
        }        
        public static Marker[] CheckColors(Farben[] korrekterFarbcode, Farben[] geratenerFarbcode)
        {
            List<Marker> rueckgabeTemp = new List<Marker>();
            List<Farben> tempKorrFarbe = new List<Farben>();
            List<Farben> tempGeraFarbe = new List<Farben>();

            Marker[] rueckgabe = new Marker[4];

            //check black
            for (int i = 0; i < form_MasterMind.AnzahlFelder; i++)
            {
                tempKorrFarbe.Add(korrekterFarbcode[i]);
                tempGeraFarbe.Add(geratenerFarbcode[i]);
                if (korrekterFarbcode[i] == geratenerFarbcode[i])
                {
                    rueckgabeTemp.Add(Marker.black);
                    tempKorrFarbe.Remove(korrekterFarbcode[i]);
                    tempGeraFarbe.Remove(geratenerFarbcode[i]);
                }
            }

            //check whites
            foreach (Farben f in tempGeraFarbe)
            {
                if (tempKorrFarbe.Contains(f))
                {
                    rueckgabeTemp.Add(Marker.white);
                    tempKorrFarbe.Remove(f);                    
                }
            }

            //build return value
            for (int i = 0; i < rueckgabeTemp.Count; i++)
            {
                rueckgabe[i] = rueckgabeTemp[i];
            }
            return rueckgabe;
        }
        public static bool CheckWin(Marker[] marker)
        {
            if (marker.Contains(Marker.none) || marker.Contains(Marker.white))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Marker[] CheckRound(Farben[] guessedColorCode)
        {
            List<Marker> returnValue = new List<Marker>();
            List<Farben> tempCorrectCode = new List<Farben>();
            List<Farben> tempGuessedCode = new List<Farben>();

            Marker[] rueckgabe = new Marker[4];

            //check black
            for (int i = 0; i < form_MasterMind.AnzahlFelder; i++)
            {
                tempCorrectCode.Add(correctOrder[i]);
                tempGuessedCode.Add(guessedColorCode[i]);
                if (correctOrder[i] == guessedColorCode[i])
                {
                    returnValue.Add(Marker.black);
                    tempCorrectCode.Remove(correctOrder[i]);
                    tempGuessedCode.Remove(guessedColorCode[i]);
                }
            }

            //check whites
            foreach (Farben f in tempGuessedCode)
            {
                if (tempCorrectCode.Contains(f))
                {
                    returnValue.Add(Marker.white);
                    tempCorrectCode.Remove(f);
                }
            }

            //build return value
            for (int i = 0; i < returnValue.Count; i++)
            {
                rueckgabe[i] = returnValue[i];
            }
            return rueckgabe;
        }
        private void SetRandomCode()
        {
            correctOrder = new Farben[form_MasterMind.AnzahlFelder];
            //select random solution
            Array values = Enum.GetValues(typeof(Farben));
            Random rnd = new Random();
            for (int i = 0; i < form_MasterMind.AnzahlFelder; i++)
            {
                correctOrder[i] = (Farben)values.GetValue(rnd.Next(1, values.Length)); //dont choose "other" as random color.
            }
        }
        private void InitializePlayground()
        {
            for (int x = 0; x < form_MasterMind.AnzahlFelder; x++)
            {
                for (int y = 0; y < 12; y++)
                {
                    playground[x, y] = new GameElement(new Point(x, y));
                }
            }
        }
    }
}
