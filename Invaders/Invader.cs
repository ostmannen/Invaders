using System.Text;
using System.Drawing;
using System.Reflection.Emit;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;


namespace Invaders
{
    public class Invader : Entity
    {
        private float speed = 160;
        public const float width = 40.0f;
        public const float length = 40.0f;
        private Vector2f size;
        public Vector2f direction = new Vector2f(1, 0.2f) / MathF.Sqrt(2.0f);
        private float shotTimer = 0;
        public Invader() : base("preview - Copy")
        {

        }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(0, 0, 40, 30);
            Vector2f playerTextureSize = new Vector2f(40, 30);
            sprite.Origin = 0.5f * playerTextureSize;
            sprite.Scale = new Vector2f(
                width / playerTextureSize.X,
                length / playerTextureSize.Y);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width,
                sprite.GetGlobalBounds().Height
            );
        }
        public float Rotation
        {
            get => sprite.Rotation;
            set => sprite.Rotation = value;
        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            Position += direction * deltaTime * speed;
            if (Position.X > Program.ScreenW)
            {
                Reflect(new Vector2f(-1, 0));
            }
            if (Position.X < 0 + 40)
            {
                Reflect(new Vector2f(1, 0));
            }
            if (shotTimer >= 1)
            {
                scene.spawn(new InvaderBullet(direction)
                {Position = new Vector2f(Position.X + direction.X  + (50 * direction.X), Position.Y + (30 * direction.Y)), Rotation = Rotation});
                shotTimer = 0;
            }
            shotTimer += deltaTime;
            if (Position.Y >= Program.ScreenH + 40){
                dead = true;
            }
        }
        private void Reflect(Vector2f normal)
        {
            direction -= normal * (2 * (direction.X * normal.X + direction.Y * normal.Y));
            if (normal.X == 1)
            {
                Rotation = 100;
            }
            else if (normal.X == -1)
            {
                Rotation = -100;
            }
        }
        protected override void CollideWith(Scene scene, Entity entity)
        {
            if (entity is PlayerBullet){
                dead = true;
                entity.dead = true;
            }  
        }
    }
}
