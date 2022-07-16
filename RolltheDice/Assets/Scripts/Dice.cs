using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dice : MonoBehaviour
{
    [SerializeField]private float _rollSpeed = 3;

    private bool _isMoving;

    public UnityEvent StartMoving;
    public UnityEvent StopMoving;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving) return;
 
        if (Input.GetKey(KeyCode.A)) Assemble(Vector3.left);
        else if (Input.GetKey(KeyCode.D)) Assemble(Vector3.right);
        else if (Input.GetKey(KeyCode.W)) Assemble(Vector3.forward);
        else if (Input.GetKey(KeyCode.S)) Assemble(Vector3.back);
 
        void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        StartMoving.Invoke();
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
        StopMoving.Invoke();
    }

    public void DetectFace()
    {
        var up = transform.up;
        var right = transform.right;
        var forward = transform.forward;
        if (transform.up == new Vector3(0f, 1f, 0f))
        {
            Debug.Log("face1");
        }else if(transform.up == new Vector3(0f, -1f, 0f))
        {
            Debug.Log("face6");
        }
        if (transform.forward == new Vector3(0f, 1f, 0f))
        {
            Debug.Log("face4");
        }else if(transform.forward == new Vector3(0f, -1f, 0f))
        {
            Debug.Log("face3");
        }
        if (transform.right == new Vector3(0f, 1f, 0f))
        {
            Debug.Log("face5");
        }else if(transform.right == new Vector3(0f, -1f, 0f))
        {
            Debug.Log("face2");
        }
    }
}
