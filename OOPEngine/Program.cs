using SFML.Graphics;

namespace OOPEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            GameContainer gc = new GameContainer(800, 600, "Game", new Game(), Color.Black);
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


