using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookRotation : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.rotation = Quaternion.LookRotation(target.position - transform.position);
    }
    /*This code makes an object rotate to point towards another Transform. The target.position - transform.position line subtracts the object’s position from the target, which creates a direction that points towards the target. Then the Transform’s rotation is set to that rotation. - GPE340*/
}
