using UnityEngine;
using System.Collections;
using System;

public class Projectile : MonoBehaviour, DestructableHitHandler
{
  void DestructableHitHandler.HandleHit(Hit hit)
  {
    GameObject.Destroy(gameObject);
  }
}
