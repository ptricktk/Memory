using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public Sprite[] cardFaces;
    public Sprite cardBack;
    public GameObject[] cards;
    public Text matchText;

    private bool _init =false;
    private int _matches = 0;

	// Update is called once per frame
	void Update () {
        if (!_init)
            InitializeCards();

        if (Input.GetMouseButtonUp(0))
            CheckCards();

	}

    void InitializeCards()
    {
        for (int id = 0; id < 2; id++)
        {
            for (int i = 0; i < (cards.Length/2); i++)
            {

                bool test = false;
                int choice  = 0;

                while(!test)
                {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().Initialized);
                }
                cards[choice].GetComponent<Card>().CardValue = i;
                cards[choice].GetComponent<Card>().Initialized = true;

            }

            _matches = (cards.Length / 2);
        }

        foreach(GameObject c in cards)
        {
            c.GetComponent<Card>().SetupGraphics();
            if (!_init)
                _init = true;
        }
    }

    public Sprite getCardBack()
    {
        return cardBack;
    }

    public Sprite getCardFace(int i)
    {
        return cardFaces[i];
    }

    void CheckCards()
    {
        List<int> c = new List<int>();
        for (int i = 0; i < cards.Length; i++)
        {
            if (cards[i].GetComponent<Card>().State == 1)
                c.Add(i);
        }

        if (c.Count == 2)
        {
            CardComparison(c);
        }
    }

    void CardComparison(List<int> c) {
        Card.Do_Not = true;

        int x = 0;

        if(cards[c[0]].GetComponent<Card>().CardValue == cards[c[1]].GetComponent<Card>().CardValue)
        {
            x = 2;
            _matches--;
            matchText.text = "Number of matches to make: " + _matches;
            if (_matches == 0)
                SceneManager.LoadScene("level_0");
        }

        for (int i= 0; i < c.Count; i++)
        {
            cards[c[i]].GetComponent<Card>().State = x;
            cards[c[i]].GetComponent<Card>().falseCheck();
        }
    }
}

