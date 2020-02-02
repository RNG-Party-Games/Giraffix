using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCamera : MonoBehaviour
{
    public Transform follow;
    public float smoothTime = 0.1f, cam_speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Camera_Horizontal") * cam_speed;
        float y = Input.GetAxis("Camera_Vertical") * cam_speed;
        if (x == 0 && y == 0) {
            Vector3 vel = Vector3.zero;
            Vector3 target = new Vector3(follow.position.x, follow.position.y, -5);
            transform.position = Vector3.SmoothDamp(transform.position, target, ref vel, smoothTime);
        }
        else {
            transform.position = new Vector3(transform.position.x + x * Time.deltaTime, transform.position.y + y * Time.deltaTime, -5);
        }
    }
}
