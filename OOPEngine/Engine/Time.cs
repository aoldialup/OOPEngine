namespace OOPEngine
{
    class Time
    {
        private static float _deltaTime = 0f;

        public static float deltaTime
        {
            get
            {
                return _deltaTime;
            }
        }

        public static void SetDeltaTime(float deltaTime)
        {
            _deltaTime = deltaTime;
        }
    }
}
