using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour, DesructableHitHandler
{
  void DesructableHitHandler.HandleHit(Hit hit)
  {
    GameObject.Destroy(gameObject);
  }
}
