using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    class Selector : IDrawable
    {
        public Texture2D line;
        public Card selected;
        public MonsterCard summoning;
        public MagicCard settingMagic;
        public TrapCard settingTrap;
        public int lineWidth;
        public Color color;
        public SelectedState state;
        public SelectedAction action;
        public int index;

        // Scalar for card buffer
        public int s = 4;
        
        // Card defaults
        public Vector2 defaultCardSize = new Vector2(350, 510);
        public Vector2 defaultPosition = new Vector2(0, 0);
        public Vector2 zoomSpritePosition = new Vector2(800, 220);
        public List<Vector2> actionPositions = new List<Vector2>()
        {
            new Vector2(822, 688),
            new Vector2(972, 688)
        };

        public Selector(SpriteBatch spriteBatch, Card card)
        {
            // Make card selector outline
            line = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            line.SetData<Color>(new Color[] { Color.White });
            lineWidth = 4;

            // Other selector variables
            color = Color.Black;
            selected = card;
            summoning = null; //idk
            settingMagic = null; //idk
            settingTrap = null; //idk
            state = SelectedState.P1_HAND;
            action = SelectedAction.NONE;
            index = 0;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (state.Equals(SelectedState.SUMMON_OR_SET) || state.Equals(SelectedState.SET_OR_ACTIVATE))
                spriteBatch.Draw(line, new Rectangle((int)defaultPosition.X, (int)defaultPosition.Y, 10, 10), color);
            if (selected.sprite == null) // Draw the selector around the given image border
                DrawBorder(spriteBatch, (int)defaultPosition.X, (int)defaultPosition.Y, (int)defaultCardSize.X, (int)defaultCardSize.Y);
            else // Used to draw the selector around empty spaces so we can still traverse them
                DrawBorder(spriteBatch, (int)selected.position.X, (int)selected.position.Y, (int)selected.sprite.Width, (int)selected.sprite.Height);
        }

        /// <summary>
        /// Helper method for drawing a rectangular outline
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="x">x position</param>
        /// <param name="y">y position</param>
        /// <param name="w">width</param>
        /// <param name="h">height</param>
        private void DrawBorder(SpriteBatch spriteBatch, int x, int y, int w, int h)
        {
            spriteBatch.Draw(line, new Rectangle(x - s * 2, y - s, lineWidth, (int)(h * 0.22f) + s + lineWidth), color); // Left
            spriteBatch.Draw(line, new Rectangle(x - s * 2, y - s * 2, (int)(w * 0.22f) + s * 2 + lineWidth, lineWidth), color); // Top
            spriteBatch.Draw(line, new Rectangle((int)(x + (w * 0.22f) + s), y- s * 2, lineWidth, (int)(h * 0.22f) + s * 2 + lineWidth), color); // Right
            spriteBatch.Draw(line, new Rectangle(x - s * 2, y + s + (int)(h * 0.22f), (int)(w * 0.22f) + s * 3 + lineWidth, lineWidth), color); // Bottom
        }

        /// <summary>
        /// Draws the selected image in the large area as well as the small rectangular selector.
        /// </summary>
        /// <param name="spriteBatch">Thing that draws</param>
        /// <param name="spriteManager">Contains the font</param>
        public void DrawSelectedCard(SpriteBatch spriteBatch, SpriteManager spriteManager)
        {
            if (selected.sprite != null)
            {
                // Draws a zoomed image of the selected card
                spriteBatch.Draw(selected.sprite, zoomSpritePosition, null, Color.White, 0, new Vector2(0, 0), 0.9f, SpriteEffects.None, 1.0f);

                // States in which we still want to draw the options
                List<SelectedState> drawStates = new List<SelectedState>()
                {
                    SelectedState.P1_HAND,
                    SelectedState.SUMMON_OR_SET,
                    SelectedState.SET_OR_ACTIVATE
                };

                // Draws the appropriate actions depending on what type of card you selected
                if (drawStates.Contains(state))
                {
                    if (selected is MonsterCard)
                    {
                        spriteBatch.DrawString(spriteManager.font, "Summon", actionPositions[0], Color.Black);
                        spriteBatch.DrawString(spriteManager.font, "Set", actionPositions[1], Color.Black);
                    }
                    else if (selected is MagicCard)
                    {
                        spriteBatch.DrawString(spriteManager.font, "Set", actionPositions[0], Color.Black);
                        spriteBatch.DrawString(spriteManager.font, "Activate", actionPositions[1], Color.Black);
                    }
                    else if (selected is TrapCard)
                    {
                        spriteBatch.DrawString(spriteManager.font, "Set", actionPositions[0], Color.Black);
                    }
                }
            }
        }
    }
}
