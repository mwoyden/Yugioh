using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yugioh.Cards.CardProperties;

namespace Yugioh.Cards
{
    abstract class MagicCard : Card
    {
        // Magic Card properties
        public MagicType magicType = MagicType.NONE;
        public bool activated = false;

        public void Apply(MagicCard card)
        {
            // nothing
        }
    }
}
