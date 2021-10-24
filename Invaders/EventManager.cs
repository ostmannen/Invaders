using System;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

namespace Invaders
{
    public delegate void ValueChangedEvent(Scene scene, int value);
    public class EventManager
    {
        public event ValueChangedEvent LoseHealth;
        private int lostHealth;
        public void PublishShot(int amount) => lostHealth += amount;
        public void Update(Scene scene){
            if (lostHealth != 0){
                LoseHealth?.Invoke(scene, lostHealth);
                lostHealth = 0;
            }
        }
    }
}
