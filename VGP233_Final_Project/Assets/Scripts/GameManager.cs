using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject player;
    public Transform currentSpawn;

    // Start is called before the first frame update
    void Start()
    {
        currentSpawn = null;
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {

            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        player.transform.position = currentSpawn.position;
    }
}
