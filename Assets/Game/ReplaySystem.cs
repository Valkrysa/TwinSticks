using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaySystem : MonoBehaviour {

    private GameManager myGameManager;
    private Rigidbody myRigidBody;
    private int currentFrame = -1;
    private int maxFrame = -1;
    private const int bufferFrames = 1000;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];

	// Use this for initialization
	void Start () {
        myRigidBody = GetComponent<Rigidbody>();
        myGameManager = GameObject.FindObjectOfType<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
        currentFrame += 1;
        if (currentFrame > maxFrame) {
            maxFrame = currentFrame;
        }
        if (currentFrame == bufferFrames) {
            currentFrame = 0;
        }
        if (myGameManager.recording) {
            Record();
        } else {
            PlayBack();
        }
    }

    private void PlayBack () {
        if (currentFrame == maxFrame) {
            currentFrame = 0;
        }
        myRigidBody.isKinematic = true;
        int frame = currentFrame % maxFrame;

        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    private void Record() {
        myRigidBody.isKinematic = false;

        keyFrames[currentFrame] = new MyKeyFrame(transform.position, transform.rotation);
    }
}

/// <summary>
/// A structure for storing position and rotation.
/// </summary>
public struct MyKeyFrame {
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame (Vector3 pos, Quaternion rot) {
        position = pos;
        rotation = rot;
    }
}
