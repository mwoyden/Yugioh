using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class SilverFang : MonsterCard
    {
        public SilverFang(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.silverFang;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Silver Fang";
            attack = 1200;
            defense = 800;
            effect = false;
            stars = 3;
            cardText = "A snow wolf that's beautiful to the eye, but absolutely vicious in battle.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.BEAST;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
