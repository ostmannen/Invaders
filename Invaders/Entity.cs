using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Invaders
{
    public abstract class Entity
    {
        private string textureName;

        protected readonly Sprite sprite;
        public bool dead;
        protected Entity(string textureName){
            this.textureName = textureName;
            sprite = new Sprite();
            
        }
        public virtual FloatRect Bounds => sprite.GetGlobalBounds();
        public Vector2f Position{
            get => sprite.Position;
            set => sprite.Position = value;
        }
        public virtual void Create(Scene scene){
            sprite.Texture = scene.assets.LoadTexture(textureName);
        }
        public void render(RenderTarget target){
            target.Draw(sprite);
        }
        public virtual void Update(float deltaTime, Scene scene){
            foreach (Entity found in scene.FindIntersects(Bounds)){
                CollideWith(scene, found);
            }
        }
        protected virtual void CollideWith(Scene scene, Entity entity){

        }
    }
}
