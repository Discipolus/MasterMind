using System;
using System.Drawing;
using System.Windows.Forms;
using MasterMind.objects;

namespace MasterMind.objects
{
    public class PlayButton : Button
    {
        public static Size Groesse = new Size(20, 20);

        public static readonly Color[] Farbreihenfolge = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Yellow,
            Color.Violet,
            Color.Orange,
            Color.Green
        };
        public PlayButton(string name) : base()
        {
            base.Name = name;
            base.Size = Groesse;
            base.Enabled = false;
            base.UseVisualStyleBackColor = true;
        }
        public void NextColor()
        {
            for (int i = 0; i < Farbreihenfolge.Length; i++)
            {
                if (BackColor == Farbreihenfolge[i])
                {
                    if (i + 1 == Farbreihenfolge.Length)
                    {
                        BackColor = Farbreihenfolge[0];
                    }
                    else
                    {
                        BackColor = Farbreihenfolge[i + 1];
                    }
                    return;
                }
            }
        }
        public void PreviousColor()
        {
            for (int i = 0; i < Farbreihenfolge.Length; i++)
            {
                if (BackColor == Farbreihenfolge[i])
                {
                    if (i == 0)
                    {
                        BackColor = Farbreihenfolge[Farbreihenfolge.Length - 1];
                    }
                    else
                    {
                        BackColor = Farbreihenfolge[i - 1];
                    }
                    return;
                }
            }
        }
        public bool BackgroudColorSet()
        {
            return Farben.other != helper.GetFarbeFromColor(base.BackColor);
        }
        public Farben GetFarbe()
        {
            return helper.GetFarbeFromColor(base.BackColor);
        }

    }
}