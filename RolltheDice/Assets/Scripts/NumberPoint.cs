using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberPoint : MonoBehaviour
{
    public int numberAttached;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("An object entered.");
        other.GetComponent<Dice>().bottomFace = numberAttached;
        other.GetComponent<Dice>().SetBottomActive(numberAttached);
    }
}
