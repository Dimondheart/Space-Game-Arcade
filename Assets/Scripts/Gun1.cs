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
    GameObject animation = Instantiate(fireAnimation) as GameObject;
    Transform spawn = GetComponentsInChildren<Transform>()[1];
    animation.transform.SetParent(spawn, false);
    newBullet.transform.SetParent(spawn, false);
    newBullet.transform.SetParent(null, true);
  }
}
