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
        /// <param name="spriteManager">Contains cardBackk sprite</param>
        /// <param name="position">position on screen</param>
        public CardBack(SpriteManager spriteManager, Vector2 position)
        {
            sprite = spriteManager.cardBack;
        }

        public CardBack(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }
    }
}
