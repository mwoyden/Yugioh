using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    /// <summary>
    /// Extension of the Player class that represents an AI
    /// </summary>
    class AIPlayer : Player
    {
        public AIPlayer()
        {
            name = "Yugi";
            lifePoints = 8000;
            hand = new List<Card>();
            sacrificed = new List<MonsterCard>();
        }
    }
}
