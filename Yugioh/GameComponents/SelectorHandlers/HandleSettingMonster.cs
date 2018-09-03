using Microsoft.Xna.Framework.Input;
using Yugioh.Cards.MonsterCardComponents;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSettingMonster : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            if (p1Field.monsterZone[selector.index].sprite == null)
                selector.defaultPosition = p1Field.monsterPositions[selector.index];
            selector.selected = p1Field.monsterZone[selector.index];

            // Handle Summon
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                selector.state = SelectedState.P1_MONSTER_ZONE;
                selector.selected = p1Field.monsterZone[selector.index];
                SetMonster.Apply(p1, p1Field, selector.summoning, selector.index);
                selector.summoning = null;
                p1.canNormalSummon = false;
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.SUMMON_OR_SET;
                selector.action = SelectedAction.SUMMON;
                selector.selected = selector.summoning;
                selector.index = 0;
                selector.defaultPosition = selectorPositions[1];
            }
        }
    }
}
