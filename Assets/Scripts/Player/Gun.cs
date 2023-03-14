using UnityEngine;

public class Gun : MonoBehaviour
{
    Gun[] guns;
    public int gunLength;
    private Vector2 Direction;
    public float Force;
    [SerializeField]
    private Transform bulletPoint;

    [SerializeField]
    private GameObject Bullet;

    private void Start()
    {

    }

    private void Update()
    {
    }


    public void Shoot(Vector2 Direction, float Force)
    {

        GameObject BulletIns = Instantiate(Bullet, bulletPoint.position, Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        guns[0].Shoot(Direction, Force);
        Audio.PlaySound("fire");
    }

    private void ShootBulletHell()
    {
        for (int i = 0; i < gunLength; i++)
        {
            guns[i].Shoot(Direction, Force);
        }
    }
}