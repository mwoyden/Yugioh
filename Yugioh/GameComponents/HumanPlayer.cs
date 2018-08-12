using System.Collections.Generic;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    /// <summary>
    /// Extension of the player class that represents you (or player 2?)
    /// </summary>
    class HumanPlayer : Player
    {
        public HumanPlayer()
        {
            name = "You";
            lifePoints = 8000;
            hand = new List<Card>();
            sacrificed = new List<MonsterCard>();
        }
    }
}
