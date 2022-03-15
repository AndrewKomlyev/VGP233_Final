using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float speed;
    public int target;
    public bool isWorking = false;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isWorking)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, speed * Time.deltaTime);
        }    
    }

    void FixedUpdate()
    {
        if(isWorking)
        {
            if (transform.position == waypoints[target].position)
            {
                if (target == waypoints.Count - 1)
                {
                    target = 0;
                }
                else
                {
                    target += 1;
                }
            }
        }
    }
}

