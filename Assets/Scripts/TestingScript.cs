using UnityEngine;
using System.Collections;

public class TestingScript : MonoBehaviour
{
  public Weapon[] mountableWeapons;
  public Spaceship[] mountOnShips;

  void Start()
  {
    foreach (Spaceship ship in mountOnShips)
    {
      foreach (WeaponMount mount in ship.weaponMounts)
      {
        foreach (Weapon weapon in mountableWeapons)
        {
          if (mount.IsWeaponCompatable(weapon))
          {
            mount.MountWeapon((Instantiate(weapon.gameObject) as GameObject).GetComponent<Weapon>());
          }
        }
      }
    }
  }
}
