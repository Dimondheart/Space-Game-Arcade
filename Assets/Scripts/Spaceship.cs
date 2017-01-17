using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrustControl))]
public class Spaceship : MonoBehaviour, DesructableHitHandler
{
  public WeaponMount[] weaponMounts;
  public TurretMount[] turretMounts;

  void DesructableHitHandler.HandleHit(Hit hit)
  {
    Debug.Log("Spaceship hit");
  }
}
