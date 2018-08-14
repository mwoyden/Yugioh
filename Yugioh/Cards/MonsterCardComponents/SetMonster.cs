using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;
using System;

namespace Yugioh.Cards.MonsterCardComponents
{
    class SetMonster : MonsterCard
    {
        public static new void Apply(Player player, Field field, MonsterCard card, int index)
        {
            bool canSet = true;

            // Check for field space
            if (field.monsterZone[index].sprite != null)
                return;

            // Order of application here is important!!!!
            // Apply to player
            canSet = player.Play(card);
            if (!canSet)
                return;

            // Apply to card BEFORE setting to field.
            card.mode = MonsterPosition.FACE_DOWN_DEFENSE;

            // Apply to field
            field.monsterZone.RemoveAt(index);
            field.monsterZone.Insert(index, card);
        }
    }
}
