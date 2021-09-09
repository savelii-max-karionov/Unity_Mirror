using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class UISpawnButton : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        NetworkClient.connection.identity.GetComponent<PlayerMovement>().CmdSpawnGamePlayer();
    }
}
