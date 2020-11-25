using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public enum TypeOfWeapon { Pistol, Rifle };
    public TypeOfWeapon weaponType;
    public Transform offHandPlacement;
}
