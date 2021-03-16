using UnityEngine;

public class MouseFollow : MonoBehaviour
{
    // Variables 
    private float distanceToPlane;
    private Vector3 worldPoint;
    public float speed = 180f;
    private RagdollControl rdC;

    private void Start()
    {
        rdC = GetComponent<RagdollControl>();
    }
    // update every frame
    private void Update()
    {
        if (rdC.isDead == false)
        {

            // create plane thats x,y,z position is 0,1,0 according to the linked objects position
            Plane worldPlane = new Plane(Vector3.up, transform.position);
            // creates a ray from origin(camera) to screen point
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            // if statement
            // condition - if the ray casts and hits the plane return the distance from the camera to the point
            if (worldPlane.Raycast(mouseRay, out distanceToPlane))
            {
                // if true - get the point where the ray hits on the plane
                worldPoint = mouseRay.GetPoint(distanceToPlane);
                // pass the point where the ray hit the plane to a function to rotate the pawn in the direction of the mouse location
                PawnFollowMouse(worldPoint);
            }
        }
    }
    // new function to rotate pawn on Y-axis, towards specific point passed to function from Update()
    private void PawnFollowMouse(Vector3 worldPoint)
    {
        // create quaternion variable - subtract vector3 values to get x,y,z location needed to rotate pawn
        Quaternion targetRotation = Quaternion.LookRotation(worldPoint - transform.position);
        // change pawns rotation value - current point, new point, rotate speed (8 is to raise speed without needing large numbers in inspector), multiply speed by time.deltatime to change unit speed per sec
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, speed * 8 * Time.deltaTime);
    }
}
