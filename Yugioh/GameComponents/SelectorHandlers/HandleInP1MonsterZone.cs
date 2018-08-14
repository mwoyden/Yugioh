using Microsoft.Xna.Framework.Input;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1MonsterZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handles left and right
            HandleLeftRightWithFieldZone(selector, state, previousState);
            // Handles all necessary actions in the given zone (including up and down)
            HandleInZone(selector, p1Field.monsterZone, p1Field.monsterPositions, SelectedState.P2_MONSTER_ZONE, SelectedState.P1_MAGIC_AND_TRAP_ZONE,
                p2Field.monsterZone, p1Field.magicAndTrapZone, p2Field.monsterPositions, p1Field.magicAndTrapPositions, state, previousState);
        }
    }
}
