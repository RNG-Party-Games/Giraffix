using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform follow;
    public float smoothTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vel = Vector3.zero;
        Vector3 target = new Vector3(follow.position.x, follow.position.y, -5);
        transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
    }
}
