using UnityEngine;
using System.Collections;

public class DebugPanel : MonoBehaviour {

    private bool m_isEnabled;

    public static DebugPanel _DebugPanel;

	// Use this for initialization
	void Start () {
        _DebugPanel = this;
	}
	
	// Update is called once per frame
	void LateUpdate () {
	     if (Input.GetKeyDown(KeyCode.Tab))
        {
            m_isEnabled = !m_isEnabled;
            gameObject.SetActive(m_isEnabled);
        }
	}
}
