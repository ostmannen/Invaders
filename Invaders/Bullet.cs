using System.Runtime.Intrinsics;
using System.Numerics;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Invaders
{
    public class Bullet : Entity
    {
        public float speed = 300;
        
        public Bullet() : base("bullet")
        {

        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            if (Position.X > Program.ScreenW - 10){
                dead = true;
            }
            if (Position.X < 10){
                dead = true;
            }
            if (Position.Y > Program.ScreenH - 10){
                dead = true;
            }
            if (Position.Y < 10){
                dead = true;
            }
        }
        protected override void CollideWith(Scene scene, Entity entity)
        {
             
        }
    }
}
