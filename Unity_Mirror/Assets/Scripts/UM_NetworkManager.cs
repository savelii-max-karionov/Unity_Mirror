using Mirror;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UM_NetworkManager : NetworkManager
{
    //[SerializeField] Transform spawnPos_1;
    //[SerializeField] Transform spawnPos_2;
    [SerializeField] TMP_Text playerList;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        //Transform start = numPlayers == 0 ? spawnPos_1 : spawnPos_2;
        // if there are no players let start position be the first spawn point, else second
        //GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        GameObject player = Instantiate(playerPrefab);
        //player.GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        NetworkServer.AddPlayerForConnection(conn, player);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        // cannot get netId from conn.indentity.netId in the client fnc 
        base.OnClientConnect(conn);
        ConnectedMessage(true);
    }


    public override void OnStopClient()
    {
        ConnectedMessage(false);
        base.OnStopClient();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

    }

    [Client]
    private void ConnectedMessage(bool connected)
    {
        playerList.text = connected ? "Status:" + "\r\n" + "Connected" : "Status:" + "\r\n" + "Offline";
    }
}
