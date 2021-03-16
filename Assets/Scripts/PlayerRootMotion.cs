

using UnityEngine;

public class PlayerRootMotion : MonoBehaviour
{
    // Allows User/Game Designer to change speed value in the inspector \\ Unity Program
    [SerializeField, Tooltip("The max speed of the player")] private float speed = 4f;

    private Animator anim;
    private CharacterController controller;
    public Weapon weapon;
    private RagdollControl rdC;

    // OnLoad, connect Components to Variables
    private void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        rdC = GetComponent<RagdollControl>();
    }
    private void Start()
    {
        
    }

    // Every Frame, update movement input
    //              update character grounded to check for ability to crouch
    private void Update()
    {
        if (rdC.isDead == false)
        {


            // Pull X/Z axis data and initialize to new variable "input"
            Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

            // Causes PlayerCharacter to always move along X/Z axis, ex. W is always +Z, S is always -Z, etc.
            input = Vector3.ClampMagnitude(input, 1f);
            input = transform.InverseTransformDirection(input);


            /*UNUSED:: input = Vector3.ClampMagnitude(input, 1f);*/
            input *= speed;

            // set X/Z Vector Data from variable "input" to values in animator
            anim.SetFloat("Horizontal", input.x);
            anim.SetFloat("Vertical", input.z);

            // Character grounded, left ctrl, and crouch is false, enable crouching via true and vice versa for disabling crouching. TOGGLE CROUCH
            if (controller.isGrounded)
            {
                // if left control and Crouch is false execute code body
                if (Input.GetKeyDown("left ctrl") && anim.GetBool("Crouch") == false)
                {
                    // set crouch to true
                    anim.SetBool("Crouch", true);
                }
                // else if left control and crouch is true execute code body
                else if (Input.GetKeyDown("left ctrl") && anim.GetBool("Crouch") == true)
                {
                    // set crouch to false
                    anim.SetBool("Crouch", false);
                }
            }

            // Controls for firing bullet
            if (Input.GetMouseButtonDown(0))
            {
                weapon.FireBullet();
            }
        }// End of IF isDead is False

        if(Input.GetKeyDown(KeyCode.F1))
        {
            rdC.isDead = true;
        }
        if(Input.GetKeyDown(KeyCode.F2))
        {
            rdC.isDead = false;
            rdC.TurnOffRagdoll();
        }
    }

    // animator for IK
    private void OnAnimatorIK(int layerIndex)
    {
        // using mask < set the IK Position relative to the weapons handpoint positions
        anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
        anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
        anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
        anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);

        // using mask < set the IK Positions weight for each part of the mask listed
        anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f); 
    }
}
