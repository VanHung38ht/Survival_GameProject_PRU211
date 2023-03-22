using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public BaseData.PlayerDataManager playerData;
    public static bool isGameOver;
    Gun[] guns;
    private float Range;
    public float FireRate;
    private Rigidbody2D _body;
    private Vector2 Direction;
    public float timeToFireBulletHell;
    public float saveTimeToFireBulletHell;
    public bool isFireBulletHell;
    private bool Detected = false;
    public float BaseSpeed { get; set; } = 5;
    public float SmoothTime { get; set; } = 0.04f;
    public float nextTimeToFire;
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

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("SaveLoad").GetComponent<SaveLoadSystemScript>().Load();
        playerData.HP = 100;
        playerData.speed = 5;
        playerData.armor = 0;
        isGameOver = false;
    }

    void Start()
    {
        
        playerAnimator = GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        SkillManager.instance.player = gameObject.GetComponent<Player>();
        guns = transform.GetComponentsInChildren<Gun>();
        Range = playerData.shootingRange;
        _body = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        timeToFireBulletHell -= Time.deltaTime;
        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;
    }

    private Transform Target;
    private void FixedUpdate()
    {
        PlayerMove();
        Target = GetClosestEnemy(GetTransformEnemies());
        if (Target != null)
        {
            RaycastPosition();
        }
    }

    private List<Transform> GetTransformEnemies()
    {
        GameObject[] bigEnemies = GameObject.FindGameObjectsWithTag("Big Enemy");
        GameObject[] smallEnemies = GameObject.FindGameObjectsWithTag("Small Enemy");
        List<Transform> result = new List<Transform>();
        foreach (var bigEnermy in bigEnemies)
        {
            result.Add(bigEnermy.transform);
        }
        foreach (var smallEnermy in smallEnemies)
        {
            result.Add(smallEnermy.transform);
        }
        return result;
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

    private Transform GetClosestEnemy(List<Transform> enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }
        return bestTarget;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    private void RaycastPosition()
    {
        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)transform.position;
        RaycastHit2D rayInfo = Physics2D.Raycast(transform.position, Direction, Range);
        if (rayInfo)
        {
            if (rayInfo.collider.gameObject.tag == "Player")
            {

                if (!Detected)
                {
                    Detected = true;

                }
                else
                {
                    Detected = false;
                }
            }
        }

        if (Detected)
        {
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + FireRate;
                if (isFireBulletHell && this.timeToFireBulletHell <= 0)
                {
                    Debug.Log(saveTimeToFireBulletHell);
                    // ShootBulletHell();
                    timeToFireBulletHell = saveTimeToFireBulletHell;
                }
                //  Shoot();
            }
        }
    }

    public float Force;
    public int gunLength;

    /*private void Shoot()
    {
        guns[0].Shoot(Direction, Force);
        Audio.PlaySound("fire");
    }*/

    /*private void ShootBulletHell()
    {
        for (int i = 0; i < gunLength; i++)
        {
            guns[i].Shoot(Direction, Force);
        }
    }*/

}
