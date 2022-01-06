# OOPEngine
Simple OOP-based game engine made in SFML.Net.


This game engine keeps things simple and provides an interface to do all of your game development in one file.


```cs
using SFML.Graphics;
using SFML.System;
using System;
using static SFML.Window.Keyboard;

namespace OOPEngine
{
    class Program
    {
        // Constants for the game's window width, height, and title. 
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;
        public const string WINDOW_TITLE = "Game";
        
        // Color that will be used to clear the screen
        public static readonly Color clearColor = Color.Black;

        static void Main(string[] args)
        {
            // This is the driver of the game, which will perform updates and rendering behind the scenes 
            GameContainer gc = new GameContainer(WINDOW_WIDTH, WINDOW_HEIGHT, WINDOW_TITLE, new Game(), clearColor);
            gc.Run();
        }
    }

    class Game : IGame
    {
        // Declare a texture and sprite for our github character 
        Texture githubTexture;
        Sprite githubSprite;
        
        public void LoadContent(GameContainer gc)
        {   
            // Load the texture. Note that the base/root path is where your OOPEngine.exe file is.
            githubTexture = new Texture("github.png");
            
            // 
            githubSprite = new Sprite(githubTexture);

            githubSprite.Position = new Vector2f(Program.WINDOW_WIDTH / 4f, Program.WINDOW_HEIGHT / 4f);
        }

        public void Update(GameContainer gc)
        {
            // This is the update loop, which will be called every 1/60th of a second
            
            // If the A key is pressed, offset the position of githubSprite by -2f
            if (Input.IsKeyDown(Key.A))
            {
                githubSprite.Position += new Vector2f(-2f, 0f);
            }
            
            // ...
            if (Input.IsKeyDown(Key.D))
            {
                githubSprite.Position += new Vector2f(2f, 0f);
            }
            
            // ...
            if (Input.IsKeyDown(Key.W))
            {
                githubSprite.Position += new Vector2f(0f, -5f);
            }
            
            // ... 
            if (Input.IsKeyDown(Key.S))
            {
                githubSprite.Position += new Vector2f(2f, 5f);
            }
        }
        
        // Draw elements to the screen
        public void Draw(RenderWindow window)
        {
            // Draw the github sprite
            githubSprite.Draw(window, RenderStates.Default);
        }
    }
}
```


