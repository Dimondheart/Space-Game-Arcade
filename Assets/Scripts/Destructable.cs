using UnityEngine;
using System.Collections;

/** Any object which can be affected by collisions with other destructables
 * or other objects.
 */
public class Destructable : MonoBehaviour
{
  /** The minimum relative speed required for a collision with another Destructable
   * to damage this Destructable. Ignored if the other destructable is marked to ignore this.
   */
  public float minimumDamageSpeed;
  public bool ignoreMinimumDamageSpeed;
  /** Game objects to ignore (will not collide or directly effect the ignored game objects.) */
  public GameObject[] ignored;

  void OnCollisionEnter2D(Collision2D collision)
  {
    Destructable other = collision.gameObject.GetComponent<Destructable>();
    if (!IsIgnoring(collision.gameObject) && other != null)
    {
      if (other.ignoreMinimumDamageSpeed || Mathf.Abs(collision.relativeVelocity.magnitude) >= minimumDamageSpeed)
      {
        Debug.Log("Destructor damages destructable");
        GetComponent<DesructableHitHandler>().HandleHit(new Hit(collision));
      }
    }
  }

  /** Check if this destructor is ignoring the specified game object. */
  public bool IsIgnoring(GameObject other)
  {
    foreach (GameObject ignore in ignored)
    {
      if (Object.ReferenceEquals(ignore, other))
      {
        return true;
      }
    }
    return false;
  }
}
