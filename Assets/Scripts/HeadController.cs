using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        rb.AddForce(speed*move);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.transform.tag == "Food")
        {
            col.gameObject.GetComponent<Food>().Eat();
            Giraffe.instance.Add_Segment();
        }
    }
}
