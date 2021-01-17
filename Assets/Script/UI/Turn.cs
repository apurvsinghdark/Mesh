using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turn : MonoBehaviour
{
    protected Vector3 posLastFrame;
    public Camera UICam;

    public Transform DetachSpawn;

    //[SerializeField] GameObject DetachedMesh;

    private void OnEnable() {
    }
    private void Update() {

        if(Input.GetKeyDown(KeyCode.B))
        {
            UICam = GameObject.Find("UICamera").GetComponent<Camera>();
            DetachSpawn = GameObject.Find("DetachSpawn").transform;
            transform.position = DetachSpawn.position;
        }

        if(Input.GetMouseButtonDown(0))
            posLastFrame = Input.mousePosition;

        if(Input.GetMouseButton(0))
        {
            var delta = Input.mousePosition - posLastFrame;
            posLastFrame = Input.mousePosition;

            var axis = Quaternion.AngleAxis(-90f, Vector3.forward) * delta;
            transform.localRotation = Quaternion.AngleAxis(delta.magnitude * 0.1f, axis) * transform.rotation;
        }
    }
}
