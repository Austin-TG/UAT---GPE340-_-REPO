using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineWin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag is "Player")
        {
            GameManager.winGame = true;
        }
    }
}
