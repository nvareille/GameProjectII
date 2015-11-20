using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardColletionPanel : MonoBehaviour {

    [SerializeField]
    private GameObject m_cardPrefab;
    [SerializeField]
    private GameObject m_selectedCardPrefab;
    [SerializeField]
    private GameObject m_grid;
    [SerializeField]
    private GameObject m_selectedGrid;

    private List<int> m_idSelecteds;
    private int m_maxCharge;

    private CardCollection m_collection;
    private GameController m_MCP;

    // Use this for initialization
    void Start()
    {
        m_collection = GameObject.FindObjectOfType<CardCollection>();
        m_MCP = GameObject.FindObjectOfType<GameController>();
        m_idSelecteds = new List<int>();
        DisplayCollection();
    }

    public void DisplayCollection()
    {
        gameObject.SetActive(true);
        List<CardElement> Elems = m_collection.GetCollection();
        foreach (CardElement elem in Elems)
        {
            GameObject obj = Instantiate(m_cardPrefab);
            obj.name = elem.GetName();
            obj.transform.SetParent(m_grid.transform);
            obj.GetComponent<CardUI>().Init(elem);
            if (!elem._isUnlocked)
            {
                //show black shader
                obj.GetComponent<Toggle>().interactable = false;
            }
            else
            {
                obj.GetComponent<Toggle>().onValueChanged.AddListener((on) => { SelectHero(obj, on); });
            }
        }
    }


    public void SelectHero(GameObject obj, bool status)
    {
        if (!status)
            return;

        CardElement card;
        int id;

        id = obj.GetComponent<CardUI>().GetId();
        m_idSelecteds.Add(id);
        card = m_collection.GetCardById(id);
        obj.GetComponent<Toggle>().enabled = false;
        GameObject inst = Instantiate(m_selectedCardPrefab);
        inst.transform.parent = m_selectedGrid.transform;
        inst.GetComponent<CardUI>().Init(card);
        //m_selectedCard.transform.Find("Name").GetComponent<Text>().text = card.GetName();
    }
}
