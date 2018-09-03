using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.MonsterCardComponents;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleBattleSelection : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.action = SelectedAction.DEFEND;
                selector.defaultPosition = selectorPositions[1];
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.action = SelectedAction.ATTACK;
                selector.defaultPosition = selectorPositions[0];
            }
            else if (state.IsKeyDown(Keys.Up) && previousState.IsKeyUp(Keys.Up)) // same as left
            {
                selector.action = SelectedAction.ATTACK;
                selector.defaultPosition = selectorPositions[0];
            }
            else if (state.IsKeyDown(Keys.Down) && previousState.IsKeyUp(Keys.Down))
            {
                selector.action = SelectedAction.SACRIFICE;
                selector.defaultPosition = selectorPositions[2];
            }

            // Select Action
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.action.Equals(SelectedAction.ATTACK))
                {
                    if (selector.selected is MonsterCard)
                    {
                        selector.attacking = (MonsterCard)selector.selected;
                        if (selector.attacking.canAttack && (p1.currentPhase.Equals(Phase.BATTLE) || p1.currentPhase.Equals(Phase.MAIN)))
                        {
                            selector.attacking.mode = MonsterPosition.ATTACK;
                            selector.state = SelectedState.ATTACKING;
                        }
                        else
                        {
                            selector.attacking = null;
                            selector.state = SelectedState.P1_MONSTER_ZONE;
                        }
                    }
                }
                else if (selector.action.Equals(SelectedAction.DEFEND))
                {
                    Defend.Apply(p1, p1Field, (MonsterCard)selector.selected);
                    selector.state = SelectedState.P1_MONSTER_ZONE;
                }
                else if (selector.action.Equals(SelectedAction.SACRIFICE))
                {
                    Sacrifice.Apply(p1, p1Field, (MonsterCard)selector.selected, selector.index);
                    selector.state = SelectedState.P1_MONSTER_ZONE;
                }
                selector.selected = p1Field.monsterZone[selector.index];
                selector.defaultPosition = p1Field.monsterPositions[selector.index];
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.P1_MONSTER_ZONE;
                selector.action = SelectedAction.NONE;
            }
        }
    }
}
