using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEXP : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Exp"))
        {
            Destroy(collision.gameObject);
        }
    }
}
