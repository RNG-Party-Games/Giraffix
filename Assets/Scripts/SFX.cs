using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SetInvoke(string method, float time) {
        Invoke(method, time);
    }

    public void Kill() {
        Destroy(gameObject);
    }

    public void Play(AudioClip clip) {
        GetComponent<AudioSource>().clip = clip;
        GetComponent<AudioSource>().Play();
        SetInvoke("Kill", clip.length);
    }
}
