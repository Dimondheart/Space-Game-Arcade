using UnityEngine;
using System.Collections;

public abstract class Turret : MonoBehaviour
{
  public enum Shape
  {
    NONE = 0,
    TURRET_ONE
  }

  /** The shape of this turret. */
  public Shape shape;

  /** Fire the weapons on this turret, if there are no effects preventing them from firing. */
  public abstract void Fire();
}
