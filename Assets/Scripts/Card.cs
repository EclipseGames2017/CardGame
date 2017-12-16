using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipseStudios.CardGame
{
    [System.Serializable]
    public class Card
    {
        public string Name;
        public string Name_En;
        public string Occupation;
    }

    [System.Serializable]
    public class CardList
    {
        public Card[] cards;

        public CardList(Card[] cards)
        {
            this.cards = cards;
        }

        public Card this[int index]
        {
            get
            {
                return cards[index];
            }
            set
            {
                cards[index] = value;
            }
        }

        public int Length
        {
            get
            {
                return cards.Length;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();
        }
    }
}