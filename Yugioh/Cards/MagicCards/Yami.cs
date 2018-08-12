using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class Yami : MagicCard
    {
        public Yami(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.yami;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Yami";
            cardText = "Increases the ATK and DEF of all Fiend and Spellcaster-Type monsters by 200 points. Also decreases the ATK and DEF of all Fairy-Type monsters by 200 points.";
            magicType = MagicType.FIELD;
        }
    }
}
