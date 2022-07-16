using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject _dice;
    // Start is called before the first frame update
    private Dice _diceScript;
    void Start()
    {
        _diceScript = _dice.GetComponent<Dice>();
        Detect();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = _dice.transform.position;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 1;
        Vector3 backward = transform.TransformDirection(Vector3.forward) * -1;
        Vector3 right = transform.TransformDirection(Vector3.right) * 1;
        Vector3 left = transform.TransformDirection(Vector3.right) * -1;
        Debug.DrawRay(transform.position, forward, Color.green);
        Debug.DrawRay(transform.position, backward, Color.red);
        Debug.DrawRay(transform.position, left, Color.blue);
        Debug.DrawRay(transform.position, right, Color.yellow);
    }

    public void Detect()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit))
        {

            print("There is something in front of the object!");
            if (hit.collider.gameObject.GetComponent<CheckPoint>())
            {
                Debug.Log("Here is a check point: "+hit.collider.gameObject.GetComponent<CheckPoint>().condition);
            }
        }
    }
}
