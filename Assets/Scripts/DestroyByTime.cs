using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour
{
  public float lifetime;

  void Start()
  {
    GameObject.Destroy(gameObject, lifetime);
  }
}
