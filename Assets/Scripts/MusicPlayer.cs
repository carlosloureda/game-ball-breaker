using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {
    static MusicPlayer instance = null;
    // Start is called before the first frame update
    void Start () {
        if (instance != null) {
            Debug.Log ("Destroy music player instance");
            Destroy (gameObject);
        } else {
            instance = this;
            GameObject.DontDestroyOnLoad (gameObject);
        }
    }

    // Update is called once per frame
    void Update () {

    }
}