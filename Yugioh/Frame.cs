using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Yugioh.Cards;
using Yugioh.GameComponents;

namespace Yugioh
{
    class Frame : IDrawable
    {
        public Texture2D background;
        public List<IDrawable> components;
        public static readonly string LIFE_POINTS = "LP: ";
        public SpriteFont font;
        public List<Vector2> lifePointPositions = new List<Vector2>()
        {
            new Vector2(822, 782),
            new Vector2(822, 50),
        };
        public Vector2 phasePosition = new Vector2(400, 350);

        public Frame(SpriteManager spriteManager)
        {
            background = spriteManager.gameMat;
            font = spriteManager.font;
            components = new List<IDrawable>();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Rectangle(0, 0, background.Width, background.Height), null, Color.White, 0, new Vector2(0, 0), SpriteEffects.None, 0.0f);
            components.ForEach(c => c.Draw(spriteBatch));
        }

        public void DrawUI(SpriteBatch spriteBatch, Player p1, Player p2, Turn turn)
        {
            // Draw lifepoints
            spriteBatch.DrawString(font, LIFE_POINTS + p1.lifePoints, lifePointPositions[0], Color.Black);
            spriteBatch.DrawString(font, LIFE_POINTS + p2.lifePoints, lifePointPositions[1], Color.Black);

            // Draw the currentPhase
            if (turn.Equals(Turn.P1))
                spriteBatch.DrawString(font, p1.currentPhase.ToString(), phasePosition, Color.Black);
            else
                spriteBatch.DrawString(font, p2.currentPhase.ToString(), phasePosition, Color.Black);
        }
    }
}
