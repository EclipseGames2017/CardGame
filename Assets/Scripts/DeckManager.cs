using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EclipseStudios.CardGame
{
    public class DeckManager : MonoBehaviour
    {
        [Tooltip("The data file that holds all of the cards.")]
        public TextAsset cardData;

        [Tooltip("The amount of cards selected for each game.")]
        public int gameDeckSize = 100;

        /// <summary>
        /// The whole list of cards.
        /// </summary>
        List<Card> fullDeck;

        /// <summary>
        /// The list of cards used for the current game.
        /// </summary>
        List<Card> gameDeck;

        /// <summary>
        /// The list of cards that have been killed this game.
        /// </summary>
        List<Card> graveyard;

        void Awake()
        {
            fullDeck = new List<Card>(JsonConvert.DeserializeObject<Card[]>(cardData.text));

            fullDeck.Shuffle();

            for (int i = 0; i < gameDeckSize; i++)
            {
                // Draw a card from the full deck and add it to the game deck.
            }
        }
    }
}