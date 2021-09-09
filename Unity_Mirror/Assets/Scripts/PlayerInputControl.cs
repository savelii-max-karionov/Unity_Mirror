using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInputControl : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //TODO: research if id would be a more effitient way to pass object then gameobject (id for example)
    [Command]
    public void CmdOpenObject(GameObject hidingObject)
    {
        ServerOpenObject(hidingObject);
    }

    [Server]
    private void ServerOpenObject(GameObject hidingObject)
    {
        hidingObject.GetComponent<HidingObject>().ChangeState();
    }
}
