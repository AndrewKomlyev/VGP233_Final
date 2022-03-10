using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToPlatform : MonoBehaviour
{

    private GameObject target = null;
    private Vector3 offset;

    public bool isRotating;
    // Start is called before the first frame update
    void Start()
    {
        target = null;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
        {
            target.transform.position = transform.position + offset;
        }
    }

    void OnTriggerStay(Collider col)
    {



        if(!isRotating)
        {

            target = col.gameObject;
            offset = target.transform.position - transform.position;
        }
    }
    void OnTriggerExit(Collider col)
    {
        target = null;
    }







}
