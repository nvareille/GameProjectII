using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardSelectionPanel : MonoBehaviour {

    [SerializeField]
    private GameObject m_cardPrefab;
    [SerializeField]
    private GameObject m_grid;
    [SerializeField]
    private GameObject m_selectedCard;

    private int m_idSelected;

    private CardCollection m_collection;
    private GameController m_MCP;

	// Use this for initialization
	void Start () {
        m_collection = GameObject.FindObjectOfType<CardCollection>();
        m_MCP = GameObject.FindObjectOfType<GameController>();
        //DisplayDeck();
	}

    public void DisplayDeck()
    {
        gameObject.SetActive(true);
        List<CardElement> Elems = m_collection.GetDeck();
        List<int> dead = m_MCP.GetDeadHeroes();
        if (dead.Count == Elems.Count)
        {
            Debug.Log("Loose");
        }
        foreach(CardElement elem in Elems)
        {
            GameObject obj = Instantiate(m_cardPrefab);
            obj.name = elem.GetName();
            obj.transform.SetParent(m_grid.transform);
            obj.GetComponent<CardUI>().Init(elem);
            if ((dead.Find(item => item == elem.GetId())) != 0)
            {
                //show black shader
                obj.GetComponent<Toggle>().interactable = false;
            }
            else
            {
                obj.GetComponent<Toggle>().onValueChanged.AddListener((on) => { SelectHero(obj, on); });
                obj.GetComponent<Toggle>().group = m_grid.GetComponent<ToggleGroup>();
            }
            Debug.Log(elem.GetName() + " is in your hand !");
        }
        m_idSelected = -1;
    }

    public void SelectHero(GameObject obj, bool status)
    {
        if (!status || obj.GetComponent<CardUI>().GetId() == m_idSelected)
            return;

        CardElement card;
        int id;

        id = obj.GetComponent<CardUI>().GetId();
        m_idSelected = id;
        m_selectedCard.SetActive(true);
        card = m_collection.GetCardById(id);
        m_selectedCard.transform.Find("Name").GetComponent<Text>().text = card.GetName();
    }

    public void Play()
    {
        m_MCP.StartTheRun(m_collection.GetCardById(m_idSelected));
        gameObject.SetActive(false);
    }

    public void Cancel()
    {
        Debug.Log("Plop");
        m_grid.GetComponent<ToggleGroup>().allowSwitchOff = true;
        foreach (Transform child in m_grid.transform)
        {
            if (child.GetComponent<Toggle>().isOn)
            {
                child.GetComponent<Toggle>().isOn = false;
                break;
            }
        }
        m_grid.GetComponent<ToggleGroup>().allowSwitchOff = false;
        m_selectedCard.SetActive(false);
        m_idSelected = -1;
    }
}
