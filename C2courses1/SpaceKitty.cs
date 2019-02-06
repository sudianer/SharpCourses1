using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Космический котик! Его отрисовка и перемещение
    /// </summary>
    class SpaceKitty:BaseObject
    {
        Image smallCat;
        Image mediumCat;
        /// <summary>
        /// Инициализирует новый экземпляр класса SpaceKitty с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция объекта</param>
        /// <param name="dir">Перемещение объекта</param>
        /// <param name="size">размер объекта</param>
        public SpaceKitty(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            smallCat = Image.FromFile("images/SmallCat.jpg");
            mediumCat = Image.FromFile("images/MediumCat.jpg");
        }
        /// <summary>
        /// Отрисовывет котика не экране
        /// </summary>
        public override void Draw()
        {
            //  Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            // Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(mediumCat, Pos.X, Pos.Y);
        }
        /// <summary>
        /// Обновляет позицию объекта на экране
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Dir.X = Game.Width + Size.Width;
        }

    }
}
