using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Определяет астероид, его отрисовку и перемещение
    /// </summary>
    class Asteroid : BaseObject , ICloneable

    {

        Image smallRock;
        public int Power { get; set; }
        /// <summary>
        /// Инициализирует новый экземпляр класса Asteroid с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция астероида</param>
        /// <param name="dir">Перемещение астероида</param>
        /// <param name="size">размер астероида</param>
        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
           smallRock = Image.FromFile("images/SmallRock.png");
        }
        /// <summary>
        /// Отрисовывает астероид на экране
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawImage(smallRock, Pos.X, Pos.Y);
        }
        public object Clone()
        {
            Asteroid asteroid = new Asteroid(new Point(Pos.X, Pos.Y), new Point(Dir.X,Dir.Y), new Size(Size.Width,Size.Height));
            return asteroid;
        } /// <summary>
          /// Обновляет позицию объекта на экране
          /// </summary>
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Dir.X = Game.Width + Size.Width;
        }
    }
}
