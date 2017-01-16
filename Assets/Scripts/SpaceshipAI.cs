using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Spaceship))]
public class SpaceshipAI : MonoBehaviour
{
  void Update()
  {
    ThrustControl thruster = GetComponent<ThrustControl>();
    thruster.StopAllThrust();
  }
}
