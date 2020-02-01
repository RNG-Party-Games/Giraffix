using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repairable : MonoBehaviour
{
    public bool broken;
    public Sprite fixedSprite, brokenSprite;
    public float hp;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
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
    }

    public void CheckState() {
        if(hp <= 0) {
            hp = 0;
            sr.sprite = brokenSprite;
        }
        else {
            sr.sprite = fixedSprite;
        }
    }
}
