using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardSelectionPanel : MonoBehaviour {

    [SerializeField]
    private GameObject m_cardPrefab;
    [SerializeField]
    private GameObject m_grid;

    private CardCollection m_collection;

	// Use this for initialization
	void Start () {
        m_collection = GameObject.FindObjectOfType<CardCollection>();
        DisplayDeck();
	}

    void DisplayDeck()
    {
        List<CardElement> Elems = m_collection.GetHand();
        foreach(CardElement elem in Elems)
        {
            GameObject obj = Instantiate(m_cardPrefab);
            obj.transform.SetParent(m_grid.transform);
            Debug.Log(elem.GetName() + " is in your hand");
        }
    }

    public void SelectHero()
    {

    }
}
