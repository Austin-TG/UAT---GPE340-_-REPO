using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ObjectWeighted : MonoBehaviour
{
    [SerializeField, Tooltip("Object enemy can drop")]
    public GameObject dropItem;
    [SerializeField, Tooltip("Chance item will be chosen to drop")]
    [Range(0.0f, 1.0f)]
    public double chance = 1.0;
}
