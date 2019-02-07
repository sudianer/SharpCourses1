using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Представляет космический корабль
    /// </summary>
    class Ship : BaseObject
    {
        public static event Message MessageDie;
        
        private int _energy = 100;
        public int Energy => _energy;

        /// <summary>
        /// Отнятие энергии у корабля
        /// </summary>
        /// <param name="n"></param>
        public void EnergyMinus(int n)
        {
            _energy -= n;
        }
        /// <summary>
        /// Добавление энергии кораблю
        /// </summary>
        public void EnergyPlus(int n)
        {
            _energy += n;
        }
        /// <summary>
        /// Объявляет экземпляр класса Ship
        /// </summary>
        /// <param name="pos">Стартовая позиция корабля</param>
        /// <param name="dir">Направление движения корабля</param>
        /// <param name="size">Размер корабля</param>
        public Ship(Point pos, Point dir, Size size) : base(pos,dir,size)
        {

        }
        /// <summary>
        /// Отрисовка корабля
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Wheat, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// Обновлиение позиции корабля(пуст)
        /// </summary>
        public override void Update()
        {
           
        }
        /// <summary>
        /// движение корабля вверх
        /// </summary>
        public void Up()
        {
            if (Pos.Y > 0) Pos.Y -= Dir.Y;
        }
        /// <summary>
        /// движение корабля вниз
        /// </summary>
        public void Down()
        {
            if (Pos.Y < Game.Height) Pos.Y += Dir.Y;
        }
        /// <summary>
        /// гибель корабля
        /// </summary>
        public void Die()
        {
            MessageDie?.Invoke();
        }


    }
}
