using UnityEngine;
using System.Collections;

public class TurretMount : MonoBehaviour
{
  /** Turret forms that can be mounted to this mount. */
  public Turret.Shape[] compatableShapes;
  /** The currently mounted turret. */
  public Turret mountedTurret { get; private set; }

  /** Check if the specified turret is compatable with this mount. */
  public bool IsTurretCompatable(Turret turret)
  {
    foreach (Turret.Shape shape in compatableShapes)
    {
      if (turret.shape == shape)
      {
        return true;
      }
    }
    return false;
  }

  /** Attempts to mount the specified turret. If the specified turret is not compatable with
   * this mount, it will not be mounted.
   */
  public void MountTurret(Turret turret)
  {
    if (IsTurretCompatable(turret))
    {
      turret.gameObject.transform.SetParent(transform, false);
      mountedTurret = turret;
    }
  }

  /** Remove the currently mounted turret. */
  public void UnmountTurret()
  {
    mountedTurret = null;
  }
}
