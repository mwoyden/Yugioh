using Microsoft.Xna.Framework;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.TrapCards.Effects;

namespace Yugioh.Cards.TrapCards.Cards
{
    class TrapHole : TrapCard
    {
        public TrapHole(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.trapHole;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Trap Hole";
            cardText = "When your opponent Normal or Flip Summons a monster with 1000 or more ATK: Target that monster; destroy that target.";
            trapType = TrapType.NORMAL;
            effect = new TrapHoleEffect();
            hooks.Add(TrapHook.NORMAL_SUMMON);
            hooks.Add(TrapHook.FLIP_SUMMON);
        }
    }
}
