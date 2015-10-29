using UnityEngine;
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
    //mettre un last will 

    [SerializeField]
    private bool m_unlockable;
    //si oui mettre l'id de la ou des cartes
    //mettre aussi une condition d'unlock
    [SerializeField]
    private int[] m_nextCards;
}
