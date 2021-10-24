using System.Collections.Generic;
using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace Invaders
{
    public class Scene
    {
        public List<Entity> entities;
        public readonly AssetManager assets;
        public readonly EventManager events;
        private Spawner Spawner ;
        private Gui gui;
        public Scene(){
            events = new EventManager();
            assets = new AssetManager();
            Restart();
        }
        public void Restart(){
            entities = new List<Entity>();
            Spawner = new Spawner();   
            gui = new Gui(assets, this);  
            spawn(new Player(){Position = new Vector2f(18,18)}); 
        }
        public void spawn(Entity entity){
            entities.Add(entity);
            entity.Create(this);
        }
        public void RenderAll(RenderTarget target){
            for (int i = 0; i < entities.Count; i++)
            {
                entities[i].render(target);
            }
            gui.Render(target);
        }
        public void UpdateAll(float deltaTime){
            events.Update(this);
            Spawner.update(this, deltaTime);
            gui.Update(this, deltaTime);
            for (int i = 0; i < entities.Count; i++)
            {
                Entity entity = entities[i];
                entity.Update(deltaTime, this);
            }
            for (int i = 0; i < entities.Count;)
            {
                Entity entity = entities[i];
                if (entity.dead == true)
                {
                    entities.RemoveAt(i);
                }
                else i++;
            }
        }
        
        public IEnumerable<Entity> FindIntersects(FloatRect bounds)
        {
            int lastEntity = entities.Count - 1;
            for (int i = lastEntity; i >= 0; i--)
            {
                Entity entity = entities[i];
                if (entity.dead) continue;
                if (entity.Bounds.Intersects(bounds))
                {
                    yield return entity;
                }
            }
        }
    }
}
