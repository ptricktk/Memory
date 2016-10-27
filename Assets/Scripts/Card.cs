using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Card : MonoBehaviour
{

    public static bool Do_Not = false;

    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized;

    private Sprite _cardBack;
    private Sprite _cardFace;

    private GameObject _manager;

    void Start()
    {
        _state = 1;
        _manager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void SetupGraphics()
    {
        _cardBack = _manager.GetComponent<GameManager>().getCardBack();
        _cardFace = _manager.GetComponent<GameManager>().getCardFace(_cardValue);

        flipCard();
    }

    public void flipCard()
    {
        if (_state == 0)
            _state = 1;
        else if (_state == 1)
            _state = 0;


        if (_state == 0 && !Do_Not)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1 && !Do_Not)
            GetComponent<Image>().sprite = _cardFace;
    }

    public int CardValue
    {
        get { return _cardValue; }
        set { _cardValue = value; }
    }

    public int State
    {
        get { return _state; }
        set { _state = value; }
    }

    public bool Initialized
    {
        get { return _initialized; }
        set { _initialized = value; }
    }

    public void falseCheck()
    {
        StartCoroutine(pause());
    }

    IEnumerator pause()
    {
        yield return new WaitForSeconds(1);
        if (_state == 0)
            GetComponent<Image>().sprite = _cardBack;
        else if (_state == 1)
            GetComponent<Image>().sprite = _cardFace;

        Do_Not = false;
    }
}
