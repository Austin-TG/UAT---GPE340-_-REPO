using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollControl : MonoBehaviour
{
    // Variables
    // Parent Components
    private CapsuleCollider _coll;
    private Rigidbody _rb;
    private Animator _anim;

    // Child Components
    private CapsuleCollider[] _collChild;
    private Rigidbody[] _rbChild;

    public bool isDead;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _coll = GetComponent<CapsuleCollider>();
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (isDead == true)
        {
            TurnOnRagdoll();
        }
    }
    public void TurnOffRagdoll()
    {
        _collChild = GetComponentsInChildren<CapsuleCollider>();
        // FOR Loop, turns off child objects colliders
        for (int i = 0; i < _collChild.Length; i++)
        {
            _collChild[i].enabled = false;
        }
        _rbChild = GetComponentsInChildren<Rigidbody>();
        // FOR Loop, disables all child objects kinematic option within their rigidbodies
        for (int i = 0; i < _rbChild.Length; i++)
        {
            _rbChild[i].isKinematic = true;
        }
        _coll.enabled = true;
        _rb.isKinematic = false;
        _anim.enabled = true;
    }
    private void TurnOnRagdoll()
    {
        _collChild = GetComponentsInChildren<CapsuleCollider>();
        // FOR Loop, turns on child objects colliders
        for (int i = 0; i < _collChild.Length; i++)
        {
            _collChild[i].enabled = true;
        }
        _rbChild = GetComponentsInChildren<Rigidbody>();
        // FOR Loop, disables ALL child objects Kinematic Option within their rigidbodies
        for (int i = 0; i < _rbChild.Length; i++)
        {
            _rbChild[i].isKinematic = false;
        }
        _coll.enabled = false;
        _rb.isKinematic = true;
        _anim.enabled = false;
    }
}
