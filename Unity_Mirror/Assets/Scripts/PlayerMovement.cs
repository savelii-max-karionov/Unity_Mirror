using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private GameObject gamePlayerPrefab;
    [SerializeField] private Transform spawnPos;
    private bool m_FacingRight = false;
    private float axis = 0;
    private Vector2 movement;
    void Start()
    {
        movement.x = 1;
        movement.y = 0;
    }

    // Update is called once per frame
    [ClientCallback]
    void Update()
    {
        if (!hasAuthority) { return; }
        axis = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!hasAuthority) { return; }
        CmdMove();
    }

    [Command]
    private void CmdMove()
    {
        RpcMove();
    }

    [ClientRpc] 
    private void RpcMove()
    {
        if (axis > 0 && !m_FacingRight)
        {
            Flip();
        }
        else if (axis < 0 && m_FacingRight)
        {
            Flip();
        }
        rb.MovePosition(rb.position + movement * axis * movementSpeed);
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    [Command]
    public void CmdSpawnGamePlayer()
    {
        ServerSpawnGamePlayer();
    }
    // move fnc somewhere else as RB cannot be setup later - it has to be as soon as this script will be enabled
    [Server]
    private void ServerSpawnGamePlayer()
    {
        GameObject player = Instantiate(gamePlayerPrefab, spawnPos.position, spawnPos.rotation);
        NetworkServer.Spawn(gamePlayerPrefab, connectionToClient);
    }
}
