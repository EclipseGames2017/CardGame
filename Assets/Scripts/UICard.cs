using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace EclipseStudios.CardGame
{
    public class UICard : MonoBehaviour
    {
        public Sprite normalFrame, deadFrame;

        public Text nameText, descriptionText;
        public Image image;
        Image frame;

        Animator animator;

        void Start()
        {
            animator = GetComponent<Animator>();
        }

        public void Show(Card card)
        {
            nameText.text = card.Name;
            descriptionText.text = card.Description;
            animator.SetTrigger("Show");
        }

        public void Select()
        {

        }
    }
}