using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Yugioh.Cards;

namespace Yugioh.GameComponents
{
    class Field
    {
        public List<Card> monsterZone;
        public List<Card> magicAndTrapZone;
        public List<Card> deck;
        public List<Card> graveYard;
        public List<Card> fusionZone;
        public Card fieldZone;

        /// <summary>
        /// All things you would find on a field, as defined by the universal player mat.
        /// </summary>
        public Field()
        {
            monsterZone = new List<Card>();
            magicAndTrapZone = new List<Card>();
            deck = new List<Card>();
            graveYard = new List<Card>();
            fusionZone = new List<Card>();
            fieldZone = null;

        }

        /// <summary>
        /// Algorithm used to shuffle the deck.
        /// </summary>
        public void Shuffle()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            int n = deck.Count;
            while (n > 1)
            {
                byte[] box = new byte[1];
                do provider.GetBytes(box);
                while (!(box[0] < n * (Byte.MaxValue / n)));
                int k = (box[0] % n);
                n--;
                //List<Card> deckAsArray = deck.ToList();
                Card card = deck[k];
                deck[k] = deck[n];
                deck[n] = card;
                //deck = new Stack<Card>(deckAsArray);
            }
        }
    }

}
