using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards
{
    class Card : IDrawable
    {
        public Texture2D sprite = null;
        public Vector2 position = new Vector2(0, 0);
        public String name = "no name";
        public String cardText = "no text";

        public void Draw(SpriteBatch spriteBatch)
        {
            if (sprite != null)
                spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 0.22f, SpriteEffects.None, 1.0f);
        }

        public void Update(GameTime gameTime)
        {
            // something?
        }

        public void Apply(Player player, Field field, Card card, int index)
        {
            // nothing
        }

        public void Apply(Player player, Field field, MonsterCard card, int index)
        {
            // nothing
        }
    }
}
