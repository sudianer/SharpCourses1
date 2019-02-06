using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace C2courses1
{
    public delegate void Message();
    /// <summary>
    /// Базовый класс объекта в игре, от него наследуются остальные классы
    /// </summary>
    abstract class BaseObject : ICollision
    {
       
        /// <summary>
        /// Начальная позиция объекта на экране
        /// </summary>
        protected Point Pos;
        /// <summary>
        /// Движение объекта на экране(изменение положения объекта при следующем update)
        /// </summary>
        protected Point Dir;
        /// <summary>
        /// размер объекта
        /// </summary>
        protected Size Size;

        /*не знаю как корректно прописать значения для ошибки
        думал насчет привязки к экрану, но за экраном тоже можно прорисовывать объекты
        пусть пока будет так*/
        const int MAX_HEIGHT = 1080;
        const int MAX_WIDTH = 1980;
        const int MAX_SIZE_HEIGHT = 400;
        const int MAX_SIZE_WIDTH = 500;
        const int MAX_SPEED = 50;
        /// <summary>
        /// Инициализирует новый экземпляр класса BaseObject с его начальной позицией, 
        /// последующим перемещением, и размером
        /// </summary>
        /// <param name="pos">Начальная позиция объекта</param>
        /// <param name="dir">Перемещение объекта</param>
        /// <param name="size">размер объекта</param>
        public BaseObject(Point pos, Point dir, Size size) 
        {
            /*нормально ли так прописывать ошибку? если в наследуемом объекте 
             * создать новый конструктор, то там придется писать все это еще раз
            */
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
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        /// <summary>
        /// Отрисовывает объект на экране
        /// </summary>
        public abstract void Draw();
        /// <summary>
        /// Обновляет позицию объекта на экране
        /// </summary>
        public abstract void Update();
        
        /// <summary>
        /// Определяет, столнулся ли этот объект с передаваемым
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        /// <summary>
        /// "хитбокс"(?) объекта
        /// </summary>
        public Rectangle Rect => new Rectangle(Pos, Size);
    }
}
