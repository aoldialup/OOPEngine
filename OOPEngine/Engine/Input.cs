using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

using static SFML.Window.Keyboard;

namespace OOPEngine
{
    class Input
    {
        private static bool firstTime = true;

        public const int KEY_COUNT = (int)Key.KeyCount;
        public const int MOUSE_BUTTON_COUNT = (int)Mouse.Button.ButtonCount;

        private static bool isInitialized = false;

        private static bool[] keysCurrent, keysLast;
        private static bool[] mouseButtonsCurrent, mouseButtonsLast;

        private static Vector2f _mousePosition;

        public Input(RenderWindow window)
        {
            window.KeyReleased += OnKeyReleased;
            window.KeyPressed += OnKeyDown;

            window.MouseButtonPressed += OnMousePressed;
            window.MouseButtonReleased += OnMouseReleased;

            window.TextEntered += OnTextEntered;

            keysCurrent = new bool[KEY_COUNT];
            keysLast = new bool[MOUSE_BUTTON_COUNT];

            mouseButtonsCurrent = new bool[MOUSE_BUTTON_COUNT];
            mouseButtonsCurrent = new bool[KEY_COUNT];

            isInitialized = true;
        }

        public static EventHandler<TextEventArgs> Typed;

        private void OnTextEntered(object sender, TextEventArgs e)
        {
            Typed?.Invoke(sender, e);
        }

        public static bool IsKeyDown(Key key)
        {
            if (!isInitialized)
            {
                return false;
            }

            return keysCurrent[(int)key];
        }

        public static bool IsKeyClicked(Key key)
        {
            if (!isInitialized)
            {
                return false;
            }

            return keysCurrent[(int)key] && !keysLast[(int)key];
        }

        public static bool IsMouseButtonClicked(Mouse.Button button)
        {
            if (!isInitialized)
            {
                return false;
            }

            return mouseButtonsCurrent[(int)button] && !mouseButtonsLast[(int)button];
        }

        public static bool IsMouseButtonDown(Mouse.Button button)
        {
            if (!isInitialized)
            {
                return false;
            }

            return mouseButtonsCurrent[(int)button];
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            keysCurrent[(int)e.Code] = true;
        }

        private void OnKeyReleased(object sender, KeyEventArgs e)
        {
            keysCurrent[(int)e.Code] = false;
        }

        private void OnMousePressed(object sender, MouseButtonEventArgs e)
        {
            mouseButtonsCurrent[(int)e.Button] = true;
        }

        private void OnMouseReleased(object sender, MouseButtonEventArgs e)
        {
            mouseButtonsCurrent[(int)e.Button] = false;
        }

        public static Vector2f mousePosition
        {
            get
            {
                if (!isInitialized)
                {
                    return new Vector2f();
                }

                return _mousePosition;
            }
        }

        public static void Update(RenderWindow window)
        {
            if (!firstTime)
            {
                keysLast = (bool[])keysCurrent.Clone();
                mouseButtonsLast = (bool[])mouseButtonsCurrent.Clone();
            }

            _mousePosition = (Vector2f)Mouse.GetPosition(window);

            firstTime = false;
        }
    }
}