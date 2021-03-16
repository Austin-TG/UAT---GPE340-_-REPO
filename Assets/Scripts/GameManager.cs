using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameObject player;
    public static bool isDead = false;

    private static GameManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("ERROR: There can only be one GameManager.");
            Destroy(gameObject);
        }

        player = GameObject.FindWithTag("Player");

        if(player == null)
        {

        }
    }

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead == true)
        {
            PlayerIsDestroyed();
        }
    }
    private void PlayerIsDestroyed()
    {
        Destroy(player, 5f);
        player = null;
    }
}
