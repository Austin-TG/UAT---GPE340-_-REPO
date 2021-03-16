using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField, Tooltip("Weapon selection for enemies")] protected GameObject[] weaponSelections;
    [SerializeField, Tooltip("Weapon Shoot Distance (min)")] protected int[] shootDistance;
    [SerializeField, Tooltip("Transform positions for weapons")] protected Transform weaponStartPosition;
    private int range;
    protected GameObject weaponChosen;
    protected int distanceToShoot;
    public Weapon weapon;
    public bool isDead;

    private void Awake()
    {
        ChooseWeapon();
    }
    protected virtual void Start()
    {

    }
    public virtual void Update()
    {
        CheckDistanceToPlayer();
    }
    private void ChooseWeapon()
    {
        range = Random.Range(0, weaponSelections.Length);
        weaponChosen = weaponSelections[range];
        distanceToShoot = shootDistance[range];
        EquipWeapon(weaponChosen, weaponStartPosition);
    }
    private void EquipWeapon(GameObject weaponToEquip, Transform assignLocation)
    {
        Instantiate(weaponToEquip, assignLocation);
        HookComponents();
        
    }
    private void HookComponents()
    {
        weapon = gameObject.GetComponentInChildren<EnemyWeapon>();

        weapon.leftHandPoint = weapon.transform.Find("LeftHand");
        weapon.rightHandPoint = weapon.transform.Find("RightHand");
        weapon.bulletStart = weapon.transform.Find("FireLocation");
    }
    private void CheckDistanceToPlayer()
    {
        if (GameManager.isDead != true)
        {
            float dist = Vector3.Distance(gameObject.transform.position, GameManager.player.transform.position);
            CheckIFCanFire(dist);
        }
    }
    private void CheckIFCanFire(float _dist)
    {
        if (isDead != true)
        {
            if (GameManager.isDead != true)
            {
                if (_dist <= distanceToShoot)
                {
                    weapon.FireBullet();
                }
            }
        }
    }
}
