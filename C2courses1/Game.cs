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
        private static Ship _ship;
        private static int _score;
        private static BufferedGraphicsContext _context;
        /// <summary>
        /// Буфер графики
        /// </summary>
        public static BufferedGraphics Buffer;
        public static EnergyPack[] _energyPacks;
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
        static Timer _timer;
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
            _timer = new Timer { Interval = 100 };
            _ship = new Ship(new Point(10, 400), new Point(5,5), new Size(10,10));
            rng = new Random();
            _score = 0;
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

            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;

          
            _timer.Start();
            _timer.Tick += Timer_Tick;

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
                obj?.Draw();
            foreach (EnergyPack ep in _energyPacks)
                ep?.Draw();
            _bullet?.Draw();
            _ship?.Draw();
            if (_ship != null)
                Buffer.Graphics.DrawString("Energy:"+_ship.Energy, SystemFonts.DefaultFont, Brushes.White, 0,0);
            Buffer.Graphics.DrawString("Score:" + _score, SystemFonts.DefaultFont, Brushes.White, 0, 20);
            Buffer.Render();
        }
        /// <summary>
        /// Вызывает метод update для всех объектов игры
        /// </summary>
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
            for (int i = 0; i<_energyPacks.Length;i++)
            {
              
                if (_energyPacks[i] == null)
                    continue;
                _energyPacks[i].Update();
                if (_energyPacks[i].Collision(_ship))
                {
                    System.Media.SystemSounds.Exclamation.Play();
                    _energyPacks[i] = null;
                    _ship.EnergyPlus(20);
                    continue;
                }
            }
            _bullet?.Update();
            for(int i = 0; i < _asteroids.Length;i++)
            {
                if (_asteroids[i] == null) continue;
                _asteroids[i].Update();
                if (_bullet != null && _asteroids[i].Collision(_bullet))
                {
                    System.Media.SystemSounds.Hand.Play();
                    //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
                    _bullet = null;
                    int r = rng.Next(5,50);
                    _score++;
                   // _asteroids[i] = null;
                    _asteroids[i] = new Asteroid(new Point(1000, rng.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
                    continue;
                }
                if (!_ship.Collision(_asteroids[i])) continue;

                _ship?.EnergyMinus(rng.Next(1, 10));
                System.Media.SystemSounds.Asterisk.Play();
                if (_ship.Energy <= 0) _ship?.Die();
            }
            //_bullet.Update();
        }
       
        

        /// <summary>
        /// Заполняет массив _objs и инициализирует все его элементы
        /// </summary>
        public static void Load()
        {
          
            _objs = new BaseObject[30];
            //_bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[20];
            _energyPacks = new EnergyPack[5];
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
            for(var i = 0; i<_energyPacks.Length; i++)
            {
                _energyPacks[i] = new EnergyPack(new Point(rng.Next(1000, 1600), rng.Next(0, Game.Height)), new Point(8, 0), new Size(15, 15));
            }

        }
        /// <summary>
        /// Обработчик нажатия кнопки
        /// </summary>
        private static void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
                _bullet = new Bullet(new Point(_ship.Rect.X + 10, _ship.Rect.Y + 4), new Point(4, 0), new Size(4, 1));
            if (e.KeyCode == Keys.Up)
                _ship.Up();
            if (e.KeyCode == Keys.Down)
                _ship.Down();
        }
        /// <summary>
        /// Конец игры
        /// </summary>
        public static void Finish()
        {
            _timer.Stop();
            Buffer.Graphics.DrawString("You Died", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.White, 200, 100);
            Buffer.Render();
        }
       
        
    
    }
}
