using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraArm : MonoBehaviour {

    public float panSpeed = 10f;

    private GameObject player;
    private Vector3 armRotation;

    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        armRotation = transform.rotation.eulerAngles;
    }
	
	void Update () {
        armRotation.y += Input.GetAxis("RightStickHorizontal") * panSpeed;
        armRotation.x += Input.GetAxis("RightStickVertical") * panSpeed;

        transform.rotation = Quaternion.Euler(armRotation);
        transform.position = player.transform.position;
	}
}
