using System.Collections.Generic;
using Yugioh.Cards.CardProperties;
using Yugioh.Cards.TrapCards;
using Yugioh.GameComponents;

namespace Yugioh.Cards
{
    abstract class TrapCard : Card
    {
        // Trap Card properties
        public TrapType trapType = TrapType.NONE;
        public bool activated = false;
        public ITrapEffect effect = null;
        public List<TrapHook> hooks = new List<TrapHook>();

        /// <summary>
        /// Checks to see if a hook triggered this trap card
        /// </summary>
        /// <param name="p">player who's hook list is being checked.</param>
        /// <returns>Index of the card that caused the hook.</returns>
        public int HookTriggered(Player p)
        {
            foreach (TrapHook hook in hooks)
                if (p.hooks.ContainsKey(hook))
                {
                    int temp = p.hooks[hook];
                    p.hooks.Remove(hook);
                    return temp;
                }
            return -1;
        }
    }
}
