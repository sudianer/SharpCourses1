using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace C2courses1
{
    class Game
    {
        private static Random rng;
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;


        public static int Width { get; set; }
        public static int Height { get; set; }
        static Game()
        {
            rng = new Random();
        }
        public static void Init(Form form)
        {


            Graphics g;

            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();

            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;

            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
           // Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            Buffer.Graphics.FillEllipse(Brushes.Aquamarine, new Rectangle(100, 100, 200, 200));
          
           

            //Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
        public static BaseObject[] _objs;
        //немного поигрался с картиночками
        public static void Load()
        {
            int speedRng;
            int rngResult;
            _objs = new BaseObject[30];
            for (int i = 0; i < _objs.Length / 2; i++)
            {
                speedRng = rng.Next(1, 20);
                rngResult = rng.Next(0, 2);
                if (rngResult == 0)
                {
                    _objs[i] = new SpaceKitty(new Point(600, i * 20), new Point(speedRng, speedRng - i), new Size(10, 10));
                }
                else
                {
                    _objs[i] = new Rock(new Point(600, i * 20), new Point(speedRng, speedRng - i), new Size(10, 10));
                }

            }
            for (int i = _objs.Length / 2; i < _objs.Length; i++)
            {
                speedRng = rng.Next(1, 20);
                _objs[i] = new Star(new Point(600, i * 20), new Point(speedRng + 10, 0), new Size(5, 5));
            }
        }
    
    }
}
