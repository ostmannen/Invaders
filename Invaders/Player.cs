using System.Drawing;
using System.Reflection.Emit;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Player : Entity
    {
        private float speed = 300.0f;
        public const float width = 59.0f;
        public const float length = 42.0f;
        private float shotTimer = 0.5f;
        private float immortalTimer = 0;
        private Vector2f size;
        public float Hp = 3;
        public Player() : base("Untitled") { }
        public override void Create(Scene scene)
        {
            base.Create(scene);
            sprite.TextureRect = new IntRect(0, 0, 209, 148);
            Position = new Vector2f(190, 350);
            Vector2f playerTextureSize = (Vector2f)sprite.Texture.Size;
            sprite.Scale = new Vector2f(
                width / playerTextureSize.X,
                length / playerTextureSize.Y);
            size = new Vector2f(
                sprite.GetGlobalBounds().Width,
                sprite.GetGlobalBounds().Height
            );
            scene.events.LoseHealth += OnLoseHealth;
        }
        public override void Update(float deltaTime, Scene scene)
        {
            base.Update(deltaTime, scene);
            if (immortalTimer > 0)
            {
                immortalTimer -= deltaTime;
                if (immortalTimer < 0)
                {
                    immortalTimer = 0;
                    scene.events.LoseHealth += OnLoseHealth;
                }
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && Position.X <= Program.ScreenW - 40)
            {
                Position += new Vector2f(1, 0) * deltaTime * speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && Position.X >= 0 + 18)
            {
                Position += new Vector2f(-1, 0) * deltaTime * speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && Position.Y >= 0)
            {
                Position += new Vector2f(0, -1) * deltaTime * speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && Position.Y <= Program.ScreenH - 40)
            {
                Position += new Vector2f(0, 1) * deltaTime * speed;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space))
            {
                if (shotTimer <= 0)
                {
                    scene.spawn(new Bullet(this, new Vector2f(0,-1), new IntRect(0,0,5,18)) {Position = new Vector2f(Position.X + width / 2 - 3, Position.Y + -10) });
                    shotTimer = 0.5f;
                }
            }
            shotTimer -= deltaTime;
        }
        protected override void CollideWith(Scene scene, Entity entity)
        {
            
        }
        public void OnLoseHealth(Scene scene, int amount)
        {
            Hp--;
            if (Hp == 0)
            {
                dead = true;
                scene.Restart();
            }
            immortalTimer = 1;
            scene.events.LoseHealth -= OnLoseHealth;
        }
         public float Rotation
        {
            get => sprite.Rotation;
            set => sprite.Rotation = value;
        }
    }
}
