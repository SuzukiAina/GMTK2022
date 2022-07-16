using UnityEngine;

public class Detector : MonoBehaviour
{
    public GameObject _dice;
    // Start is called before the first frame update
    private RaycastHit forwardHit;
    private RaycastHit backwardHit;
    private RaycastHit rightHit;
    private RaycastHit leftHit;
    void Start()
    {
        GetComponent<Transform>().position = _dice.transform.position;
        Detect();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = _dice.transform.position;
        
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward), Color.green);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * -1, Color.red);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * -1, Color.blue);
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1, Color.yellow);
        Detect();
    }

    public void Detect()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out forwardHit,0.5f))
        {
            if (forwardHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if (!forwardHit.collider.gameObject.GetComponent<CheckPoint>().Check(_dice.GetComponent<Dice>().forwardFace))
                {
                    Debug.Log("not allow f");
                    _dice.GetComponent<Dice>().allowForward = false;
                }
            }
        }
        else
        {
            _dice.GetComponent<Dice>().allowForward = true;
        }
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward) * -1, out backwardHit,0.5f))
        {
            if (backwardHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(!backwardHit.collider.gameObject.GetComponent<CheckPoint>().Check(_dice.GetComponent<Dice>().backwardFace)){
                    
                    Debug.Log("not allow f");
                    _dice.GetComponent<Dice>().allowBackward = false;
                }
            }
        }
        else
        {
            _dice.GetComponent<Dice>().allowBackward = true;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out rightHit,0.5f))
        {
            if (rightHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(!rightHit.collider.gameObject.GetComponent<CheckPoint>().Check(_dice.GetComponent<Dice>().rightFace)){
                    Debug.Log("not allow r");
                    _dice.GetComponent<Dice>().allowRight = false;
                }
            }
        }
        else
        {
            _dice.GetComponent<Dice>().allowRight = true;
        }
        
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right)*-1, out leftHit,0.5f))
        {
            if (leftHit.collider.gameObject.GetComponent<CheckPoint>())
            {
                if(!leftHit.collider.gameObject.GetComponent<CheckPoint>().Check(_dice.GetComponent<Dice>().leftFace)){
                    Debug.Log("not allow l");
                    _dice.GetComponent<Dice>().allowLeft = false;
                }
            }
        }
        else
        {
            _dice.GetComponent<Dice>().allowLeft = true;
        }
    }
}
