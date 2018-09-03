using Yugioh.GameComponents;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards.MonsterCardComponents
{
    class Attack
    {
        public static void Apply(Player attackingPlayer, Player attackedPlayer, 
                                Field attackingField, Field attackedField, 
                                MonsterCard attacking, MonsterCard attacked, int index)
        {
            // Enter battle phase
            if (!attackingPlayer.currentPhase.Equals(Phase.BATTLE))
                attackingPlayer.currentPhase = Phase.BATTLE;

            // Check for direct attack
            if (attacked == null)
            {
                attackedPlayer.lifePoints -= attacking.attack;
                return;
            }

            // Check if monster was selected to attack (and not blank field space)
            if (attackedField.monsterZone[index].sprite == null)
                return;

            // Order of application here is important.
            // Apply to player and monster simultaneously
            if (attacked.mode.Equals(MonsterPosition.ATTACK))
            {
                if (attacked.attack < attacking.attack)
                {   // Attacked monster is destroyed
                    attackedField.graveYard.Add(attacked);
                    attackedField.monsterZone[index] = new Card();
                    attackedPlayer.lifePoints -= (attacking.attack - attacked.attack);
                }
                else if (attacked.attack > attacking.attack)
                {   // Attacking monster wasn't strong enough and dies
                    attackingField.graveYard.Add(attacking);
                    attackingField.monsterZone[index] = new Card();
                    attackingPlayer.lifePoints -= (attacked.attack - attacking.attack);
                }
                else
                {   // Same attack, both die
                    attackedField.graveYard.Add(attacked);
                    attackedField.monsterZone[index] = new Card();
                    attackingField.graveYard.Add(attacking);
                    attackingField.monsterZone[index] = new Card();
                }
            }
            else if (attacked.mode.Equals(MonsterPosition.DEFENSE) || attacked.mode.Equals(MonsterPosition.FACE_DOWN_DEFENSE))
            {
                if (attacked.defense < attacking.attack)
                {   // Attacked monster had lower defense and dies
                    attackedField.graveYard.Add(attacked);
                    attackedField.monsterZone[index] = new Card();
                }
                else if (attacked.defense > attacking.attack)
                {   // Attacking monster not strong enough, lose lifepoints 
                    attackingPlayer.lifePoints -= (attacked.attack - attacking.attack);
                    attacked.mode = MonsterPosition.DEFENSE;
                }
                else
                {
                    attacked.mode = MonsterPosition.DEFENSE;
                }
            }
            attacking.canAttack = false;
        }
    }
}
