using UnityEngine;
using System.Collections;

public class Gun1 : Weapon
{
  public GameObject bullet;
  public GameObject fireAnimation;

  public override void Fire()
  {
    if (Time.time - lastFireTime < fireInterval)
    {
      return;
    }
    lastFireTime = Time.time;
    GameObject newBullet = Instantiate(bullet) as GameObject;
    // Don't allow the bullet to accidentally hit the thing firing
    newBullet.GetComponent<Destructable>().ignored = new GameObject[] { spaceship };
    newBullet.GetComponent<Rigidbody2D>().velocity = spaceship.GetComponent<Rigidbody2D>().velocity;
    GameObject animation = Instantiate(fireAnimation) as GameObject;
    Transform spawn = GetComponentsInChildren<Transform>()[1];
    // Bind the firing animation to the spawn point
    animation.transform.SetParent(spawn, false);
    // Align but not bind the projectile to the spawn point
    newBullet.transform.SetParent(spawn, false);
    newBullet.transform.SetParent(null, true);
  }
}
