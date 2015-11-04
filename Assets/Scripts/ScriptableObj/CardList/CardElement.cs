﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class CardElement {

    public bool _isUnlocked;

    [SerializeField]
    private int m_id;
    [SerializeField]
    private string m_name;
    [SerializeField]
    private Texture2D m_picture;
    [SerializeField]
    private string m_malusDescription;
    //mettre un malus elem
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
    public string GetName() { return m_name; }
    public ELastWill GetLastWill() { return m_lastWillPow; }
    public int GetHp() { return m_maxHp; }
    public int GetAttack() { return m_baseAttack; }
    public int GetDefence() { return m_defence; }

}