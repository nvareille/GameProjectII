using UnityEngine;
using System.Collections;

public class PlayableCharacter : CharacterStats {

    private string m_name;
    private ELastWill m_lastWillPow;
    private int m_id;
    private LastWillDb m_lastWillFunc;

    void Start()
    {
        m_lastWillFunc = GameObject.FindObjectOfType<LastWillDb>();
    }

    public void printHp()
    {
        Debug.Log("plop");
    }

    //start coroutine de la mort
    void Die()
    {
        m_lastWillFunc.UseLastWill(m_lastWillPow, gameObject, m_id);
    }

    public void LoadPlayerFromCard(CardElement elem)
    {
        m_id = elem.GetId();
        m_lastWillPow = elem.GetLastWill();
        m_name = elem.GetName();
        m_maxHp = elem.GetHp();
        m_baseAttack = elem.GetAttack();
        m_defence = elem.GetDefence();
        if (m_lastWillFunc.GetPreviousWill() == ELastWill.BOOST)
            m_bonusAttack = 30;
    }
}
