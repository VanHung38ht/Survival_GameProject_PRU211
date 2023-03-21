using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
     public float FollowSpeed = 2f;
   //  public float yOffset = 1f;
     public Transform target;

   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPoss = target.position;
        newPoss.z = -10f;
        transform.position = newPoss;
        /*
          Vector3 newPoss = new Vector3(target.position.x, target.position.y *//*+ yOffset*//*, -10f);
          transform.position = Vector3.Slerp(transform.position, newPoss, FollowSpeed * Time.deltaTime);*/
    }
}
