using UnityEngine;
using System.Collections;

public class PauseMenuController : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void RestartGame(GameObject obj)
    {
        Application.LoadLevel(Application.loadedLevel);
        Unpause(obj);
        
    }

    public void Unpause(GameObject obj)
    {
        obj.GetComponent<UIController>().MenuActivate();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Fullscreen()
    {
        Screen.fullScreen = !Screen.fullScreen;
    }
}
