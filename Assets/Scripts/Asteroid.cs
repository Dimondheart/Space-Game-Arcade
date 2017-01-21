using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Asteroid : MonoBehaviour, DestructableHitHandler
{
  /** Asteroids that can emerge from this one when it splits. Should be sorted from
   * smallest mass to largest mass.
   */
  public GameObject[] smallerAsteroids;

  void DestructableHitHandler.HandleHit(Hit hit)
  {
    BreakApart();
  }

  /** Break apart and move the pieces away from the specified direction. */
  public void BreakApart()
  {
    // Just destroy this if there are no smaller asteroids to break into
    if (smallerAsteroids.Length <= 0)
    {
      Deteriorate();
      return;
    }
    // Break into any number of smaller asteroids with a total mass <= this asteroids mass
    float remainingMass = GetComponent<Rigidbody2D>().mass;
    int iLargestAllowedAsteroid = smallerAsteroids.Length - 1;
    while (iLargestAllowedAsteroid >= 0)
    {
      int iToInstantiate = 0;
      if (iLargestAllowedAsteroid != 0)
      {
        iToInstantiate = Random.Range(0, iLargestAllowedAsteroid);
      }
      Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
      GameObject newAsteroid = Instantiate(smallerAsteroids[iToInstantiate], transform.position, rotation) as GameObject;
      newAsteroid.GetComponent<Rigidbody2D>().velocity = GetComponent<Rigidbody2D>().velocity;
      float angleOfAppliedForce = Random.Range(60.0f, 300.0f);
      float appliedForceMagnitude = Random.Range(10.0f, 100.0f);
      Vector2 appliedForce = (Quaternion.Euler(0.0f, 0.0f, angleOfAppliedForce) * Vector2.right) * appliedForceMagnitude;
      newAsteroid.GetComponent<Rigidbody2D>().AddForce(appliedForce);
      remainingMass -= (newAsteroid.GetComponent<Rigidbody2D>().mass * 1.5f);
      while (iLargestAllowedAsteroid >= 0 && remainingMass < smallerAsteroids[iLargestAllowedAsteroid].GetComponent<Rigidbody2D>().mass)
      {
        iLargestAllowedAsteroid--;
      }
    }
    Deteriorate();
  }

  public void Deteriorate()
  {
    Destroy(gameObject);
  }
}
