using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipseStudios.CardGame
{
    [System.Serializable]
    public class Card
    {
        public string Name;
        public string Description;
    }

    [System.Serializable]
    public class CardList
    {
        public List<Card> cards;

        public CardList(Card[] cards)
        {
            this.cards = new List<Card>(cards);
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
                return cards.Count;
            }
        }
        public int Count
        {
            get
            {
                return cards.Count;
            }
        }

        public void AddNewCard()
        {
            cards.Add(new Card());
        }

        public void RemoveAt(int i)
        {
            cards.RemoveAt(i);
        }

        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();
        }
    }
}