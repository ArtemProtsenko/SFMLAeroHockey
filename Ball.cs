using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public class Ball
    {
        private static uint width = Game.width;
        private static uint height = Game.height;
        
        private static float radius = 60.0f;
        
        CircleShape ball = new CircleShape(radius);
        
        private RenderWindow window = Game.window;
        
        private CircleShape gameBall;

        private static float speed = 1.5f;
        
        private float x = -speed;
        private float y = -speed;
        
        private Vector2f position = new Vector2f((width / 2) - radius, (height / 2) - radius);
        
        public void SpawnBall()
        {
            gameBall = ball;
            gameBall.FillColor = Color.Magenta;
            gameBall.Position = position;
            window.Draw(gameBall);
        }

        public void BallBehaviour(CircleShape racketOne, CircleShape racketTwo, bool isPaused)
        {
            if(!isPaused)
            {
                WallReflection();
                RacketReflection(racketOne, racketTwo);
            }
        }
        
        void WallReflection()
        {
            position += new Vector2f(x, y);

            /*if (IsOutOfWidth())
            {
                x = 0;
                y = 0;
                position = new Vector2f((width / 2) - radius, (height / 2) - radius);
            }*/
            
            if (IsLessThanHeight())
            {
                y = speed;
            }
            
            if (IsMoreThanHeight())
            {
                y = -speed;
            }
            
            if (IsLessThanWidth())
            {
                x = speed;
            }
            
            if (IsMoreThanWidth())
            {
                x = -speed;
            }

        }

        void RacketReflection(CircleShape racketOne, CircleShape racketTwo)
        {
            if (IsInTouch(racketOne))
            {
                x = speed;
            }
            if (IsInTouch(racketTwo))
            {
                x = -speed;
            }
        }

        //bool IsOutOfWidth() => gameBall.Position.X <= 0 || gameBall.Position.X >= width - (radius * 2);

        bool IsLessThanHeight() => gameBall.Position.Y <= 0;
        
        bool IsMoreThanHeight() => gameBall.Position.Y >= height - (radius * 2);

        bool IsLessThanWidth() => gameBall.Position.X <= 0;
        
        bool IsMoreThanWidth() => gameBall.Position.X >= width - (radius * 2);

        bool IsInTouch(CircleShape racket) => Math.Sqrt(Math.Pow(ball.Position.X - racket.Position.X, 2) +
                                                        Math.Pow(ball.Position.Y - racket.Position.Y, 2)) <= radius * 2;
    }
        
}