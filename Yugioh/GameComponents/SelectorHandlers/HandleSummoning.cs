using Microsoft.Xna.Framework.Input;
using Yugioh.Cards.MonsterCardComponents;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSummoning : SelectorHandler, ISelectorHandler
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
                Summon.Apply(p1, p1Field, selector.summoning, selector.index);
                selector.summoning = null;
            }
        }
    }
}
