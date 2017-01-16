using UnityEngine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
  public float lowestZoom;
  public float highestZoom;
  public float zoomStep;
  public float zoomSmoothTime;

  public float targetZoom;
  public float currentZoom
  {
    get
    {
      return -transform.position.z;
    }
    protected set
    {
      transform.position = new Vector3(transform.position.x, transform.position.y, -value);
    }
  }

  private float smoothStartTime;

  void Start()
  {
    currentZoom = targetZoom;
  }

  void Update()
  {
    if (Input.mouseScrollDelta.magnitude > 0.0f)
    {
      targetZoom += -Input.mouseScrollDelta.y * zoomStep;
      targetZoom = Mathf.Clamp(targetZoom, lowestZoom, highestZoom);
    }
  }

  void FixedUpdate()
  {
    if (Mathf.Approximately(targetZoom, currentZoom))
    {
      currentZoom = targetZoom;
      smoothStartTime = Time.time;
    }
    else
    {
      currentZoom = Mathf.Lerp(currentZoom, targetZoom, (Time.time - smoothStartTime) / zoomSmoothTime);
    }
  }
}
