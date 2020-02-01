using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public List<Repairable> repairables;
    public TextMeshProUGUI repaired;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    public void UpdateRepair()
    {
        float hp = 0, maxhp = 0;
        foreach(Repairable r in repairables) {
            maxhp += r.maxhp;
            hp += r.hp;
        }
        repaired.text = (int) Mathf.Round((hp/maxhp) * 100) + "% Repaired";
    }
}
