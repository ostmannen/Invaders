using System.Drawing;
using System.Reflection.Emit;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Spawner
    {
        private float  invaderTimer = 3;
        private float invaderCurrentTime = 0;
        public void update(Scene scene, float deltaTime){
            if (invaderCurrentTime >= invaderTimer){
                scene.spawn(new Invader(){Position = new Vector2f(200, 18), Rotation = 100});
                if (invaderTimer >= 1){
                    invaderTimer -= 0.1f;
                }
                invaderCurrentTime = 0;
            }
            invaderCurrentTime += deltaTime;
        }
    }
}
