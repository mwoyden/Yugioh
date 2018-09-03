using Microsoft.Xna.Framework.Input;
using Yugioh.Cards;

namespace Yugioh.GameComponents.SelectorHandlers
{
    class HandleSetOrActivate : SelectorHandler, ISelectorHandler
    {
        public void Handle(Selector selector, Player p1, Player p2, Field p1Field, Field p2Field,
            KeyboardState state, KeyboardState previousState)
        {
            // Handle Action select movement
            if (state.IsKeyDown(Keys.Right) && previousState.IsKeyUp(Keys.Right))
            {
                selector.action = SelectedAction.ACTIVATE;
                selector.defaultPosition = selectorPositions[1];
            }
            else if (state.IsKeyDown(Keys.Left) && previousState.IsKeyUp(Keys.Left))
            {
                selector.action = SelectedAction.SET;
                selector.defaultPosition = selectorPositions[0];
            }

            // Select Action
            if (state.IsKeyDown(Keys.Enter) && previousState.IsKeyUp(Keys.Enter))
            {
                if (selector.action.Equals(SelectedAction.SET))
                {
                    selector.state = SelectedState.SETTING_MAGIC;
                    selector.selected = p1Field.magicAndTrapZone[0];
                    selector.defaultPosition = p1Field.magicAndTrapPositions[0];
                }
                else if (selector.action.Equals(SelectedAction.ACTIVATE))
                {
                    // Activate effect
                    selector.settingMagic.effect.Activate(p1, p2, p1Field, p2Field);
                    // Destory card from hand
                    selector.state = SelectedState.P1_HAND;
                    selector.action = SelectedAction.NONE;
                    selector.index = p1.hand.IndexOf(selector.settingMagic);
                    p1.hand[selector.index] = new Card();
                    p1Field.graveYard.Add(selector.settingMagic);
                    selector.settingMagic = null;
                }
            }
            else if (state.IsKeyDown(Keys.Back) && previousState.IsKeyUp(Keys.Back))
            {
                selector.state = SelectedState.P1_HAND;
                selector.action = SelectedAction.NONE;
                selector.index = p1.hand.IndexOf(selector.settingMagic);
                selector.selected = selector.settingMagic;
                selector.settingMagic = null;
            }
        }
    }
}
