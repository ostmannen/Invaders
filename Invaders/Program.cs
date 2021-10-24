using System.Runtime.Intrinsics;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    class Program
    {
        public const int ScreenW = 414;
        public const int ScreenH = 450;
        static void Main(string[] args)
        {
            

            using (var window = new RenderWindow(
                new VideoMode(828, 900), "Pacman"))
            {
                window.Closed += (o, e) => window.Close();
                Clock clock = new Clock();
                Scene scene = new Scene();
                
                
                scene.spawn(new Player(){Position = new Vector2f(18,18)});
                window.SetView(new View(new FloatRect(18, 0, 414, 450)));
                
                while (window.IsOpen)
                {
                    window.DispatchEvents();
                    float deltaTime = clock.Restart().AsSeconds();
                    deltaTime = MathF.Min(deltaTime, 0.01f);
                    
                    window.Clear(new Color(94, 129, 161));
                    scene.RenderAll(window);
                    scene.UpdateAll(deltaTime);
                    window.Display();
                }
            }
        }
    }
}
