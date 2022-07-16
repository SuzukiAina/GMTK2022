using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int checkNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Check(int number)
    {
        if (checkNumber == number)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}
