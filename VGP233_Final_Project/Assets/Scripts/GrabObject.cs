using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour
{

    RaycastHit hit;
    GameObject grabbedObject;
    public Transform grabPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Physics.Raycast(transform.position, transform.forward, out hit, 5) && hit.transform.GetComponent<Rigidbody>())
        {
            grabbedObject = hit.transform.gameObject;
            grabbedObject.GetComponent<Rigidbody>().mass = 0;
            grabbedObject.tag = "Untagged";

        }
        else if (Input.GetKeyUp(KeyCode.E))
        {
            grabbedObject.GetComponent<Rigidbody>().mass = 5;
            grabbedObject.tag = "Ground";
            grabbedObject = null;
            
        }

        if(grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity =10 * (grabPosition.position- grabbedObject.transform.position);
            grabbedObject.transform.rotation = Quaternion.Euler(grabbedObject.transform.rotation.x, grabbedObject.transform.rotation.y, grabbedObject.transform.rotation.z);      
        }


    }
}
