using System.Collections;
using System.Collections.Generic;
using System.Text;
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

        public void AddCard()
        {
            AddCard(new Card());
        }
        public void AddCard(Card newCard)
        {
            cards.Add(newCard);
        }

        public void RemoveAt(int i)
        {
            cards.RemoveAt(i);
        }

        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();
        }

        public void Shuffle()
        {
            List<int> indexes = new List<int>();
            for (int i = 0; i < cards.Count; i++)
                indexes.Add(i);

            List<Card> tempList = new List<Card>();
            
            while (indexes.Count > 0)
            {
                int i = indexes[Random.Range(0, indexes.Count)];
                indexes.Remove(i);
                tempList.Add(cards[i]);
            }

            cards.Clear();
            cards.AddRange(tempList);
        }

        /// <summary>
        /// Gets the card at the given index.
        /// </summary>
        /// <param name="index">The index of the card to draw.</param>
        /// <param name="removeCard">Whether to remove the card from the list.  Defaults to true.</param>
        /// <returns>Returns the card drawn from the list.</returns>
        public Card DrawCard(int index, bool removeCard = true)
        {
            Card temp = cards[index];
            if (removeCard)
                cards.RemoveAt(index);
            return temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < cards.Count; i++)
            {
                sb.AppendFormat("{0}: {1}{2}", i, cards[i].Name, (i < cards.Count - 1) ? "\n" : "");
            }

            return sb.ToString();
        }
    }
}