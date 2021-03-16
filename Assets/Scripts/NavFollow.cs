using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavFollow : Enemy
{
    private Vector3 desiredVelo;
    private Animator _anim;
    protected NavMeshAgent navAgent;
    private int _dist;

    protected override void Start()
    {
        _anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        _dist = distanceToShoot;
        SetStoppingDistance(_dist);
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        SetDestinationToPlayer();

        if (isDead != true)
        {
            // Set wanted velocity to the navAgent instead of using animator velocity
            Vector3 navInput = navAgent.desiredVelocity;
            desiredVelo = Vector3.MoveTowards(desiredVelo, navAgent.desiredVelocity, navAgent.acceleration * Time.deltaTime);
            navInput = transform.InverseTransformDirection(desiredVelo);
            _anim.SetFloat("Horizontal", navInput.x);
            _anim.SetFloat("Vertical", navInput.z);
        }
        base.Update();
    }
    private void OnAnimatorMove()
    {
        navAgent.velocity = _anim.velocity;
    }
    void SetDestinationToPlayer()
    {
        if (GameManager.player == null)
        {
            if (GameManager.isDead == true)
            {
                // .Stop is Deprecated, along with .Pause and .Start, replaced with .isStopped.
                navAgent.isStopped = true;
                _anim.SetFloat("Horizontal", 0f);
                _anim.SetFloat("Vertical", 0f);
                return;
            }
        }
        if(GameManager.player != null)
        {
            if(GameManager.isDead != true)
            {
                gameObject.transform.LookAt(GameManager.player.transform.position);
                navAgent.SetDestination(GameManager.player.transform.position);
            }
        }
    }
    // animator for IK
    private void OnAnimatorIK(int layerIndex)
    {
        // using mask < set the IK Position relative to the weapons handpoint positions
        _anim.SetIKPosition(AvatarIKGoal.LeftHand, weapon.leftHandPoint.position);
        _anim.SetIKPosition(AvatarIKGoal.RightHand, weapon.rightHandPoint.position);
        _anim.SetIKRotation(AvatarIKGoal.LeftHand, weapon.leftHandPoint.rotation);
        _anim.SetIKRotation(AvatarIKGoal.RightHand, weapon.rightHandPoint.rotation);

        // using mask < set the IK Positions weight for each part of the mask listed
        _anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
        _anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
        _anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
        _anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
    }
    public void SetStoppingDistance(int distance)
    {
        navAgent.stoppingDistance = distance;
    }
}
   