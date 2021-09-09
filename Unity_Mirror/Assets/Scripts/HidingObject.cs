using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingObject : MonoBehaviour
{
    [SerializeField] private BoxCollider2D hideCollider;
    [SerializeField] private Animator animator;
    private bool open;
    private Vector3 mousePos;
    private Vector2 mousePos2D;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    public void ChangeState()
    {
        open = !open;
        animator.SetBool("Open", open);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
