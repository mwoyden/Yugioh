using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1Hand : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 6);
            if (p1.hand[selector.index].sprite == null)
                selector.defaultPosition = p1.handPositions[selector.index];
            selector.selected = p1.hand[selector.index];

            // Handles up and down
            HandleUpAndDown(selector, SelectedState.P1_MAGIC_AND_TRAP_ZONE, p1Field.magicAndTrapZone, p1Field.magicAndTrapPositions,
                                    SelectedState.P2_MAGIC_AND_TRAP_ZONE, p2Field.magicAndTrapZone, p2Field.magicAndTrapPositions,
                                    state, previousState);

            // Handles actions
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.selected is MonsterCard)
                {
                    selector.state = SelectedState.SUMMON_OR_SET;
                    selector.action = SelectedAction.SUMMON;
                    selector.summoning = (MonsterCard)selector.selected;
                    selector.index = 0;
                    selector.defaultPosition = selectorPositions[0];
                }
                else if (selector.selected is MagicCard)
                {
                    selector.state = SelectedState.SET_OR_ACTIVATE;
                    selector.action = SelectedAction.SET;
                    selector.settingMagic = (MagicCard)selector.selected;
                    selector.index = 0;
                    selector.defaultPosition = selectorPositions[0];
                }
                else if (selector.selected is TrapCard)
                {
                    selector.state = SelectedState.SETTING_TRAP;
                    selector.settingTrap = (TrapCard)selector.selected;
                    selector.index = 0;
                    selector.selected = p1Field.magicAndTrapZone[0];
                    selector.defaultPosition = p1Field.magicAndTrapPositions[0];
                }
            }
        }
    }
}
