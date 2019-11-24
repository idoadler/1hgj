
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public player p;

    public Card[] cards;

    public Sprite[] numbers;

    private CardData[] cardsData = new CardData[3];
    private Vector3[] dirs = new Vector3[] { Vector3.up, Vector3.left, Vector3.right };

    private void Start()
    {
        for(int i=0; i<3; i++)
        {
            cards[i].id = i;
            cards[i].parent = this;
        }

        RandomizeCards();
    }


    public void RandomizeCards()
    {
        for (int i = 0 ; i < 3; i++)
        {
            if (Random.value < 0.4)
            {
                cards[i].arrow.transform.localRotation = Quaternion.Euler(0, 0, 0);
                cardsData[i].dir = 0;
            }
            else if (Random.value < 0.5)
            {
                cards[i].arrow.transform.localRotation = Quaternion.Euler(0, 0, 90);
                cardsData[i].dir = 1;
            }
            else
            {
                cards[i].arrow.transform.localRotation = Quaternion.Euler(0, 0, -90);
                cardsData[i].dir = 2;
            }

            int r = Random.Range(0, 3);
            cards[i].num.sprite = numbers[r];
            cardsData[i].add = r + 1;

            if (Random.value < 0.25)
            {
                cards[i].num.sprite = numbers[3];
                cards[i].plus.gameObject.SetActive(false);
            }
            else
            {
                cards[i].plus.gameObject.SetActive(true);
            }
        }
    }

    public struct CardData
    {
        public int dir;
        public int add;
    }
}
