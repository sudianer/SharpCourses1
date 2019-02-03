using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    class Pizza: BaseObject
    {
        Image SmallPizza = Image.FromFile("Pizza.jpg");
        public Pizza(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            //  Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            // Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(SmallPizza, Pos.X, Pos.Y);
        }
    }
}
