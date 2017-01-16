using UnityEngine;
using System.Collections;

/** Any object which cannot be affected like a Destructable, but can
 * affect a Destructable.
 */
public class Destructor : MonoBehaviour
{
  /** Game objects to ignore (will not collide or directly effect the ignored game objects. */
  public GameObject[] ignored;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (!IsIgnoring(other.gameObject) && other.GetComponent<Destructable>() != null)
    {
      Debug.Log("Destructor hit destructable");
      GameObject.Destroy(gameObject);
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
