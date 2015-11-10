using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardCollection : MonoBehaviour {

    [SerializeField]
    private CardList m_cardList;
    [SerializeField]
    private int[] m_hand;

    public List<CardElement> GetHand()
    {
        List<CardElement> elems = new List<CardElement>();

        foreach (int i in m_hand)
        {
            elems.Add(m_cardList.Cards[i]);
        }

        return elems;
    }

    public CardElement GetCardById(int id)
    {
        return m_cardList.GetById(id);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
