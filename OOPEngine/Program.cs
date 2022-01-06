using SFML.Graphics;

namespace OOPEngine
{
    class Program
    {
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;
        public const string WINDOW_TITLE = "Game";
        public static readonly Color clearColor = Color.Black;

        static void Main(string[] args)
        {
            GameContainer gc = new GameContainer(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_TITLE, new Game(), clearColor);
            gc.Run();
        }
    }

    class Game : IGame
    {
        public void LoadContent(GameContainer gc)
        {

        }

        public void Update(GameContainer gc)
        {

        }

        public void Draw(RenderWindow window)
        {

        }
    }
}


