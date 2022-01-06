using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Text;

namespace OOPEngine
{
    class Textbox
    {
        private const int DELETE_KEY = 8;
        private const int ENTER_KEY = 13;
        private const int ESCAPE_KEY = 27;

        public const int NO_CHAR_LIMIT = -1;

        public TextInputMode textInputMode { get; set; } = TextInputMode.DEFAULT;

        private Text textBox;
        private StringBuilder text;

        public bool isSelected { get; set; }

        private int charLimit;

        public string textTyped
        {
            get
            {
                return text.ToString();
            }
        }

        public Textbox(int textSize, int charLimit, Color color, Vector2f position, bool isSelected)
        {
            this.isSelected = isSelected;
            this.charLimit = charLimit;

            //textBox = new Text(string.Empty, Helper.CONSOLAS);
            textBox.CharacterSize = (uint)textSize;
            textBox.FillColor = color;
            textBox.Position = position;

            text = new StringBuilder();

            if (isSelected)
            {
                textBox.DisplayedString = "_";
            }

            Input.Typed += UpdateText;
        }

        public event Action OnPressEnter = null;

        public Vector2f position
        {
            get
            {
                return textBox.Position;
            }
            set
            {
                textBox.Position = value;
            }
        }

        public Color fillColor
        {
            get
            {
                return textBox.FillColor;
            }
            set
            {
                textBox.FillColor = value;
            }
        }

        private bool IsKeyValid(int charTyped)
        {
            return charTyped < 128;
        }

        private char ProcessText(char key)
        {
            switch (textInputMode)
            {
                case TextInputMode.DEFAULT:
                    return key;

                case TextInputMode.UPPER_CASE:
                    return char.ToUpper(key);

                case TextInputMode.LOWER_CASE:
                    return char.ToLower(key);
            }

            return char.MinValue;
        }

        public void UpdateText(object o, TextEventArgs e)
        {
            if (isSelected)
            {
                char key = ProcessText(e.Unicode[0]);

                if (IsKeyValid(key))
                {
                    switch (key)
                    {
                        case (char)DELETE_KEY:
                            RemoveLastChar();
                            break;

                        case (char)ESCAPE_KEY:
                            isSelected = false;
                            break;

                        case (char)ENTER_KEY:
                            OnPressEnter?.Invoke();
                            break;

                        default:
                            AddChar(key);
                            break;
                    }
                }
            }

            textBox.DisplayedString = text.ToString() + '_';
        }


        public void Draw(RenderWindow window)
        {
            window.Draw(textBox);
        }

        private void AddChar(char keyTyped)
        {
            if (!IsFull())
            {
                text.Append(keyTyped);
            }
        }

        private void RemoveLastChar()
        {
            if (!IsEmpty())
            {
                text.Remove(text.Length - 1, 1);
            }
        }

        public void Clear()
        {
            text.Clear();
            textBox.DisplayedString = "_";
        }

        public bool IsFull()
        {
            return text.Length == charLimit;
        }

        public bool IsEmpty()
        {
            return text.Length == 0;
        }
    }
}