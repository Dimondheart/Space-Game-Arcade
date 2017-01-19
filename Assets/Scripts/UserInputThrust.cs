using UnityEngine;
using System.Collections;

public class UserInputThrust : MonoBehaviour
{
  public GameObject spaceship
  {
    get
    {
      return gameController.GetComponent<PlayerShipSelection>().activePlayerShip.gameObject;
    }
  }

  private GameObject gameController;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController");
  }

  void Update()
  {
    if (spaceship == null)
    {
      return;
    }
    float horizontal = Input.GetAxisRaw("Horizontal");
    float vertical = Input.GetAxisRaw("Vertical");
    float rotational = GetRotationThrust();
    ThrustControl thruster = spaceship.GetComponent<ThrustControl>();
    // Appy rotational thrust
    thruster.rotationalThrust = rotational;
    // Apply left/right thrust
    if (Mathf.Approximately(0.0f, horizontal))
    {
      thruster.leftwardThrust = 0.0f;
      thruster.rightwardThrust = 0.0f;
    }
    else if (horizontal > 0.0f)
    {
      thruster.leftwardThrust = 0.0f;
      thruster.rightwardThrust = horizontal * thruster.rightwardMaxThrust;
    }
    else
    {
      thruster.leftwardThrust = Mathf.Abs(horizontal * thruster.leftwardMaxThrust);
      thruster.rightwardThrust = 0.0f;
    }
    // Apply forward/backward thrust
    if (Mathf.Approximately(0.0f, vertical))
    {
      thruster.forwardThrust = 0.0f;
      thruster.backwardThrust = 0.0f;
    }
    else if (vertical > 0.0f)
    {
      thruster.forwardThrust = vertical * thruster.forwardMaxThrust;
      thruster.backwardThrust = 0.0f;
    }
    else
    {
      thruster.forwardThrust = 0.0f;
      thruster.backwardThrust = Mathf.Abs(vertical * thruster.backwardMaxThrust);
    }
  }

  private float GetRotationThrust()
  {
    float thrust = 0.0f;
    Camera mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    Vector2 myPos = mainCamera.WorldToScreenPoint(spaceship.transform.position);
    Vector2 mousePos = Input.mousePosition;
    Vector2 targetDirection = mousePos - myPos;
    Vector3 targetAngle = new Vector3(0.0f, 0.0f, Vector2.Angle(Vector2.up, targetDirection));
    if (targetDirection.x > 0.0f)
    {
      targetAngle.z = 360.0f - targetAngle.z;
    }
    Vector3 currentAngle = spaceship.transform.rotation.eulerAngles;
    if (currentAngle.z < 0.0f)
    {
      currentAngle.z = 360.0f + currentAngle.z;
    }
    float zRotation = targetAngle.z - currentAngle.z;
    if (zRotation > 180.0f)
    {
      zRotation = 180.0f - zRotation;
    }
    else if (zRotation < -180.0f)
    {
      zRotation = 360.0f + zRotation;
    }
    float angularVelocity = spaceship.GetComponent<Rigidbody2D>().angularVelocity;
    //Debug.Log(angularVelocity);
    ThrustControl thruster = spaceship.GetComponent<ThrustControl>();
    if (zRotation < 0.0f && angularVelocity > 0.0f)
    {
      thrust = -thruster.maxRotationalThrust;
    }
    else if (zRotation > 0.0f && angularVelocity < 0.0f)
    {
      thrust = thruster.maxRotationalThrust;
    }
    else
    {
      thrust = zRotation / 180.0f * thruster.maxRotationalThrust;
    }
    return thrust;
  }
}
