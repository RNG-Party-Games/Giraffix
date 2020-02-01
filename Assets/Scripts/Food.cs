using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int foodValue;
    public bool isPlant;
    public Sprite eatenSprite;
    bool isEaten;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eat()
    {
        isEaten = true;
        if(isPlant) {
            GetComponent<SpriteRenderer>().sprite = eatenSprite;
        }
        else {
            Destroy(this.gameObject);
        }
    }

    public bool IsEaten() {
        return isEaten;
    }
}
