using UnityEngine;
using System.Collections;

/** Applies the current thrust values to change the movement of the object, and constrains to the maximum speed. */
[RequireComponent(typeof(Rigidbody2D))]
public class ThrustControl : MonoBehaviour
{
  /** The maximum allowed rotational thrust value. */
  public float maxRotationalThrust;
  /** The maximum forward thrust. */
  public float forwardMaxThrust;
  /** The maximum backward thrust. */
  public float backwardMaxThrust;
  /** The maximum leftward thrust. */
  public float leftwardMaxThrust;
  /** The maximum rightward thrust. */
  public float rightwardMaxThrust;

  /** The amount of rotational thrust to apply. Positive is counterclockwise. */
  public float rotationalThrust;
  /** Thrust applied in the forward direction. */
  public float forwardThrust;
  /** Thrust applied in the backward (reverse) direction. */
  public float backwardThrust;
  /** Thrust applied in the leftward direction (causes movement to the left.) */
  public float leftwardThrust;
  /** Thrust applied in the rightward direction (causes movement to the right.) */
  public float rightwardThrust;

  void FixedUpdate()
  {
    Rigidbody2D rb = GetComponent<Rigidbody2D>();
    //Debug.Log(rb.velocity.magnitude);
    Vector2 thrustForce = Vector2.zero;
    thrustForce.x = Mathf.Clamp(rightwardThrust - leftwardThrust, -leftwardMaxThrust, rightwardMaxThrust);
    thrustForce.y = Mathf.Clamp(forwardThrust - backwardThrust, -backwardMaxThrust, forwardMaxThrust);
    rb.AddRelativeForce(thrustForce * Time.deltaTime);
    // Apply rotation
    rb.AddTorque(Mathf.Clamp(rotationalThrust, -maxRotationalThrust, maxRotationalThrust) * Time.deltaTime);
    //Debug.log(rb.angularvelocity);
  }

  /** Stop all horizontal and vertical thrust forces. */
  public void StopLinearThrust()
  {
    forwardThrust = 0.0f;
    backwardThrust = 0.0f;
    leftwardThrust = 0.0f;
    rightwardThrust = 0.0f;
  }

  /** Stop all rotational thrust forces. */
  public void StopRotationalThrust()
  {
    rotationalThrust = 0.0f;
  }

  /** Stop all thrust forces. */
  public void StopAllThrust()
  {
    StopLinearThrust();
    StopRotationalThrust();
  }
}
