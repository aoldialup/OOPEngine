using SFML.Graphics;
using System.Collections.Generic;

namespace OOPEngine
{
    class StateManager
    {
        private Dictionary<int, GameState> gameStates;

        private GameState currentState = null;
        private GameState pendingState = null;

        private bool stateActive = false;

        public StateManager()
        {
            gameStates = new Dictionary<int, GameState>();
        }

        private bool StateExists(int id)
        {
            return gameStates.ContainsKey(id);
        }

        public void ChangeState(int id)
        {
            if (StateExists(id))
            {
                if (!stateActive)
                {
                    pendingState = GetState(id);
                    ExecuteStateChange();
                }
                else
                {
                    pendingState = GetState(id);
                }
            }
        }

        private GameState GetState(int id)
        {
            return gameStates[id];
        }

        private bool StateCanUpdate()
        {
            return stateActive && currentState.update != null;
        }

        private bool StateCanDraw()
        {
            return stateActive && currentState.draw != null;
        }

        public void UpdateCurrentState(GameContainer gc)
        {
            if (StateCanUpdate())
            {
                stateActive = true;
                currentState.update(gc);
            }
        }

        public void DrawCurrentState(RenderWindow window)
        {
            if (StateCanDraw())
            {
                currentState.draw(window);
                stateActive = false;
            }

            if (pendingState != null)
            {
                ExecuteStateChange();
            }
        }


        private void ExecuteStateChange()
        {
            currentState = pendingState;
            pendingState = null;

            Log.Info(this, $"Changed state to [{currentState.id}]");
        }

        public void AddState(int id, Update update, Draw draw)
        {
            gameStates.Add(id, new GameState(id, update, draw));
        }
    }
}