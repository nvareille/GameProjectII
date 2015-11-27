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
    ENDLEVEL
}

public class GameController : MonoBehaviour {

    static GameController instance;
    private List<int> m_idDeads;
    private CardElement m_curentHero;
    private EGameState m_curentState;
    private int m_currentSceneId;

    [SerializeField]
    private string m_menuScene;
    [SerializeField]
    private int m_maxLevelId;

    public List<int> GetDeadHeroes()
    {
        return m_idDeads;
    }

    void Awake()
    {
        if (instance)
        {
            GameObject.DestroyImmediate(gameObject);
            SetCurLevel();
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            instance = this;
            SetCurLevel();
        }

    }

    public void SetCurLevel()
    {
        string levelName = Application.loadedLevelName;
        Debug.Log(Application.loadedLevelName);

        m_curentHero = null;
        m_idDeads = new List<int>();

        if (levelName.Contains(m_menuScene))
        {
            m_currentSceneId = -1;
            m_curentState = EGameState.MENU;
        }
        else
        {
            m_currentSceneId = int.Parse(levelName.Split(new char[] { '_', '.' })[1]);
            Debug.Log(m_currentSceneId);
            m_curentState = EGameState.SELECTION;
            Time.timeScale = 0;
            StartCoroutine(DisplayDeckOrder(1));
        }
    }

    IEnumerator DisplayDeckOrder(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.FindObjectOfType<CardSelectionPanel>().DisplayDeck();
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

    public void ReadyToPlay()
    {
        Application.LoadLevel("Level_1");
    }

    IEnumerator WaitToNextLvl(float time)
    {
        m_curentState = EGameState.ENDLEVEL;
        yield return new WaitForSeconds(time);
        if (m_currentSceneId < m_maxLevelId)
        {
            m_currentSceneId++;
            Debug.LogWarning("Loading scene : Level_" + m_currentSceneId);
            Application.LoadLevel("Level_" + m_currentSceneId);
        }
        else
        {
            Debug.LogError("Final Level, faire une fin");
        }
    }
}
