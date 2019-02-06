using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Звезда! Ее отрисовка и перемещение
    /// </summary>
    class Star: BaseObject
    {
        Image smallStar;
        /// <summary>
        /// Инициализирует новый экземпляр класса Star с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция объекта</param>
        /// <param name="dir">Перемещение объекта</param>
        /// <param name="size">размер объекта</param>
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            smallStar = Image.FromFile("images/SmallStar.jpg");
        }
        /// <summary>
        /// Отрисовывет звезду 
        /// </summary>
        public override void Draw()
        {
            //  Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            // Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(smallStar, Pos.X, Pos.Y);
        }        
        /// <summary>
        /// Обновляет позицию звезды
        /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
