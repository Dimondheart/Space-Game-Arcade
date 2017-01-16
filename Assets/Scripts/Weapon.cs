using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
  public enum Shape
  {
    NONE=0,
    SMALL_GUN,
    SIDE_GUN
  }
  /** The amount of time between each weapon fire. */
  public float fireInterval;
  /** The shape of this weapon. */
  public Shape shape;

  /** The last time the weapon was fired (or if the weapon fires several rounds at a time,
   * this is the starting time for the entire salvo.
   */
  public float lastFireTime { get; protected set; }

  /** Fire the weapon, if there are no effects preventing it from firing, such as not enough
   * time has passed since the previous shot.
   */
  public abstract void Fire();
}
