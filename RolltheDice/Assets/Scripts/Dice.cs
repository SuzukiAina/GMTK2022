using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Dice : MonoBehaviour
{
    [SerializeField]private float _rollSpeed = 3;

    private bool _isMoving;
    public GameObject detector;
    public bool allowForward;
    public bool allowBackward;
    public bool allowRight;
    public bool allowLeft;
    

    public int topFace;
    public int forwardFace;
    public int backwardFace;
    public int rightFace;
    public int leftFace;
    public int bottomFace;

    public List<Canvas> CanvasList;
    private Canvas _bottomCanvas;

    // Start is called before the first frame update
    void Start()
    { 
        allowForward=true;
        allowBackward=true;
        allowRight=true;
        allowLeft=true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving) return;

        if (Input.GetKey(KeyCode.A))
        {
            if (!allowLeft) return;
            
            int tmpFace = topFace;
            topFace = rightFace;
            rightFace = bottomFace;
            bottomFace = leftFace;
            leftFace = tmpFace;
            Canvas tmpCanvas = CanvasList[0];
            CanvasList[0] = CanvasList[3];
            CanvasList[3] = CanvasList[5];
            CanvasList[5] = CanvasList[2];
            CanvasList[2] = tmpCanvas;
            Assemble(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            if (!allowRight) return;
            
            int tmpFace = topFace;
            topFace = leftFace;
            leftFace = bottomFace;
            bottomFace = rightFace;
            rightFace = tmpFace;
            Canvas tmpCanvas = CanvasList[0];
            CanvasList[0] = CanvasList[2];
            CanvasList[2] = CanvasList[5];
            CanvasList[5] = CanvasList[3];
            CanvasList[3] = tmpCanvas;
            
            Assemble(Vector3.right);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (!allowForward) return;
            int tmpFace = topFace;
            topFace = backwardFace;
            backwardFace = bottomFace;
            bottomFace = forwardFace;
            forwardFace = tmpFace;
            Canvas tmpCanvas = CanvasList[0];
            CanvasList[0] = CanvasList[4];
            CanvasList[4] = CanvasList[5];
            CanvasList[5] = CanvasList[1];
            CanvasList[1] = tmpCanvas;
            Assemble(Vector3.forward);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (!allowBackward) return;
            int tmpFace = topFace;
            topFace = forwardFace;
            forwardFace = bottomFace;
            bottomFace = backwardFace;
            backwardFace= tmpFace;
            Canvas tmpCanvas = CanvasList[0];
            CanvasList[0] = CanvasList[1];
            CanvasList[1] = CanvasList[5];
            CanvasList[5] = CanvasList[4];
            CanvasList[4] = tmpCanvas;
            Assemble(Vector3.back);

        }
 
        void Assemble(Vector3 dir) {
            var anchor = transform.position + (Vector3.down + dir) * 0.5f;
            var axis = Vector3.Cross(Vector3.up, dir);
            StartCoroutine(Roll(anchor, axis));
        }
        
        
        
    }

    private IEnumerator Roll(Vector3 anchor, Vector3 axis) {
        _isMoving = true;
        for (var i = 0; i < 90 / _rollSpeed; i++) {
            transform.RotateAround(anchor, axis, _rollSpeed);
            yield return new WaitForSeconds(0.01f);
        }
        _isMoving = false;
    }

    public void SetBottomActive(int number)
    {
        Debug.Log(CanvasList[5].gameObject);
        CanvasList[5].GetComponent<CanvasController>().SetImageActive(number);
    }

}
