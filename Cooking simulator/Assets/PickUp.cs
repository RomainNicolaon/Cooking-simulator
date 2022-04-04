using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    Vector3 objectPos;
    float distance;
    public bool canHold=true;
    public GameObject item;
    public GameObject tempParent;
    public bool isHolding=false;
  
    // Update is called once per frame
    void Update()
    {
        // pick-up
        distance= Vector3.Distance(item.transform.position,tempParent.transform.position);
        if(Input.GetKeyDown(KeyCode.E) && isHolding==false && distance<2f){
            isHolding=true;
            item.GetComponent<Rigidbody>().useGravity=false;
            item.GetComponent<Rigidbody>().detectCollisions=false;
            item.transform.position=tempParent.transform.position;
        } 
        else if(Input.GetKeyDown(KeyCode.E) && isHolding==true){
            isHolding=false;
            item.GetComponent<Rigidbody>().detectCollisions=true;
        }   
        if(isHolding==true){
            item.GetComponent<Rigidbody>().velocity= Vector3.zero;
            item.GetComponent<Rigidbody>().angularVelocity= Vector3.zero;
            item.transform.SetParent(tempParent.transform);
        }
        else{
            objectPos=item.transform.position;
            item.transform.SetParent(null);
            item.GetComponent<Rigidbody>().useGravity=true;
            item.transform.position=objectPos;
        }
        if(distance>=2f){
            isHolding=false;
        }
    }
}