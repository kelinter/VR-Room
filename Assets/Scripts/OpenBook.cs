using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpenBook : MonoBehaviour
{

    public GameObject cover; // Reference to the cover of the book GameObject
    public HingeJoint myHinge; // Reference to the Hinge component

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var myHinge = cover.GetComponent<HingeJoint>();
        myHinge.useMotor = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        myHinge.useMotor = true;
        Debug.Log("Hinge motor enabled");
        
    }
}
