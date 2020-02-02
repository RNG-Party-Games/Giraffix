using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadController : MonoBehaviour
{
    public float speed, spitSpeed, rotateSpeed;
    public Rigidbody2D wrench;
    Vector3 wrenchPos;
    Quaternion wrenchRot;
    Rigidbody2D rb;
    bool hasWrench = true;
    bool wrenchTouching = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        wrenchPos = wrench.transform.localPosition;
        wrenchRot = wrench.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameState.instance.IsEnded()) {
            Vector2 move = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            rb.AddForce(speed * move);
            CheckWrench();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(!hasWrench && collision.transform.tag == "WrenchTrigger")
        {
            GrabWrench();
        }
        // for plant triggers
        if (collision.transform.tag == "Food" && !collision.GetComponent<Food>().IsEaten()) {
            GameState.instance.Chomp();
            collision.gameObject.GetComponent<Food>().Eat();
            Giraffe.instance.Add_Segments(collision.gameObject.GetComponent<Food>().foodValue);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (!hasWrench && collision.transform.tag == "WrenchTrigger") {
            wrenchTouching = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Food") {
            GameState.instance.Chomp();
            collision.gameObject.GetComponent<Food>().Eat();
            Giraffe.instance.Add_Segments(collision.gameObject.GetComponent<Food>().foodValue);
        }
    }

    public void CheckWrench() {
        if(hasWrench && Input.GetMouseButtonDown(0))
        {
            Vector2 mouse = Input.mousePosition;
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            Vector2 direction = mouse - (Vector2) transform.position;
            wrench.transform.parent = null;
            wrench.bodyType = RigidbodyType2D.Dynamic;
            wrench.GetComponent<BoxCollider2D>().enabled = true;
            wrench.AddForce(direction * spitSpeed, ForceMode2D.Impulse);
            wrench.AddTorque(rotateSpeed, ForceMode2D.Impulse);
            hasWrench = false;
        }
        else if(!hasWrench && wrenchTouching && Input.GetMouseButtonDown(0)) {
            GrabWrench();
        }
    }

    void GrabWrench() {
        wrench.GetComponent<BoxCollider2D>().enabled = false;
        wrench.transform.parent = this.transform;
        wrench.transform.localPosition = wrenchPos;
        wrench.transform.localRotation = wrenchRot;
        wrench.bodyType = RigidbodyType2D.Kinematic;
        hasWrench = true;
        wrenchTouching = true;
    }
}
