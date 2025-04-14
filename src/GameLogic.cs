using System.Reflection;
using System.Drawing.Drawing2D;
using System.Diagnostics;

namespace Seed
{
    /// <summary>
    /// The main class of Seed. All Seed scripts derive from it.
    /// </summary>
    public abstract class GameLogic
    {
        static Color backgroundColor = Color.White;
        private static GameWindow window = new GameWindow(800, 600);
        static Bitmap secondBuffer = new Bitmap(window.Width, window.Height);
        /// <summary>
        /// Object that is used to draw elements on the game window.
        /// </summary>
        public static Graphics G = Graphics.FromImage(secondBuffer);
        static Graphics? gWindow;
        static int desiredFps = 60;
        static bool isRunning = false;
        static Rectangle screenRectangle;
        static List<GameLogic> scripts = new List<GameLogic>();
        /// <summary>
        /// The count of the frames that have been sucessfully rendered. The value of it is 0 at the start. It increases by 1 with each sucessfully rendered frame.
        /// </summary>
        public static int FrameNumber {get; private set;} = 0;

        /// <summary>
        /// The number of game units currently present on the game window. 10 by default.
        /// </summary>
        public static double UnitsOnCanvas = 10;
        /// <summary>
        /// The width of the game window in pixels. 800 by default.
        /// </summary>
        public static int Width {get; private set;} = window.Width;
        /// <summary>
        /// The height of the game window in pixels. 600 by default.
        /// </summary>
        public static int Height {get; private set;} = window.Height - (screenRectangle.Top - window.Top) - 8;
        
        private static bool isFullScreen = false;

        /// <summary>
        /// A list of STextures that represents the tile map textures. The item with index 0 is an empty STexture.
        /// </summary>
        public static List<STexture> TileTextures = new List<STexture>(){new STexture(1, 1)};

