using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleInP1MagicAndTrapZone : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {            
            // Handles left and right
            HandleLeftRightWithMaxIndex(selector, state, previousState, 4);
            // Handles all necessary actions in the given zone (including up and down)
            PositionController.Builder builder = new PositionController.Builder();
            PositionController controller = builder.WithSelector(selector)
                .WithActiveZone(p1Field.magicAndTrapZone)
                .WithActiveZonePositions(p1Field.magicAndTrapPositions)
                .WithUpArea(SelectedState.P1_MONSTER_ZONE)
                .WithUpZone(p1Field.monsterZone)
                .WithUpPositions(p1Field.monsterPositions)
                .WithDownArea(SelectedState.P1_HAND)
                .WithDownZone(p1.hand)
                .WithDownPositions(p1.handPositions)
                .WithCurrentState(state)
                .WithPreviousState(previousState)
                .Build();
            HandleInZone(controller);

            // Handles actions
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.selected is MagicCard)
                {
                    selector.settingMagic = (MagicCard)selector.selected;
                    // Activate effect
                    selector.settingMagic.effect.Activate(p1, p2, p1Field, p2Field);
                    // Destory card from hand
                    selector.state = SelectedState.P1_MAGIC_AND_TRAP_ZONE;
                    selector.action = SelectedAction.NONE;
                    selector.index = p1Field.magicAndTrapZone.IndexOf(selector.selected);
                    p1Field.magicAndTrapZone[selector.index] = new Card();
                    p1Field.graveYard.Add(selector.settingMagic);
                    selector.settingMagic = null;
                }
                else if (selector.selected is TrapCard)
                {
                    //activate trap
                }
            }
        }
    }
}
