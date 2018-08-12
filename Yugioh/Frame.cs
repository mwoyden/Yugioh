using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh
{
    class Frame : IDrawable
    {
        public Texture2D background;
        public List<IDrawable> components;

        public Frame(SpriteManager spriteManager)
        {
            background = spriteManager.gameMat;
            components = new List<IDrawable>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            components.ForEach(c => c.Draw(spriteBatch));
        }
    }
}
