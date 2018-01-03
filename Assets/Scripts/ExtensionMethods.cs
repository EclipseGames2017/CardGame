using System.Collections.Generic;
using UnityEngine;

namespace EclipseStudios.CardGame
{
    public static class ExtensionMethods
    {
        public static void Shuffle(this List<Card> cards)
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
    }
}
