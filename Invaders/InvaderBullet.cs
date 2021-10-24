/*using System.Runtime.Intrinsics;
using System.Numerics;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Invaders
{
    public sealed class InvaderBullet : Bullet
    {
        public Vector2f Direction;
        public InvaderBullet(Vector2f dir)
        {
            speed = 300;
            Direction = dir;
        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(0,25,5,22);
        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            Position += deltaTime * speed * Direction;
        }
        public float Rotation
        {
            get => sprite.Rotation;
            set => sprite.Rotation = value;
        }
    }
}
*/