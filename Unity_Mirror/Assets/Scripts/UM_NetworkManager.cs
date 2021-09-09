using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UM_NetworkManager : NetworkManager
{
    [SerializeField] Transform spawnPos_1;
    [SerializeField] Transform spawnPos_2;

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        Transform start = numPlayers == 0 ? spawnPos_1 : spawnPos_2;
        // if there are no players let start position be the first spawn point, else second
        GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
        player.GetComponentInChildren<SpriteRenderer>().color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
