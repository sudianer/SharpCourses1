using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;
       // Image asteroid = Image.FromFile("asteroid.jpg");
        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }
        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawImage(asteroid, Pos.X, Pos.Y);
        }
        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
            
        }
    }
}
