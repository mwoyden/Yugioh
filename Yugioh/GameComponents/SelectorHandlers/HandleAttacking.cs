using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;
using Yugioh.Cards.MonsterCardComponents;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleAttacking : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            if (p2Field.monsterZone[selector.index].sprite == null)
                selector.defaultPosition = p2Field.monsterPositions[selector.index];
            selector.selected = p2Field.monsterZone[selector.index];

            // Handle Attack
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter) && 
                (p1.currentPhase.Equals(Phase.MAIN) || p1.currentPhase.Equals(Phase.BATTLE)))
            {
                selector.state = SelectedState.P2_MONSTER_ZONE;
                selector.selected = p2Field.monsterZone[selector.index];
                selector.defaultPosition = p2Field.monsterPositions[selector.index];
                if (selector.selected is MonsterCard) // Can't attack empty field spaces
                    Attack.Apply(p1, p2, p1Field, p2Field, selector.attacking, (MonsterCard)selector.selected, selector.index);
                else if (!p2Field.HasMonsters() || selector.attacking.canAttackDirectly) // Attack directly
                    Attack.Apply(p1, p2, p1Field, p2Field, selector.attacking, null, selector.index);
                selector.attacking = null;
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.BATTLE_SELECT;
                selector.action = SelectedAction.ATTACK;
                selector.selected = selector.attacking;
                selector.index = 0;
                selector.defaultPosition = selectorPositions[0];
            }
        }
    }
}
