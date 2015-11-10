using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class CardList : ScriptableObject
{
    public CardElement[] Cards;

    public CardElement GetById(int id)
    {
        foreach (CardElement card in Cards)
        {
            if (card.GetId() == id)
            {
                return card;
            }
        }
        return null;
    }
}
