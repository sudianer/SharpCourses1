using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Аптечка, восстанавливает кораблю энергию
    /// </summary>
    class EnergyPack : BaseObject
    {

        /// <summary>
        /// Создает экземпляр EnergyPack
        /// </summary>
        /// <param name="pos">Начальная позиция</param>
        /// <param name="dir">Перемещение</param>
        /// <param name="size">Размер</param>
        public EnergyPack(Point pos, Point dir, Size size) : base(pos, dir ,size)
        {

        }
        /// <summary>
        /// отрисовка объекта
        /// </summary>
        public override void Draw()
        {
            Game.Buffer.Graphics.DrawRectangle(Pens.AliceBlue, Pos.X, Pos.Y, Size.Width, Size.Height);
        }
        /// <summary>
        /// обновление позиции объекта
        /// </summary>
        public override void Update()
        {
            Pos.X -= Dir.X;
        }


    }
}
