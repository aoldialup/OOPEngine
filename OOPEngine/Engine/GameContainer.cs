using SFML.Graphics;
using SFML.Window;
using System;
using System.Diagnostics;
using System.Threading;

namespace OOPEngine
{
    class GameContainer
    {
        private RenderWindow window;

        private IGame game;

        private Input input;

        public readonly string windowTitle;
        public readonly int windowWidth;
        public readonly int windowHeight;

        public readonly Color clearColor;

        private const int CURRENT_FPS = 60;

        private int actualFPS = 0;

        public GameContainer(int windowWidth, int windowHeight, string windowTitle, IGame game, Color clearColor)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.windowTitle = windowTitle;

            this.clearColor = clearColor;
            this.game = game;

            window = new RenderWindow(new VideoMode((uint)windowWidth, (uint)windowHeight), windowTitle);
            window.SetFramerateLimit(60);

            InitWindow();
        }

        private void OnClose(object sender, EventArgs e)
        {
            window.Close();
        }

        private void LoadContent()
        {
            game.LoadContent(this);
        }

        private void Update()
        {
            game.Update(this);
        }

        private void Draw()
        {
            game.Draw(window);
        }

        private void InitWindow()
        {
            window.Closed += OnClose;
            input = new Input(window);
        }

        public void Run()
        {
            const float TIME_BETWEEN_UPDATES = 1000000000 / CURRENT_FPS;
            const int MAX_UPDATES_BEFORE_RENDER = 2;

            float lastUpdateTime = NanoTime();
            float lastRenderTime = lastUpdateTime;

            const float TARGET_TIME_BETWEEN_RENDERS = 1000000000 / CURRENT_FPS;

            int lastSecondTime = (int)(lastUpdateTime / 1000000000);

            float now = 0f;
            int updateCount = 0;
            int frameCount = 0;
            bool render = false;

            int thisSecond = 0;

            LoadContent();

            while (window.IsOpen)
            {
                now = NanoTime();
                updateCount = 0;
                render = false;

                window.DispatchEvents();

                while (now - lastUpdateTime > TIME_BETWEEN_UPDATES && updateCount < MAX_UPDATES_BEFORE_RENDER)
                {
                    Time.SetDeltaTime(((now - lastUpdateTime) / 1000000) / 1000f);

                    Input.Update(window);
                    Update();

                    lastUpdateTime += TIME_BETWEEN_UPDATES;
                    updateCount++;
                    render = true;
                }

                if (render)
                {
                    window.Clear(clearColor);
                    Draw();
                    window.Display();

                    frameCount++;
                    lastRenderTime = now;
                }

                thisSecond = (int)(lastUpdateTime / 1000000000);
                if (thisSecond > lastSecondTime)
                {
                    actualFPS = frameCount;
                    frameCount = 0;
                    lastSecondTime = thisSecond;
                }

                while (now - lastRenderTime < TARGET_TIME_BETWEEN_RENDERS &&
                        now - lastUpdateTime < TIME_BETWEEN_UPDATES)
                {
                    Thread.Yield();

                    now = NanoTime();
                }
            }
        }

        private long NanoTime()
        {
            long nano = 10000L * Stopwatch.GetTimestamp();
            nano /= TimeSpan.TicksPerMillisecond;
            nano *= 100L;
            return nano;
        }
    }
}
