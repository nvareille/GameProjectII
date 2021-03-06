﻿using UnityEngine;
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
    [SerializeField]
    private Text m_costText;

    private List<int> m_idSelecteds;
    private int m_maxCost;
    private int m_curentCost;

    private CardCollection m_collection;
    private GameController m_MCP;

    // Use this for initialization
    void Start()
    {
        m_collection = GameObject.FindObjectOfType<CardCollection>();
        m_MCP = GameObject.FindObjectOfType<GameController>();
        m_idSelecteds = new List<int>();
        DisplayCollection();
        m_curentCost = 0;
        m_maxCost = 20;
    }

    /*
     * Affiche la collection complète de carte
     * (unlock ou pas) avec toutes les stats 
     */
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

    /*
     * Select Hero : prend la carte et save l'id de la carte selectionné,
     * crée une instance dans la liste des cartes sélectionnées
     * add un listener sur le nouveau boutton instancié pour le supprimer
     */
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
        inst.transform.SetParent(m_selectedGrid.transform);
        m_curentCost += card.GetCost();
        UpdateCost();
        inst.GetComponent<CardUI>().Init(card);
        inst.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => { RemoveSelectHero(id, card.GetCost()); });
        //m_selectedCard.transform.Find("Name").GetComponent<Text>().text = card.GetName();
    }

    //Update le cout du deck et l'affiche
    void UpdateCost()
    {
        if (m_curentCost <= m_maxCost)
        {
            m_costText.color = Color.green;
        }
        else
        {
            m_costText.color = Color.red;
        }
        m_costText.text = m_curentCost + " / " + m_maxCost;
    }

    /*
     * fct qui enlève l'instance se situant dans la liste des heros selectionné
     * et réactive le toggle qui est dans la liste des héros.
     */
    public void RemoveSelectHero(int id, int cost)
    {
        GameObject obj = FindCardById(id);
        if (obj == null)
        {
            Debug.LogError("Can't find card with id : " + id);
            return;
        }
        m_idSelecteds.Remove(id);
        m_curentCost -= cost;
        UpdateCost();
        obj.GetComponent<Toggle>().isOn = false;
        obj.GetComponent<Toggle>().enabled = true;
        foreach (Transform child in m_selectedGrid.transform)
        {
            if (child.GetComponent<CardUI>().GetId() == id)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    //cherche la carte avec un id X dans la collection entière
    GameObject FindCardById(int id)
    {
        foreach (Transform child in m_grid.transform)
        {
            if (child.GetComponent<CardUI>().GetId() == id)
            {
                return child.gameObject;
            }
        }

        return null;
    }

    //
    public void ValadiateSelection()
    {
        if (m_curentCost <= m_maxCost)
        {
            m_collection.SetDeck(m_idSelecteds);
            m_MCP.ReadyToPlay();
        }
    }
}
