using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Yugioh.GameComponents;

namespace Yugioh.Cards
{
    abstract class Card : IDrawable
    {
        public Texture2D sprite = null;
        public Vector2 position = new Vector2(0, 0);
        public String name = "no name";
        public String cardText = "no text";

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 0.2f, SpriteEffects.None, 1.0f);
        }

        public void Update(GameTime gameTime)
        {
            // something?
        }

        public void Apply(Player player)
        {
            // nothing
        }

        public void Apply(Field field)
        {
            // nothing
        }

        public void Apply(Card card)
        {
            // nothing
        }
    }
}
