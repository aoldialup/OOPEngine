using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace OOPEngine
{
    class Button
    {
        private Text text;

        private RectangleShape buttonRect;

        public bool isVisible { get; set; } = true;
        public bool isActive { get; set; } = true;

        public Color hoveringColor { get; set; } = Color.Green;

        public Button(string displayedText, Vector2f position, Vector2f size, Font font, int charSize)
        {
            buttonRect = new RectangleShape(size);
            text = new Text(displayedText, font, (uint)charSize);

            text.FillColor = Color.Black;
            buttonRect.FillColor = Color.White;

            this.position = position;
        }

        public Color textColor
        {
            get
            {
                return text.FillColor;
            }
            set
            {
                text.FillColor = value;
            }
        }

        public string displayedString
        {
            get
            {
                return text.DisplayedString;
            }
            set
            {
                text.DisplayedString = value;
            }
        }

        public Vector2f position
        {
            get
            {
                return buttonRect.Position;
            }
            set
            {
                buttonRect.Position = value;
                text.Position = FindTextCenter();
            }
        }

        private Vector2f FindTextCenter()
        {
            return new Vector2f(
                (buttonRect.Position.X + buttonRect.GetGlobalBounds().Width / 2) - (text.GetGlobalBounds().Width / 2),
                (buttonRect.Position.Y + buttonRect.GetGlobalBounds().Height / 2) - (text.GetGlobalBounds().Height / 2)
            );
        }

        public bool IsMouseOver()
        {
            return Helper.IsMouseOverRectangle(buttonRect);
        }

        public bool IsPressed()
        {
            return IsMouseOver() && Input.IsMouseButtonClicked(Mouse.Button.Left);
        }

        public void Draw(RenderWindow window)
        {
            if (isVisible)
            {
                if (isActive && IsMouseOver())
                {
                    buttonRect.FillColor = Color.Green;
                }

                window.Draw(buttonRect);
                window.Draw(text);

                if (isActive)
                {
                    buttonRect.FillColor = Color.White;
                }
            }
        }
    }
}
