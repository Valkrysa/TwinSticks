using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
            recording = false;
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1")) {
            recording = true;
        }
    }
}
