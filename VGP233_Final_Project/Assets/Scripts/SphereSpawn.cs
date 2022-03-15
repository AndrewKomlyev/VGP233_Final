using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawn : MonoBehaviour
{

    public GameObject sphere;
    public GameObject reference;
    [SerializeField] private Transform spawn;

    // Start is called before the first frame update
    void Start()
    {
        if (reference == null)
        {
            Instantiate(sphere, spawn);
            reference = sphere;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (reference == null)
        {
            Instantiate(sphere, spawn);
            reference = sphere;
        }

    }
}
