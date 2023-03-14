using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    #region MovePlayer
    [SerializeField]
    private FloatingJoystick Joystick;
    Vector2 move;
    Rigidbody2D rb;
    public float moveSpeed = 2f;
    #endregion

    [SerializeField]
    private SpriteRenderer sprite;
    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    public void PlayerMove()
    {
        playerAnimator.SetFloat("run", Mathf.Abs(move.x));
        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);
        if (move.x > 0)
        {
            sprite.flipX = false;
        }
        if (move.x < 0)
        {
            sprite.flipX = true;
        }
    }
}
