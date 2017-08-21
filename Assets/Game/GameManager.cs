using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class GameManager : MonoBehaviour {

    public bool recording = true;
    private bool currentlyPaused = false;
    private float fixedDeltaTime;

    // Use this for initialization
    void Start() {
        fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update() {
        if (CrossPlatformInputManager.GetButtonDown("Fire1")) {
            recording = false;
        }
        if (CrossPlatformInputManager.GetButtonUp("Fire1")) {
            recording = true;
            // PlayerPrefsManager.LockLevel(1); // lock level 2, zero indexed
            // print(PlayerPrefsManager.IsLevelUnlocked(1));
            // PlayerPrefsManager.UnlockLevel(1); // unlock level 2, zero indexed
            // print(PlayerPrefsManager.IsLevelUnlocked(1));
        }
        if (Input.GetKeyDown(KeyCode.P)) {
            PauseUnpauseGame();
        }
    }

    void PauseUnpauseGame () {
        if (currentlyPaused) {
            currentlyPaused = false;
            Time.timeScale = 1f;
            Time.fixedDeltaTime = fixedDeltaTime;
        } else {
            currentlyPaused = true;
            Time.timeScale = 0f;
            Time.fixedDeltaTime = 0f;
        }
    }

    // void OnApplicationPause(bool pause) {
    //     currentlyPaused = !pause; // backwards because PauseUnpause flips it immediately, refactor probably
    //     PauseUnpauseGame();
    // }
}
