using System.Collections;
using UnityEngine;

public class AIRespawn : MonoBehaviour
{
    // variables
    [SerializeField] private GameObject enemy;
    private int xPos;
    [SerializeField, Tooltip("Mix Max of X position")] private int xPosMin, xPosMax;
    [SerializeField, Tooltip("Mix Max of Z position")] private int zPosMin, zPosMax;
    private int zPos;
    [SerializeField] private int enemyCount;
    [SerializeField] private float waitSeconds;
    [SerializeField] private int totalEnemies;
    [SerializeField] private bool isSpawnOnPoint;
    //private GameObject[] AICount;
    //private bool checkPass = false;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }
    // update every frame
    private void Update()
    {
        
    }

    // use coroutine to spawn enemies randomly between a portion of the map
    IEnumerator EnemySpawn()
    {
        // while enemycount is less than total enemies allowed, instantiate more enemies to scene
        while(enemyCount < totalEnemies)
        {
            if (isSpawnOnPoint == false)
            {
                // xPos, zPos are allowed spawning ranges, Min/Max Exclusive
                xPos = Random.Range(xPosMin, xPosMax);
                zPos = Random.Range(zPosMin, zPosMax);
                // instantiate enemy to scene
                Instantiate(enemy, new Vector3(xPos, .1f, zPos), Quaternion.identity);
                // before returning to loop, wait an amount of seconds dependant on set inspector value
                yield return new WaitForSeconds(waitSeconds);
                // add 1 count to enemycount to determine amount of enemies on scene
                enemyCount++;
            }
            else
            {
                Instantiate(enemy, gameObject.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(waitSeconds);
                enemyCount++;
            }
        }
    }

}
