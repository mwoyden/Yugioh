using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class FeralImp : MonsterCard
    {
        public FeralImp(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.feralImp;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Feral Imp";
            attack = 800;
            defense = 2000;
            effect = false;
            stars = 4;
            cardText = "A delicate elf that lacks offense, but has a terrific defense backed by mystical power.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.FIEND;
            attribute = MonsterAttribute.DARK;
        }
    }
}
