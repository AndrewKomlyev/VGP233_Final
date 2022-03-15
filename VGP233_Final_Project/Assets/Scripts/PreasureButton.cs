using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasureButton : MonoBehaviour
{
    [SerializeField] private LayerMask grab;
    [SerializeField] private GameObject[] activatedObjects;
    private bool touched =false;
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
        if (!touched )
        {
            touched = true; 
            if (other.gameObject.layer == 7)
            {
                if (other.gameObject.GetComponent<Rigidbody>().mass >= 2.0f)
                {
                    for (int i = 0; i < activatedObjects.Length; i++)
                    {
                        print("pref" + i);
                        if (activatedObjects[i].GetComponentInChildren<MovingPlatform>())
                        {
                            activatedObjects[i].GetComponentInChildren<MovingPlatform>().isWorking = !activatedObjects[i].GetComponentInChildren<MovingPlatform>().isWorking;
                        }
                        if (activatedObjects[i].GetComponentInChildren<Killzone>())
                        {
                            activatedObjects[i].GetComponentInChildren<Killzone>().isWorking = !activatedObjects[i].GetComponentInChildren<Killzone>().isWorking;
                        }
                        if (activatedObjects[i].GetComponentInChildren<RotatingCylinder>())
                        {
                            activatedObjects[i].GetComponentInChildren<RotatingCylinder>().isWorking = !activatedObjects[i].GetComponentInChildren<RotatingCylinder>().isWorking;
                        }
                    }
                }
            }
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (touched)
        {
            touched = false;
            if (other.gameObject.layer == 7)
            {
                for (int i = 0; i < activatedObjects.Length; i++)
                {
                    print("pref" + i);

                    if(activatedObjects[i].GetComponentInChildren<MovingPlatform>())
                    {
                        activatedObjects[i].GetComponentInChildren<MovingPlatform>().isWorking = !activatedObjects[i].GetComponentInChildren<MovingPlatform>().isWorking;
                    }
                    if (activatedObjects[i].GetComponentInChildren<Killzone>())
                    {
                        activatedObjects[i].GetComponentInChildren<Killzone>().isWorking = !activatedObjects[i].GetComponentInChildren<Killzone>().isWorking;
                    }
                    if (activatedObjects[i].GetComponentInChildren<RotatingCylinder>())
                    {
                        activatedObjects[i].GetComponentInChildren<RotatingCylinder>().isWorking = !activatedObjects[i].GetComponentInChildren<RotatingCylinder>().isWorking;
                    }
                        
                        
                }
                
            }
        }
    }

}
