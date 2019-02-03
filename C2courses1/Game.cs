using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2courses1
{
    /// <summary>
    /// Предоставляет игру, отрисовывает объекты на экране и позволяет с ними взаимодействовать(пока нет)
    /// </summary>
    class Game
    {
        static Random rng;


        private static BufferedGraphicsContext _context;
        /// <summary>
        /// Буфер графики
        /// </summary>
        public static BufferedGraphics Buffer;

        /// <summary>
        /// Хранит в себе разные объекты игры
        /// </summary>
        public static BaseObject[] _objs;
        /// <summary>
        /// пуля этой игры
        /// </summary>
        private static Bullet _bullet;
        /// <summary>
        /// астероиды этой игры
        /// </summary>
        private static Asteroid[] _asteroids;
        
        /// <summary>
        /// Ширина окна игры, не может быть больше 1000 либо отрицательной
        /// </summary>
        public static int Width { get; set; }
        /// <summary>
        /// Высота окна игры, не может быть больше 1000 либо отрицательной
        /// </summary>
        public static int Height { get; set; }
        static Game()
        {
            rng = new Random();
        }
        const int MAX_HEIGHT = 1000;
        const int MAX_WIDTH = 1000;
        /// <summary>
        /// Инициализация графики игры
        /// </summary>
        /// <param name="form"></param>
        public static void Init(Form form)
        {
           

            Graphics g;

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            if (Width > MAX_WIDTH
                || Height > MAX_HEIGHT
                || Width < 0
                || Height < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        /// <summary>
        /// Обновляет картинку по таймеру
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        /// <summary>
        /// Отрисовывает объекты игры
        /// </summary>
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (Asteroid obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        /// <summary>
        /// Вызывает метод update для всех объектов игры
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            for(int i = 0; i < _asteroids.Length;i++)
            {
                _asteroids[i].Update();
                if (_asteroids[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
                    int r = rng.Next(5,50);
                    
                    _asteroids[i] = new Asteroid(new Point(1000, rng.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                }
            }
            _bullet.Update();
        }
       
        

        /// <summary>
        /// Заполняет массив _objs и инициализирует все его элементы
        /// </summary>
        public static void Load()
        {
          
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[20];          
            for (var i = 0; i < _objs.Length; i++)
            {   
                int r = rng.Next(5, 50);

                _objs[i] = new Star(new Point(1000,rng.Next(0,Game.Height)), new Point(-r, r), new Size(3,3));     
            }
            for (var i = 0; i<_asteroids.Length;i++)
            {
                int r = rng.Next(5,50);
                _asteroids[i] = new Asteroid(new Point(1000, rng.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r,r));
            }

        }
    
    }
}
