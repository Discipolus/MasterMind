using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterMind.objects
{
    internal class GameElement
    {
        private Point position;
        private bool active;
        private bool used;
        private Farben farbe;
        public GameElement(Point position)
        {
            this.position = position;
            active = false;
            used = false;
            farbe = Farben.red;
        }
        public Point Position
        {
            get 
            {
                return position;
            }
        }
        public bool Active
        {
            get
            {
                return active;
            }
            set
            {
                active = value;
            }
        }
        public bool Used
        {
            get { return used; }
            set { used = false; }
        }

    }
}
