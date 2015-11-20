using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CardUI : MonoBehaviour {

    [SerializeField]
    private Text _name;
    [SerializeField]
    private Text _level;
    [SerializeField]
    private Text _lastWill;
    [SerializeField]
    private Text _default;
    [SerializeField]
    private GameObject _filter;

    private CardElement elem;
    public int GetId() { return elem.GetId(); }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator SettingUI(CardElement card)
    {
        yield return null;
        elem = card;
        Debug.Log(card.GetName() + " init");
        _name.text = elem.GetName();
        if (_lastWill != null)
            _lastWill.text = elem.GetLastWillDesc();
        
    }

    public void Init(CardElement card)
    {
        StartCoroutine(SettingUI(card));
    }
}
