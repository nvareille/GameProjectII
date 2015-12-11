using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public bool Paused;
    private int WaitingPause;
    public GameObject[] Bars;
    private Material[] BarsMaterials;
    public Text[] Texts;
    public CharacterStats Stats;
    public GameObject[] Menu;

    // Use this for initialization
	void Start ()
    {
        BarsMaterials = new Material[2];
        BarsMaterials[0] = new Material(Bars[0].GetComponent<Image>().material);
        BarsMaterials[1] = new Material(Bars[1].GetComponent<Image>().material);

        Bars[0].GetComponent<Image>().material = BarsMaterials[0];
        Bars[1].GetComponent<Image>().material = BarsMaterials[1];
	}
	
	// Update is called once per frame
	void Update ()
    {
        BarsMaterials[0].SetFloat("_FilingValue", 0.5f - ((float)Stats.GetHp() / (float)Stats.GetMaxHp() / 2));
        BarsMaterials[1].SetFloat("_FilingValue", 0.5f - ((float)Stats.GetHp() / (float)Stats.GetMaxHp() / 2));
	    Texts[0].text = Stats.GetHp() + " / " + Stats.GetMaxHp();

	    if (WaitingPause > 30 && Input.GetKey(KeyCode.Escape))
	    {
	        WaitingPause = 0;
	        MenuActivate();
	    }
	    else
	        ++WaitingPause;
    }

    public void MenuActivate()
    {
        Paused = !Paused;
        Time.timeScale = Paused ? 0 : 1;
        Menu[0].SetActive(Paused);
        Menu[1].SetActive(false);
    }
}