        /// <summary>
        /// The desired FPS of the game. 60 by default.
        /// </summary>
        /// <exception cref="InvalidDataException">
        /// Thrown when the value is attempted to be set to 0 or less.
        /// </exception>
        public static int DesiredFps 
        {
            get
            {
                return desiredFps;
            }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Fps cannot be less than 0");
                }
                else
                {
                    desiredFps = value;
                }
            }
        }
        private static double _lastCameraX = Camera.PosX;
        private static double _lastCameraY = Camera.PosY;

        /// <summary>
        /// The actual FPS of the game.
        /// </summary>
        public static int Fps {get; private set;}
        /// <summary>
        /// The time between the current and last frame.
        /// </summary>
        static public double DeltaTime {get; private set;}
        
        /// <summary>
        /// Rectangle that stretches the entire screen. It is used to determine if an element is in the screen and should it be drawn.
        /// </summary>
        public static FullRectangle? IsInScreenRect;
        
        /// <summary>
        /// Called when the game loop starts. It has to be overriden. It can be used to provide code to be executed when the game loop is started.
        /// </summary>
        public abstract void OnStart();
        /// <summary>
        /// Called each frame. It has to be overriden. It can be used to provide code to be executed each frame.
        /// </summary>
        public abstract void OnFrame();
        /// <summary>
        /// Creates a new instance of the GameLogic class.
        /// </summary>
        /// <exception cref="Exception">Thrown if a GameLogic object gets created after the game loop is started.</exception>
        public GameLogic()
        {
            if(isRunning)
            {
                throw new Exception("New GameLogic scripts cannot be created after the game loop has been started");
            }
            scripts.Add(this);
        }

        /// <summary>
        /// Starts the game loop and opens the game window.
        /// </summary>
        /// <exception cref="Exception">Thrown if the method is called more than once.</exception>
        public static void StartGameLoop()
        {
            G.InterpolationMode = InterpolationMode.NearestNeighbor;
            G.SmoothingMode = SmoothingMode.HighSpeed;
            G.CompositingQuality = CompositingQuality.HighSpeed;
            if(isRunning)
            {
                throw new Exception("Game loop can only be started once");
            }
            Thread startWindow = new Thread(() => Application.Run(window));
            startWindow.Start();
            isRunning = true;
            IsInScreenRect = new FullRectangle(ScaleConverter.NeutralToGame(0, true, true, false), ScaleConverter.NeutralToGame(0, true, false, false), ScaleConverter.NeutralToGame(Width, false, false, false), ScaleConverter.NeutralToGame(Height, false, false, false), Color.FromArgb(0, 0, 0));
            CallUpdate();
        }

        static void CallUpdate()
        {
            Task.Delay(3);
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            foreach(GameLogic script in scripts)
            {
                script.OnStart();
            }
            long timeAtLastFrameMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            while(true)
            {
                screenRectangle = window.Invoke(() => window.RectangleToScreen(window.ClientRectangle));
                Brush brush = new SolidBrush(backgroundColor);
                Width = window.Width;
                Height = window.Height - (screenRectangle.Top - window.Top) - (screenRectangle.Top - window.Top == 0? 0 : 8);
                if(secondBuffer.Size != window.Size || gWindow == null)
                {
                    secondBuffer = new Bitmap(window.Width, window.Height);
                    G = Graphics.FromImage(secondBuffer);
                    gWindow = window.Invoke(() => window.CreateGraphics());
                    G.InterpolationMode = InterpolationMode.NearestNeighbor;
                    gWindow.InterpolationMode = InterpolationMode.NearestNeighbor;
                    G.SmoothingMode = SmoothingMode.HighSpeed;
                    G.CompositingQuality = CompositingQuality.HighSpeed;
                    gWindow.SmoothingMode = SmoothingMode.HighSpeed;
                    gWindow.CompositingQuality = CompositingQuality.HighSpeed;
                    IsInScreenRect = new FullRectangle(ScaleConverter.NeutralToGame(0, true, true, false), ScaleConverter.NeutralToGame(0, true, false, false), ScaleConverter.NeutralToGame(Width, false, false, false), ScaleConverter.NeutralToGame(Height, false, false, false), Color.FromArgb(0, 0, 0));
                }
                long timeNowMillis = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                DeltaTime = (timeNowMillis - timeAtLastFrameMillis) / 1000.0;
                timeAtLastFrameMillis = timeNowMillis;
                G.FillRectangle(brush, 0, 0, Width, Height);
                foreach(GameLogic script in scripts)
                {
                    script.OnFrame();
                }
                 if(_lastCameraX != Camera.PosX || _lastCameraY != Camera.PosY)
                    IsInScreenRect = new FullRectangle(ScaleConverter.NeutralToGame(0, true, true, false), ScaleConverter.NeutralToGame(0, true, false, false), ScaleConverter.NeutralToGame(Width, false, false, false), ScaleConverter.NeutralToGame(Height, false, false, false), Color.FromArgb(0, 0, 0));
                gWindow.DrawImage(secondBuffer, Point.Empty);
                long endTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
                long timeItTook = stopwatch.ElapsedMilliseconds;
                long waitTime = 1000/DesiredFps - timeItTook;
                _lastCameraX = Camera.PosX;
                _lastCameraY = Camera.PosY;
                FrameNumber++;
                if(waitTime > 0)    
                {
                    Thread.Sleep((int)waitTime);
                }
                if(DeltaTime != 0)
                    Fps = Convert.ToInt32(1f/DeltaTime);
            }
        }
        /// <summary>
        /// Sets the title of the game window.
        /// </summary>
        /// <param name="title">The text that gets set as the title of the game window.</param>
        public static void SetTitle(string title)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Text = title);
            }
            else
            {
                window.Text = title;
            }
        }
        /// <summary>
        /// Sets the height and width of the game window.
        /// </summary>
        /// <param name="height">A value in pixels that gets set as the height of the game window.</param>
        /// <param name="width">A value in pixels that gets set as the width of the game window.</param>
        public static void SetSize(int width, int height)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Height = height);
                window.Invoke(() => window.Width = width);
            }
            else
            {
                window.Height = height;
                window.Width = width;
            }
        }
        /// <summary>
        /// Sets the icon of the game winodw.
        /// </summary>
        /// <param name="icon">The icon that gets set as the game window's icon.</param>
        public static void SetIcon(Icon icon)
        {
            if(isRunning)
            {
                window.Invoke(() => window.Icon = icon);
            }
            else
            {
                window.Icon = icon;
            }
        }
        /// <summary>
        /// Enables or disables resizing the game window.
        /// </summary>
        /// <param name="value">Defines whether the game window should be allowed to be resized or not.</param>
        public static void AllowResizing(bool value)
        {    
            if(!isFullScreen)
            {                
                switch (value)
                {
                    case false:
                    if(isRunning)
                    {
                        window.Invoke(() => window.FormBorderStyle = FormBorderStyle.FixedSingle);
                        window.Invoke(() => window.MaximizeBox = false);
                    }
                    else
                    {
                        window.FormBorderStyle = FormBorderStyle.FixedSingle;
                        window.MaximizeBox = false;
                    }
                    break;
                    case true:
                    if(isRunning)
                    {
                        window.Invoke(() => window.FormBorderStyle = FormBorderStyle.Sizable);
                        window.Invoke(() => window.MaximizeBox = true);
                    }
                    else
                    {
                        window.FormBorderStyle = FormBorderStyle.Sizable;
                        window.MaximizeBox = true;
                    }
                    break;
                } 
            }
        }
        /// <summary>
        /// Sets the game window's size mode to windowed or full screen.
        /// </summary>
        /// <param name="value">Describes the size mode the game window is to be set. True if full screen, false if windowed.</param>
        public static void SetFullScreen(bool value)
        {
            switch(value)
            {
                case true:
                    AllowResizing(false);
                    isFullScreen = true;
                    if(isRunning)
                    {
                        window.Invoke(() => window.WindowState = FormWindowState.Maximized);
                        window.Invoke(() => window.FormBorderStyle = FormBorderStyle.None);
                    }
                    else 
                    {
                        window.WindowState = FormWindowState.Maximized;
                        window.FormBorderStyle = FormBorderStyle.None;
                    }
                    break;
                case false:
                    isFullScreen = false;
                    if(isRunning)
                    {
                        window.Invoke(() => window.WindowState = FormWindowState.Normal);
                        AllowResizing(true);
                    }
                    else 
                    {
                        window.WindowState = FormWindowState.Normal;
                        AllowResizing(true);
                    }
                    break;
            }
            
        }
        /// <summary>
        /// Sets the background color of the game window.
        /// </summary>
        /// <param name="color">The color which the window's background color is to be set to.</param>
        public static void SetColor(Color color)
        {
            backgroundColor = color;
        }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public static void Exit()
        {
            Application.Exit();
        }

        private class GameWindow : Form
        {  
            public GameWindow(int width, int height)
            {
                Height = height;
                Width = width;
                this.SizeGripStyle = SizeGripStyle.Hide;
                this.Text = "Seed Game";
                this.KeyDown += KeyHandler.KeyDown;
                this.KeyUp += KeyHandler.KeyUp;
                this.MouseMove += Mouse.GetMousePos;
                this.MouseDown += Mouse.OnMouseDown;
                this.MouseUp += Mouse.OnMouseUp;
                Assembly assembly = Assembly.GetExecutingAssembly();
                using(Stream? imageStream = assembly.GetManifestResourceStream("Seed.Icons.Icon.ico"))
                {
                    if (imageStream != null)
                    {
                        this.Icon = new Icon(imageStream);
                    }
                }
                this.FormClosing += new FormClosingEventHandler(GameWindow.Close); 
            }
            

            static void Close(object? sender, FormClosingEventArgs e)
            {
                Environment.Exit(0);
            }
        }
    }
}
