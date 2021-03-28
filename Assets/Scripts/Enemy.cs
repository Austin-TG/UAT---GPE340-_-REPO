using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [Header("Weapon Spawn")]
    [SerializeField, Tooltip("Weapon selection for enemies")] protected GameObject[] weaponSelections;
    [SerializeField, Tooltip("Weapon Shoot Distance (min)")] protected int[] shootDistance;
    [SerializeField, Tooltip("Transform positions for weapons")] protected Transform weaponStartPosition;

    [Header("Item Drop Settings")]
    [SerializeField, Tooltip("Chance enemy will drop an item")][Range(0.0f, 1.0f)] protected float itemDropChance;
    [SerializeField, Tooltip("CLASS - ObjectWeighted, Item to drop, Chance to choose Item")] protected ObjectWeighted[] itemDrops;
    private GameObject chosenItem;

    [Header("Etc.")]
    private int range;
    protected GameObject weaponChosen;
    protected int distanceToShoot;
    public Weapon weapon;
    public bool isDead;
    [SerializeField] private ParticleSystem muzzleFlash;
    private ParticleSystem afterMuzzleFlash;

    static public System.Random rnd;

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
        if (GameManager.isDead == false)
        {
            float dist = Vector3.Distance(gameObject.transform.position, GameManager.player.transform.position);
            CheckIFCanFire(dist);
        }
        else return;
    }
    private void CheckIFCanFire(float _dist)
    {
        if (isDead != true)
        {
            if (GameManager.isDead != true)
            {
                if (_dist <= distanceToShoot)
                {
                    afterMuzzleFlash = Instantiate(muzzleFlash, weapon.bulletStart.transform.position, Quaternion.identity);
                    weapon.FireBullet();
                    if (afterMuzzleFlash.isStopped)
                    {
                        Destroy(afterMuzzleFlash);
                    }
                }
            }
        }
    }
    private GameObject DropCheck()
    {
        int randomInt = Random.Range(0, itemDrops.Length);
        chosenItem = itemDrops[randomInt].dropItem;
        return chosenItem;
    }
    public void DropItem()
    {
        DropCheck();
        if(Random.Range(0f, 1f) < itemDropChance)
        {
            Instantiate(DropCheck(),transform.position, Quaternion.identity);
        }
    }
    public void OnDie()
    {
        Destroy(gameObject, 5f);
        DropItem();
    }
}
