using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace EclipseStudios.CardGame
{
    public class Test : MonoBehaviour
    {
        public TextAsset dataFile;

        Text uiText;

        CardList cards;

        void Start()
        {
            uiText = GetComponent<Text>();

            cards = JsonUtility.FromJson<CardList>(dataFile.text);

            int i = Random.Range(0, cards.Length);
            uiText.text = cards[i].Name_En + "(" + cards[i].Name + ")";
        }
    }
}