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
        public float speed = 500;
        private Entity creator;
        public Vector2f direction;
        public Bullet(Entity entity, Vector2f dir, IntRect textureIntRect) : base("bullet")
        {
            creator = entity;
            sprite.TextureRect = textureIntRect;
            direction = dir;
        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            Position += deltaTime * speed * direction;
            if (Position.X > Program.ScreenW + 30)
            {
                dead = true;
            }
            if (Position.X < -30)
            {
                dead = true;
            }
            if (Position.Y > Program.ScreenH + 30)
            {
                dead = true;
            }
            if (Position.Y < -30)
            {
                dead = true;
            }
        }
        public float Rotation
        {
            get => sprite.Rotation;
            set => sprite.Rotation = value;
        }
        protected override void CollideWith(Scene scene, Entity entity)
        {
            if (entity is Player && creator is Invader)
            {
                dead = true;
                scene.events.PublishShot(1);
            }
            if (entity is Invader && creator is Player)
            {
                entity.dead = true;
                dead = true;
            }
        }
    }
}
