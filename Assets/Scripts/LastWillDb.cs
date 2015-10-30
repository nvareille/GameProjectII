using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public enum ELastWill
{
    ROCK,
    EXPLOSION,
    BOOST,
    NONE
}

public class LastWillDb : MonoBehaviour {

    delegate void funct(GameObject obj);

    private Dictionary<ELastWill, funct> m_lastWillD;
    private ELastWill m_prevLastWill;

    void Start()
    {
        m_lastWillD = new Dictionary<ELastWill, funct>
        {
            { ELastWill.ROCK, ApplyRock },
            { ELastWill.BOOST, ApplyBoost },
            { ELastWill.EXPLOSION, ApplyExplosion },
        };

        m_prevLastWill = ELastWill.NONE;
    }

    public ELastWill GetPreviousWill()
    {
        return m_prevLastWill;
    }

    public void UseLastWill(ELastWill pow, GameObject obj)
    {
        m_lastWillD[pow](obj);
        m_prevLastWill = pow;
    }

    void ApplyRock(GameObject obj)
    {

        return;
    }

    void ApplyBoost(GameObject obj)
    {

        return;
    }

    void ApplyExplosion(GameObject obj)
    {

        return;
    }
}
