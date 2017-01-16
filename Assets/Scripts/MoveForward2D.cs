using UnityEngine;
using System.Collections;

public class MoveForward2D : MonoBehaviour
{
  public float initialForce;

  void Start()
  {
    GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * initialForce);
  }
}
