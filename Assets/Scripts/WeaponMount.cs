using UnityEngine;
using System.Collections;

/** A slot for mounting a weapon. */
public class WeaponMount : MonoBehaviour
{
  /** Weapon forms that can be mounted to this mount. */
  public Weapon.Shape[] compatableShapes;
  /** The currently mounted weapon. */
  public Weapon mountedWeapon { get; private set; }

  /** Check if the specified weapon is compatable with this mount. */
  public bool IsWeaponCompatable(Weapon weapon)
  {
    foreach (Weapon.Shape shape in compatableShapes)
    {
      if (weapon.shape == shape)
      {
        return true;
      }
    }
    return false;
  }

  /** Attempts to mount the specified weapon. If the specified weapon is not compatable with
   * this mount, it will not be mounted.
   */
  public void MountWeapon(Weapon weapon)
  {
    if (IsWeaponCompatable(weapon))
    {
      weapon.gameObject.transform.SetParent(transform, false);
      mountedWeapon = weapon;
    }
  }

  /** Remove the currently mounted weapon. */
  public void UnmountWeapon()
  {
    mountedWeapon = null;
  }
}
