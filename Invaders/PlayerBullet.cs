using System.Runtime.Intrinsics;
using System.Numerics;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Invaders
{
    public sealed class PlayerBullet : Bullet
    {
        public PlayerBullet()
        {
            speed = 700;
        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(0,0,5,18);
        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            Position += deltaTime * speed * new Vector2f(0,-1);
        }
    }
}
