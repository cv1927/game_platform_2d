using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    private PlayerController playerController;
    private Rigidbody2D rb2d;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Platform":
                rb2d.velocity = new Vector3(0f, 0f, 0f);
                playerController.transform.parent = collision.transform;
                playerController.grounded = true;
                break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                playerController.grounded = true;
                break;
            case "Platform":
                playerController.transform.parent = collision.transform;
                playerController.grounded = true;
                break;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
                playerController.grounded = false;
                break;
            case "Platform":
                playerController.transform.parent = null;
                playerController.grounded = false;
                break;
        }
    }
}
