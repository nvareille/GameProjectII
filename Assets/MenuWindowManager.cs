using UnityEngine;
using System.Collections;

public class MenuWindowManager : MonoBehaviour {

    [SerializeField]
    private GameObject m_mainPanel;
    [SerializeField]
    private GameObject m_collectionPanel;
    [SerializeField]
    private GameObject m_howPanel;

    //active le panel avec l'int qui sert de key
    public void SwithcPanel(int val)
    {
        switch (val)
        {
            case 0:
                m_collectionPanel.SetActive(false);
                m_howPanel.SetActive(false);
                m_mainPanel.SetActive(true);
                break;
            case 1:
                m_mainPanel.SetActive(false);
                m_howPanel.SetActive(false);
                m_collectionPanel.SetActive(true);
                break;
            case 2:
                m_collectionPanel.SetActive(false);
                m_mainPanel.SetActive(false);
                m_howPanel.SetActive(true);
                break;
        }
    }

    //quitte le jeu
    public void Quit()
    {
        Application.Quit();
    }
}
