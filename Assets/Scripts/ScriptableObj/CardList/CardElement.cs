﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class CardElement {

    public bool _isUnlocked;

    [SerializeField]
    private int m_id;
    // cout de la carte pour le deck
    [SerializeField]
    private int m_cost;
    //nom de la carte
    [SerializeField]
    private string m_name;
    //image de la carte
    [SerializeField]
    private Texture2D m_picture;
    //couleur du hero
    [SerializeField]
    private Color m_color;
    //mettre un malus elem
    [SerializeField]
    private string m_malusDescription;
    //dernière volonté
    [SerializeField]
    private string m_lastWillDescription;
    [SerializeField]
    private ELastWill m_lastWillPow;

    [SerializeField]
    private bool m_unlockable;
    //si oui mettre l'id de la ou des cartes
    //mettre aussi une condition d'unlock
    [SerializeField]
    private int[] m_nextCards;
    [SerializeField]
    protected int m_maxHp;
    [SerializeField]
    protected int m_baseAttack;
    [SerializeField]
    protected int m_defence;

    public int GetId() { return m_id; }
    public int GetCost() { return m_cost; }
    public string GetName() { return m_name; }
    public ELastWill GetLastWill() { return m_lastWillPow; }
    public string GetLastWillDesc() { return m_lastWillDescription; }
    public int GetHp() { return m_maxHp; }
    public int GetAttack() { return m_baseAttack; }
    public int GetDefence() { return m_defence; }
    public Color GetColor() { return m_color; }

    public void SetParams(CardElement other)
    {
        _isUnlocked = other._isUnlocked;
        m_id = other.GetId();
        m_cost = other.GetCost();
        m_name = other.GetName();
        m_lastWillPow = other.GetLastWill();
        m_lastWillDescription = other.GetLastWillDesc();
        m_maxHp = other.GetHp();
        m_baseAttack = other.GetAttack();
        m_defence = other.GetDefence();
    }
}
