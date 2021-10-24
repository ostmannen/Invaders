using System.Runtime.InteropServices.ComTypes;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Drawing;
using System;
using SFML.System;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.Linq;

namespace Invaders
{
    public class Gui
    {
        private Text scoreText;
        private Text hpText;
        private float score = 0;
        private int playerHp = 3;
        public Gui(AssetManager asset, Scene scene)
        {
            scoreText = new Text();
            hpText = new Text();
            scoreText.CharacterSize = 24;
            scoreText.Font = asset.LoadFont("pixel-font");
            hpText.CharacterSize = 24;
            hpText.Font = asset.LoadFont("pixel-font");
            scene.events.LoseHealth += OnLoseHealth;
        }
        public void Update(Scene scene, float deltaTime)
        {
            score += deltaTime * 100;
        }
        public void Render(RenderTarget target)
        {
            scoreText.DisplayedString = $"Score: {(int)score}";
            scoreText.Position = new Vector2f(24, 5);
            target.Draw(scoreText);
            hpText.DisplayedString = $"{(int)playerHp} hp";
            hpText.Position = new Vector2f(Program.ScreenW - 50, 10);
            target.Draw(hpText);

        }
        public void OnLoseHealth(Scene scene, int amount){
            playerHp--;
        }
    }
}
