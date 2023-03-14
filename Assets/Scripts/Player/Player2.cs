using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    public BaseData.PlayerDataManager playerData;
    public static bool isGameOver;
    Gun[] guns;
    private float Range;
    private Rigidbody2D _body;
    public float timeToFireBulletHell;
    public float BaseSpeed { get; set; } = 5;
    public float SmoothTime { get; set; } = 0.04f;

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

    /*private void Awake()
    {
        GameObject.FindGameObjectWithTag("SaveLoad").GetComponent<SaveLoadSystemScript>().Load();
        playerData.HP = 100;
        playerData.speed = 5;
        playerData.armor = 0;
        isGameOver = false;
    }*/

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        // SkillManager.instance.player = gameObject.GetComponent<Player>();
        guns = transform.GetComponentsInChildren<Gun>();
        Range = playerData.shootingRange;
        _body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        timeToFireBulletHell -= Time.deltaTime;
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