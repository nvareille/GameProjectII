using UnityEngine;
using System.Collections;

public class CharacterStats : MonoBehaviour {

    [SerializeField]
    protected int m_maxHp;
    [SerializeField]
    protected int m_baseAttack;
    [SerializeField]
    protected int m_defence;

    protected int m_curHp;
    protected bool m_isDieing;
    protected bool m_isDead;

    public int m_bonusAttack;

    public int GetHp() { return m_curHp; }
    public int GetAttack() { return (m_baseAttack + m_bonusAttack); }
    public int GetDefence() { return m_defence; }

    public int RecoverHp(int value)
    {
        m_curHp += value;
        if (m_curHp > m_maxHp)
            m_curHp = m_maxHp;

        return m_curHp;
    }

    /*
     * fonction qui prends les damages (int value) et qui les soustrait à l'armure.
     * si la vie tombe en dessous de 0 => mort.
     * si mort, ne prend pu de dégat;
    */
    public int TakeDamage(int value)
    {
        if (m_isDieing)
            return 0;

        int damages = value - m_defence;

        if (damages <= 0)
            damages = 1;

        m_curHp -= damages;
        if (m_curHp <= 0)
            m_curHp = 0;

        if (m_curHp == 0)
        {
            m_isDieing = true;
            Die();
        }

        return m_curHp;
    }

    void Die()
    {
        m_isDead = true;
        GameObject.Destroy (this.gameObject);
    }

    void Start()
    {
        m_curHp = m_maxHp;
        m_isDieing = false;
        m_isDead = false;
    }
}
