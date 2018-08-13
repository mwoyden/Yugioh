using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.TrapCards
{
    class CastleWalls : TrapCard
    {
        public CastleWalls(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.castleWalls;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Castle Walls";
            cardText = "Increase the DEF of 1 face-up monster on the field by 500 points until the end of this turn.";
            trapType = TrapType.NORMAL;
        }
    }
}
