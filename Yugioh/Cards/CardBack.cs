using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Yugioh.GameComponents;

namespace Yugioh.Cards
{
    class CardBack : Card
    {
        /// <summary>
        /// Back of a card. Used for decks, face down cards, etc.
        /// </summary>
        /// <param name="spriteManager">Contains car_back sprite</param>
        /// <param name="x">x position on screen</param>
        /// <param name="y">y position on screen</param>
        public CardBack(SpriteManager spriteManager, float x, float y)
        {
            sprite = spriteManager.cardBack;
            position = new Vector2(x, y);
        }
    }
}
