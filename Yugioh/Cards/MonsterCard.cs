using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards
{
    /// <summary>
    /// An extension of the Card class that represents a monster card.
    /// </summary>
    abstract class MonsterCard : Card
    {
        // Monster Card properties
        public int attack;
        public int defense;
        public bool effect;
        public int stars;
        public bool canAttack;
        public bool canAttackDirectly;
        public bool canChangePosition;
        public MonsterType monsterType;
        public MonsterSubType subType;
        public MonsterAttribute attribute;
        public MonsterPosition mode = MonsterPosition.NONE;

        public MonsterCard()
        {
            // super fields
            name = "no name";
            cardText = "no text";

            // member fields
            attack = 0;
            defense = 0;
            effect = false;
            canAttack = true;
            canAttackDirectly = false;
            canChangePosition = false;
            stars = 0;
            monsterType = MonsterType.NONE;
            subType = MonsterSubType.NONE;
            attribute = MonsterAttribute.NONE;
            mode = MonsterPosition.NONE;
        }

        public new void Draw(SpriteBatch spriteBatch)
        {
            if (sprite == null)
                return;
            if (mode.Equals(MonsterPosition.ATTACK))
                spriteBatch.Draw(sprite, position, null, Color.White, 0, new Vector2(0, 0), 0.22f, SpriteEffects.None, 1.0f);
            else if (mode.Equals(MonsterPosition.FACE_DOWN_DEFENSE) || mode.Equals(MonsterPosition.DEFENSE))
            {
                Vector2 origin = new Vector2(sprite.Width / 2f - 250, sprite.Height / 2f + 170); // yeah idfk
                spriteBatch.Draw(sprite, position, null, Color.White, (float)Math.PI / 2.0f, origin, 0.22f, SpriteEffects.None, 1.0f);
            }

        }
    }
}
