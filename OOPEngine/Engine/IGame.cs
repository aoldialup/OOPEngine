using SFML.Graphics;

namespace OOPEngine
{
    interface IGame
    {
        public void LoadContent(GameContainer gc);

        public void Update(GameContainer gc);

        public void Draw(RenderWindow window);
    }
}
