using System.Drawing;
using System;

namespace MasterMind.objects
{
    public static class helper
    {
        public static Point GetIndexFromName(string name)
        {
            Point rueckgabewert = new Point(-1, -1);
            string[] substrings = name.Split('_');
            try
            {
                rueckgabewert.X = Convert.ToInt32(substrings[2]);
                rueckgabewert.Y = Convert.ToInt32(substrings[1]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim bestimmen des Index eines PlayButtons: /n" + ex.Message);
            }
            return rueckgabewert;
        }
        public static Farben GetFarbeFromColor(Color c)
        {
            if (c == Color.Red)
            {
                return Farben.red;
            }
            else if (c == Color.Blue)
            {
                return Farben.blue;
            }
            else if (c == Color.Yellow)
            {
                return Farben.yellow;
            }
            else if (c == Color.Violet)
            {
                return Farben.violet;
            }
            else if (c == Color.Orange)
            {
                return Farben.orange;
            }
            else if (c == Color.Green)
            {
                return Farben.green;
            }
            return Farben.other;
        }
        public static Color GetColorFromFarbe(Farben farbe)
        {
            switch (farbe)
            {
                case Farben.red:
                    return Color.Red;
                case Farben.blue:
                    return Color.Blue;
                case Farben.green:
                    return Color.Green;
                case Farben.orange:
                    return Color.Orange;
                case Farben.violet:
                    return Color.Violet;
                case Farben.yellow:
                    return Color.Yellow;
                default:
                    Console.WriteLine("Keine passende Farbe gefunden: Color.Wheat returned.");
                    return Color.Wheat;
            }
        }
        public static Color GetColorFromMarker(Marker marker)
        {
            switch (marker)
            {
                case Marker.black:
                    return Color.Black;
                case Marker.white:
                    return Color.White;
                default:
                    Console.WriteLine("Markerfarbe war none oder undefiniert. Gebe Color.Wheat zurück.");
                    return Color.Wheat;
            }
        }

    }
}
