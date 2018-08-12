using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.MonsterCards;

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
        public MonsterType monsterType;
        public MonsterSubType subType;
        public MonsterAttribute attribute;
        public MonsterPosition mode;
        
        public MonsterCard()
        {
            // super fields
            name = "no name";
            cardText = "no text";

            // member fields
            attack = 0;
            defense = 0;
            effect = false;
            stars = 0;
            monsterType = MonsterType.NONE;
            subType = MonsterSubType.NONE;
            attribute = MonsterAttribute.NONE;
            mode = MonsterPosition.NONE;
        }

        public void Apply(MonsterCard monster)
        {
            // nothing
        }
    }
}
