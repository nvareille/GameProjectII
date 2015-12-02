using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardCollection : MonoBehaviour {

    [SerializeField]
    private CardList m_cardList;
    [SerializeField]
    private List<int> m_hand;

    public List<CardElement> DrawCard()
    {
        List<CardElement> elems = new List<CardElement>();

        foreach (int i in m_hand)
        {
            elems.Add(m_cardList.Cards[i]);
        }

        return elems;
    }

    public List<CardElement> GetCollection()
    {
        List<CardElement> elems = new List<CardElement>();

        foreach(CardElement obj in m_cardList.Cards)
        {
            elems.Add(obj);
        }

        return elems;
    }

    public CardElement GetCardById(int id)
    {
        return m_cardList.GetById(id);
    }

    public void SetDeck(List<int> list)
    {
        m_hand = list;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
