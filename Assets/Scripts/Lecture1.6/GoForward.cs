using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoForward : MonoBehaviour
{
    public float speed = 1f;

    private void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
    /* This code moves an object along the world Z axis at 2 meters/second.Vector3.forward is shorthand for new Vector3(0f, 0f, 1f). We can multiply this vector by a number like our speed to scale the vector a certain amount, which would give us a vector of (0, 0, 2). Then we multiply by Time.deltaTime, which is the amount of time that’s passed since the last frame, and we get a vector of something like (0, 0, 0.032). That way we move ~3cm/frame 60 times/second, which gives us a constant speed of around 2 meters/second.*/
}
