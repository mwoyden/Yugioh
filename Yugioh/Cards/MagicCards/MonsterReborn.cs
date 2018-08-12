using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MagicCards
{
    class MonsterReborn : MagicCard
    {
        public MonsterReborn(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.monsterReborn;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Monster Reborn";
            cardText = "Target 1 monster in either player's Graveyard; Special Summon it.";
            magicType = MagicType.NORMAL;
        }
    }
}
