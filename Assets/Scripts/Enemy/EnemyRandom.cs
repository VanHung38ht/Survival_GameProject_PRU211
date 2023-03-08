using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    [SerializeField]
    public GameObject SmallMonster;
    public GameObject BigMonster;
    public float timeCreate;
    public float Speed = 5.0f;

    float a;
    float xPosition = 0;
    float yPosition = 0;
    float screenWidth;
    float screenHeight;
    float screenLeft;
    float screenRight;
    float screenTop;
    float screenBottom;

    void Start()
    {
        screenWidth = Screen.width;

        screenHeight = Screen.height;

        // save screen edges in world coordinates 

        float screenZ = -Camera.main.transform.position.z;

        Vector3 lowerLeftCornerScreen = new Vector3(0, 0, screenZ);

        Vector3 upperRightCornerScreen = new Vector3(

            screenWidth, screenHeight, screenZ);

        Vector3 lowerLeftCornerWorld =

            Camera.main.ScreenToWorldPoint(lowerLeftCornerScreen);

        Vector3 upperRightCornerWorld =

            Camera.main.ScreenToWorldPoint(upperRightCornerScreen);

        screenLeft = lowerLeftCornerWorld.x;

        screenRight = upperRightCornerWorld.x;

        screenTop = upperRightCornerWorld.y;

        screenBottom = lowerLeftCornerWorld.y;

    }

    List<GameObject> enemyObject = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        xPosition = Random.Range(screenLeft, screenRight);
        yPosition = Random.Range(screenTop, screenBottom);
        timeCreate += Time.deltaTime;
        if (timeCreate >= 2 && (int)timeCreate % 2 == 0)
        {
            timeCreate = 0;
            enemyObject.Add(Instantiate<GameObject>(SmallMonster, new Vector3(xPosition, yPosition, 0), Quaternion.identity));
            enemyObject.Add(Instantiate<GameObject>(BigMonster, new Vector3(xPosition, yPosition, 0), Quaternion.identity));
        }
    }
}