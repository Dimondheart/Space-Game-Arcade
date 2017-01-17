using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
  public enum Shape
  {
    NONE=0,
    SMALL_GUN,
    SIDE_GUN,
    SMALL_GUN_M2,
    BIG_GUN,
    LAUNCHER
  }
  /** The amount of time between each weapon fire. */
  public float fireInterval;
  /** The shape of this weapon. */
  public Shape shape;

  public bool isTopMounted
  {
    get
    {
      return GetComponent<SpriteRenderer>().sortingLayerName == "ShipTopMount";
    }
    set
    {
      if (value)
      {
        GetComponent<SpriteRenderer>().sortingLayerName = "ShipTopMount";
      }
      else
      {
        GetComponent<SpriteRenderer>().sortingLayerName = "ShipBottomMount";
      }
    }
  }

  protected GameObject spaceship
  {
    get
    {
      return transform.parent.parent.gameObject;
    }
  }

  private bool internalIsTopMounted;

  /** The last time the weapon was fired (or if the weapon fires several rounds at a time,
   * this is the starting time for the entire salvo.
   */
  public float lastFireTime { get; protected set; }

  /** Fire the weapon, if there are no effects preventing it from firing, such as not enough
   * time has passed since the previous shot.
   */
  public abstract void Fire();
}
