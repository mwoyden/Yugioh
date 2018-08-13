using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    class Selector : IDrawable
    {
        public Texture2D line;
        public Card selected;
        public int lineWidth;
        public Color color;
        public SelectedArea area;
        public int index;

        // Scalar for card buffer
        public int s = 4;
        
        // Card defaults
        public Vector2 defaultCardSize = new Vector2(350, 510);
        public Vector2 defaultCardPosition = new Vector2(0, 0);

        public Selector(SpriteBatch spriteBatch, Card card)
        {
            line = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            line.SetData<Color>(new Color[] { Color.White });
            lineWidth = 4;
            color = Color.Black;
            selected = card;
            area = SelectedArea.P1_HAND;
            index = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (selected.sprite == null)
            {
                spriteBatch.Draw(line, new Rectangle((int)defaultCardPosition.X - s*2, (int)defaultCardPosition.Y - s, lineWidth, (int)(defaultCardSize.Y * 0.22f) + s + lineWidth), color); // Left
                spriteBatch.Draw(line, new Rectangle((int)defaultCardPosition.X - s*2, (int)defaultCardPosition.Y - s*2, (int)(defaultCardSize.X * 0.22f) + s*2 + lineWidth, lineWidth), color); // Top
                spriteBatch.Draw(line, new Rectangle((int)defaultCardPosition.X + (int)(defaultCardSize.X * 0.22f) + s, (int)defaultCardPosition.Y - s*2, lineWidth, (int)(defaultCardSize.Y * 0.22f) + s*2 + lineWidth), color); // Right
                spriteBatch.Draw(line, new Rectangle((int)defaultCardPosition.X - s*2, (int)defaultCardPosition.Y + s + (int)(defaultCardSize.Y * 0.22f), (int)(defaultCardSize.X * 0.22f) + s * 3 + lineWidth, lineWidth), color); // Bottom
            }
            else
            {
                spriteBatch.Draw(line, new Rectangle((int)selected.position.X - s*2, (int)selected.position.Y - s, lineWidth, (int)(selected.sprite.Height * 0.22f) + s + lineWidth), color); // Left
                spriteBatch.Draw(line, new Rectangle((int)selected.position.X - s*2, (int)selected.position.Y - s*2, (int)(selected.sprite.Width * 0.22f) + s*2 + lineWidth, lineWidth), color); // Top
                spriteBatch.Draw(line, new Rectangle((int)selected.position.X + (int)(selected.sprite.Width * 0.22f) + s, (int)selected.position.Y - s*2, lineWidth, (int)(selected.sprite.Height * 0.22f) + s*2 + lineWidth), color); // Right
                spriteBatch.Draw(line, new Rectangle((int)selected.position.X - s*2, (int)selected.position.Y + s + (int)(selected.sprite.Height * 0.22f), (int)(selected.sprite.Width * 0.22f) + s * 3 + lineWidth, lineWidth), color); // Bottom
            }
        }
    }
}
