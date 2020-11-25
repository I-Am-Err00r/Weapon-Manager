using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleWeapon : Character
{
    public Transform weaponHand;
    public Transform weaponRotation;
    public Transform offHandIK;
    public List<Weapon> weapons = new List<Weapon>();

    private Weapon[] currentWeapons;
    private GameObject currentWeapon;


    /*
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        foreach(Weapon weapon in weapons)
        {
            Instantiate(weapon);
        }
        currentWeapons = FindObjectsOfType<Weapon>();
        foreach(Weapon weapon in currentWeapons)
        {
            weapon.gameObject.transform.SetParent(transform);
            weapon.gameObject.SetActive(false);
        }
        ChangeWeapon();
    }
    */

    protected override void Initializtion()
    {
        base.Initializtion();
        foreach (Weapon weapon in weapons)
        {
            Instantiate(weapon);
        }
        currentWeapons = FindObjectsOfType<Weapon>();
        foreach (Weapon weapon in currentWeapons)
        {
            weapon.gameObject.transform.SetParent(transform);
            weapon.gameObject.SetActive(false);
        }
        ChangeWeapon();
    }

    private void Update()
    {
        ManageInput();
    }

    
    private void LateUpdate()
    {
        ManagePlacement();
    }

    private void ManageInput()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeWeapon();
        }
    }

    private void ChangeWeapon()
    {
        for (int i = 0; i < currentWeapons.Length; i++)
        {
            if (currentWeapon == null)
            {
                currentWeapons[0].gameObject.SetActive(true);
                currentWeapon = currentWeapons[0].gameObject;
                SetAnimator();
                return;
            }
            else
            {
                currentWeapons[i].gameObject.SetActive(false);
                if (currentWeapons[i].gameObject == currentWeapon)
                {
                    i++;
                    if (i == currentWeapons.Length)
                    {
                        i = 0;
                    }
                    currentWeapons[i].gameObject.SetActive(true);
                    currentWeapon = currentWeapons[i].gameObject;
                    SetAnimator();
                }
            }
        }
    }

    private void ManagePlacement()
    {
        if (currentWeapon != null)
        {
            currentWeapon.transform.position = weaponHand.position;
            offHandIK.position = currentWeapon.GetComponent<Weapon>().offHandPlacement.position;
            currentWeapon.transform.rotation = weaponRotation.rotation;
        }
    }

    private void SetAnimator()
    {
        if (currentWeapon.GetComponent<Weapon>().weaponType == Weapon.TypeOfWeapon.Pistol)
        {
            anim.SetBool("Pistol", true);
            anim.SetBool("Rifle", false);
        }
        if (currentWeapon.GetComponent<Weapon>().weaponType == Weapon.TypeOfWeapon.Rifle)
        {
            anim.SetBool("Rifle", true);
            anim.SetBool("Pistol", false);
        }
    }
}
