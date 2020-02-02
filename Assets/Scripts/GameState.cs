using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    public static GameState instance;
    public List<Repairable> repairables;
    public TextMeshProUGUI repaired, finalrepair, finaltime;
    public GameObject sfx;
    public AudioClip wrenchSFX, bumpSFX, chompSFX;
    public Animator endScreen;
    bool ended = false;
    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null) {
            instance = this;
        }
    }

    void Update() {
        if(ended && Input.GetButtonDown("Restart")) {
            Restart();
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

    public void PlaySFX(AudioClip clip) {
        GameObject newSFX = Instantiate(sfx);
        newSFX.GetComponent<SFX>().Play(clip);
    }

    public void WrenchSFX() {
        PlaySFX(wrenchSFX);
    }

    public void Bump() {
        PlaySFX(bumpSFX);
    }

    public void Chomp() {
        PlaySFX(chompSFX);
    }

    public void Exit() {
        endScreen.Play("EndFade");
        ended = true;
        float hp = 0, maxhp = 0;
        foreach (Repairable r in repairables) {
            maxhp += r.maxhp;
            hp += r.hp;
        }
        finalrepair.text = (int) Mathf.Round((hp / maxhp) * 100) + "% Repaired";
        System.TimeSpan actualTime = System.TimeSpan.FromSeconds(Time.time);
        finaltime.text = string.Format("{0:D2}:{1:D2}", actualTime.Minutes, actualTime.Seconds);
    }

    public bool IsEnded() {
        return ended;
    }

    public void Restart() {
        SceneManager.LoadScene("Game");
    }
}
