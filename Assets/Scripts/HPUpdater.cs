using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPUpdater : MonoBehaviour {

    [Header("HP Bar")]
    [SerializeField] [Range(5, 10)] int hpBars = 5;

    private Player player;
    private TextMeshProUGUI hpText;

	// Use this for initialization
	void Start ()
    {
        UpdateText();
    }
    // Update is called once per frame
    void Update () {
        UpdateText();
	}

    private void UpdateText()
    {
        player = FindObjectOfType<Player>();
        hpText = GetComponent<TextMeshProUGUI>();
        float currentHP = player? player.getHP() : 0;
        float maxHP = player? player.getMaxHP(): 0;

        hpText.text = (currentHP > 0)? getHPBars(currentHP, maxHP): "";
    }

    private string getHPBars(float hp, float maxHp)
    {
        float perBarValue = maxHp / hpBars;
        int currentBars = (hp >= perBarValue) ? Mathf.RoundToInt(hp / perBarValue) : 1;
        string hpBarsStr = new string('|', currentBars);

        return hpBarsStr;
    }

}
