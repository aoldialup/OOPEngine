using SFML.Graphics;

namespace OOPEngine
{
    delegate void Draw(RenderWindow window);
    delegate void Update(GameContainer gc);

    class GameState
    {
        public readonly int id;

        public Draw draw { get; } = null;

        public Update update { get; } = null;

        public GameState(int id, Update update, Draw draw)
        {
            this.update = update;
            this.draw = draw;
            this.id = id;
        }
    }
}