using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killzone : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isWorking = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player" && isWorking)
        {
            GameManager.Instance.Respawn();
        }
    }
}
