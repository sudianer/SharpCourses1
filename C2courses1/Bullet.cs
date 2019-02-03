using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Определяет пулю, ее отрисовку и перемещение
    /// </summary>
    class Bullet:BaseObject
    {
        const int MAX_HEIGHT = 1980;
        const int MAX_WIDTH = 1080;
        const int MAX_SIZE_HEIGHT = 400;
        const int MAX_SIZE_WIDTH = 500;
        const int MAX_SPEED = 50;
        /// <summary>
        /// Инициализирует новый экземпляр класса Bullet с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция Bullet</param>
        /// <param name="dir">Перемещение Bullet</param>
        /// <param name="size">размер Bullet</param>
        public Bullet(Point pos, Point dir, Size size) : base(pos,dir,size)
        {
            if (pos.X > MAX_WIDTH
              || pos.Y > MAX_HEIGHT
              || pos.X < 0
              || pos.Y < 0
              || dir.X > MAX_SPEED
              || dir.Y > MAX_SPEED
              || size.Height > MAX_SIZE_HEIGHT
              || size.Width > MAX_SIZE_WIDTH
              || size.Height < 0
              || size.Width < 0)
            {
                throw new GameObjectException("Корявый объект");
            }
        }
        /// <summary>
        /// Отрисовывает объект
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.OrangeRed, Pos.X,Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Обновляет позицию объекта
        /// </summary>
        public override void Update()
        {
            Pos.X += Dir.X;
        }
    }
}
