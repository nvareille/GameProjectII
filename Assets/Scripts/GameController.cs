using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum EGameState
{
    MENU,
    GAME,
    PAUSE,
    NONE,
    SELECTION,
}

public class GameController : MonoBehaviour {

    private List<int> m_idDeads;
    private CardElement m_curentHero;
    private EGameState m_curentState;

    public List<int> GetDeadHeroes()
    {
        return m_idDeads;
    }

	// Use this for initialization
	void Start () {
        m_curentState = EGameState.SELECTION; //a changer quand on aura une GUI
        Time.timeScale = 0;
        m_curentHero = null;
        m_idDeads = new List<int>();
        GameObject.FindObjectOfType<CardSelectionPanel>().DisplayDeck();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ConsumeHero(int id)
    {
        m_idDeads.Add(id);
        GameObject.FindObjectOfType<CardSelectionPanel>().DisplayDeck();
    }

    public void StartTheRun(CardElement card)
    {
        m_curentHero = card;

        GameObject.FindObjectOfType<PlayableCharacter>().LoadPlayerFromCard(m_curentHero);
        m_curentState = EGameState.GAME;
        Time.timeScale = 1;
        //load un hero avec ces infos
        //play le game
    }
}
