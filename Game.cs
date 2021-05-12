using SFML.Window;
using SFML.Graphics;
using SFML.System;
using System;

namespace Game
{
    public class Game
    {
        private Ball ball = new Ball();
        private Players pl = new Players();
        
        public static uint width = 1600;
        public static uint height = 900;
        
        public static RenderWindow window = new RenderWindow(new VideoMode(width, height), "Game");

        private Keyboard.Key pauseKey = Keyboard.Key.Space;

        bool isPaused = false;
        
        public void Main()
        {
            window.SetActive();
            while (window.IsOpen)
            {
                window.DispatchEvents();
                window.Clear(Color.Cyan);
                ball.SpawnBall();
                pl.SpawnPlayers();
                pl.RacketMove(isPaused);
                ball.BallBehaviour(pl.racketOne, pl.racketTwo, isPaused);
                Pause();
                window.Display();
            }
        }

        void Pause()
        {
            if (Keyboard.IsKeyPressed(pauseKey))
            {
                if (isPaused)
                {
                    isPaused = false;
                }
                else
                {
                    isPaused = true;
                }
            }
        }
    }
}