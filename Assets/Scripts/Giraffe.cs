using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giraffe : MonoBehaviour
{
    public HingeJoint2D body;
    public Rigidbody2D head;
    public GameObject segment;
    public List<NeckSegment> neck_segments;
    public List<Sprite> necksprites;
    public int amt_segments;
    public static Giraffe instance;
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        HingeJoint2D lastJoint = body;
        for (int i = 0; i < amt_segments; ++i)
        {
            GameObject new_segment = Instantiate(segment, this.transform);
            lastJoint.connectedBody = new_segment.GetComponent<Rigidbody2D>();
            new_segment.transform.position = new Vector2(lastJoint.transform.position.x + lastJoint.anchor.x, lastJoint.transform.position.y + lastJoint.anchor.y + new_segment.GetComponent<SpriteRenderer>().bounds.size.y / 2);
            lastJoint = new_segment.GetComponent<HingeJoint2D>();
            new_segment.GetComponent<SpriteRenderer>().sprite = RandomNeck();
            neck_segments.Insert(0, new_segment.GetComponent<NeckSegment>());
            if(i == amt_segments - 1)
            {
                new_segment.layer = 9;
            }
        }
        lastJoint.connectedBody = head;
        head.transform.position = new Vector2(lastJoint.transform.position.x + lastJoint.anchor.x, lastJoint.transform.position.y + lastJoint.anchor.y + head.GetComponent<SpriteRenderer>().bounds.size.y / 2);

        for(int i = 0; i < neck_segments.Count; ++i)
        {
            neck_segments[i].name = "Neck " + i;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Add_Segment()
    {
        GameObject new_segment = Instantiate(segment, this.transform);
        new_segment.name = "Neck " + (neck_segments.Count);
        body.connectedBody = new_segment.GetComponent<Rigidbody2D>();
        NeckSegment bottom_segment = neck_segments[neck_segments.Count - 1];
        new_segment.transform.position = new Vector2(bottom_segment.connection.position.x, bottom_segment.connection.position.y - new_segment.GetComponent<SpriteRenderer>().bounds.size.y / 2);
        //new_segment.transform.position = new Vector2(body.transform.position.x + body.anchor.x, body.transform.position.y + body.anchor.y);
        new_segment.GetComponent<HingeJoint2D>().connectedBody = neck_segments[neck_segments.Count - 1].GetComponent<Rigidbody2D>();
        new_segment.GetComponent<SpriteRenderer>().sprite = RandomNeck();
        neck_segments.Add(new_segment.GetComponent<NeckSegment>());
    }

    Sprite RandomNeck() {
        int index = Random.Range(0, necksprites.Count);
        return necksprites[index];
    }
}
