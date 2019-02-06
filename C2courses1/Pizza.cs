using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Определяет пиццу, ее отрисовку и перемещение
    /// </summary>
    class Pizza : BaseObject
    {
        private Image smallPizza;
        /// <summary>
        /// Инициализирует новый экземпляр класса Pizza с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция объекта</param>
        /// <param name="dir">Перемещение объекта</param>
        /// <param name="size">размер объекта</param>
        public Pizza(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            smallPizza = Image.FromFile("images/Pizza.jpg");
        }
        /// <summary>
        /// Отрисовывает космическую пиццу на экране
        /// </summary>
        public override void Draw()
        {

            Game.Buffer.Graphics.DrawImage(smallPizza, Pos.X, Pos.Y);
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