using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject _dice;
    // Start is called before the first frame update
    private Dice _diceScript;
    void Start()
    {
        _diceScript = _dice.GetComponent<Dice>();
        GetComponent<Transform>().position = _dice.transform.position;
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
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        Debug.DrawRay(transform.position, backward, Color.red);
        Debug.DrawRay(transform.position, left, Color.blue);
        Debug.DrawRay(transform.position, right, Color.yellow);
        
    }

    public void Detect()
    {
        RaycastHit forwardHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out forwardHit,0.5f))
        {
            
            Debug.Log("forward "+forwardHit.collider.gameObject);
            if (forwardHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if (forwardHit.collider.gameObject.GetComponent<CheckPoint>().Check(_diceScript.forwardFace))
                {
                    _diceScript.allowForward = true;
                }
                else
                {
                    Debug.Log("not allow forward");
                    _diceScript.allowForward = false;
                }
            }
        }
        RaycastHit backwardHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * -1, out backwardHit,0.5f))
        {
        
            Debug.Log("backward "+backwardHit.collider.gameObject);
            if (backwardHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(backwardHit.collider.gameObject.GetComponent<CheckPoint>().Check(_diceScript.backwardFace)){
                    _diceScript.allowBackward = true;
                }
                else
                {
                    _diceScript.allowBackward = false;
                }
            }
        }
        RaycastHit rightHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit,0.5f))
        {
        
            Debug.Log("right "+rightHit.collider.gameObject);
            if (rightHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(rightHit.collider.gameObject.GetComponent<CheckPoint>().Check(_diceScript.rightFace)){
                    _diceScript.allowRight = true;
                }
                else
                {
                    _diceScript.allowRight = false;
                }
            }
        }
        RaycastHit leftHit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right)*-1, out leftHit,0.5f))
        {
        
            Debug.Log("left "+leftHit.collider.gameObject);
            if (leftHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(leftHit.collider.gameObject.GetComponent<CheckPoint>().Check(_diceScript.leftFace)){
                    _diceScript.allowLeft = true;
                }
                else
                {
                    _diceScript.allowLeft = false;
                }
            }
        }
    }
}
