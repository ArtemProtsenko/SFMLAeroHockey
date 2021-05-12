using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public class Players
    {
        private static uint width = Game.width;
        private static uint height = Game.height;
        
        private static float radius = 60.0f;
        
        CircleShape baseRacketOne = new CircleShape(radius);
        CircleShape baseRacketTwo = new CircleShape(radius);
        
        private RenderWindow window = Game.window;
        
        public CircleShape racketOne;
        public CircleShape racketTwo;
        
        private Vector2f positionOne = new Vector2f(0, (height / 2) - radius);
        private Vector2f positionTwo = new Vector2f(width - (radius * 2), (height / 2) - radius);
        
        private float speed = 2f;
        
        void CreatePlayerOne()
        {
            racketOne = baseRacketOne;
            racketOne.FillColor = Color.Blue;
            racketOne.Position = positionOne;
            window.Draw(racketOne);
        }
        
        void CreatePlayerTwo()
        {
            racketTwo = baseRacketTwo;
            racketTwo.FillColor = Color.Red;
            racketTwo.Position = positionTwo;
            window.Draw(racketTwo);
        }

        public void SpawnPlayers()
        {
            CreatePlayerOne();
            CreatePlayerTwo();
        }

        public void RacketMove(bool isPaused)
        {
            if(!isPaused)
            {
                if (CanMoveUp(racketOne))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.W) || Keyboard.IsKeyPressed(Keyboard.Key.D))
                    {
                        MoveUp(out positionOne, racketOne);
                    }
                }

                if (CanMoveDown(racketOne))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.S) || Keyboard.IsKeyPressed(Keyboard.Key.A))
                    {
                        MoveDown(out positionOne, racketOne);
                    }
                }

                if (CanMoveUp(racketTwo))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.I) || Keyboard.IsKeyPressed(Keyboard.Key.L))
                    {
                        MoveUp(out positionTwo, racketTwo);
                    }
                }

                if (CanMoveDown(racketTwo))
                {
                    if (Keyboard.IsKeyPressed(Keyboard.Key.K) || Keyboard.IsKeyPressed(Keyboard.Key.J))
                    {
                        MoveDown(out positionTwo, racketTwo);
                    }
                }
            }
        }

        void MoveUp(out Vector2f position, CircleShape racket)
        {
            Vector2f pos = new Vector2f(0f, -speed);
            position = racket.Position;
            position += pos;
        }
        
        void MoveDown(out Vector2f position, CircleShape racket)
        {
            Vector2f pos = new Vector2f(0f, speed);
            position = racket.Position;
            position += pos;
        }

        bool CanMoveUp(CircleShape racket) => racket.Position.Y > 0;

        bool CanMoveDown(CircleShape racket) => racket.Position.Y < height - (radius * 2);
    }
}