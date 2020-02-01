using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairable : MonoBehaviour
{
    public bool startBroken;
    public Sprite fixedSprite, brokenSprite;
    public float maxhp;
    public ParticleSystem sparkles, smoke;
    public float hp;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        if(!startBroken) {
            hp = maxhp;
        }
        sr = GetComponent<SpriteRenderer>();
        CheckState();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag == "Player") {
            if(collision.relativeVelocity.magnitude > 1 && hp > 0) {
                hp -= collision.relativeVelocity.magnitude;
                CheckState();
            }
        }
        else if(collision.transform.tag == "Wrench")
        {
            if(hp < maxhp)
            {
                hp = maxhp;
                CheckState();
            }
        }
    }

    public void CheckState() {
        if(hp >= maxhp)
        {
            hp = maxhp;
            sparkles.Play();
        }
        else
        {
            sparkles.Stop();
        }

        if (hp <= 0)
        {
            hp = 0;
            sr.sprite = brokenSprite;
            smoke.Play();
        }
        else
        {
            sr.sprite = fixedSprite;
            smoke.Stop();
        }
        GameState.instance.UpdateRepair();
    }
}
