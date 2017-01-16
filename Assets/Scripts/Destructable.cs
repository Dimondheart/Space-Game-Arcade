using UnityEngine;
using System.Collections;

/** Any object which can be affected by collisions with other destructables
 * or other objects.
 */
public class Destructable : MonoBehaviour
{
  /** The minimum relative speed required for a collision with another Destructable
   * to damage this Destructable.
   */
  public float minimumDamageSpeed;

  void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.relativeVelocity.magnitude >= minimumDamageSpeed)
    {
      Debug.Log(collision.relativeVelocity.magnitude);
      Debug.Log("(" + gameObject + ") damaged");
    }
  }
}
