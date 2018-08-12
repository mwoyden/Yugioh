using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCards
{
    class MammothGraveyard : MonsterCard
    {
        public MammothGraveyard(SpriteManager spriteManager)
        {
            // Game attributes
            sprite = spriteManager.mammothGraveyard;
            position = new Vector2(0, 0);

            // Card attributes
            name = "Mammoth Graveyard";
            attack = 1200;
            defense = 800;
            effect = false;
            stars = 3;
            cardText = "A mammoth that protects the graves of its pack and is absolutely merciless when facing grave-robbers.";
            monsterType = MonsterType.NORMAL;
            subType = MonsterSubType.DINOSAUR;
            attribute = MonsterAttribute.EARTH;
        }
    }
}
