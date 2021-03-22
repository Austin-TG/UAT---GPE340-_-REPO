using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineWin : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.winGame = true;
        }
    }
}
