using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrustControl))]
public class Spaceship : MonoBehaviour
{
  public WeaponMount[] weaponMounts;
  public TurretMount[] turretMounts;
}
