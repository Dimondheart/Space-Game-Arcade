using UnityEngine;
using System.Collections;

public class FollowObjectRigid2D : MonoBehaviour
{
  public Transform toFollow;

  private GameObject gameController;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController");
  }

  void Update()
  {
    // If this is attached to the main camera, update the current thing to follow
    if (CompareTag("MainCamera"))
    {
      toFollow = gameController.GetComponent<PlayerShipSelection>().activePlayerShip.transform;
    }
    if (toFollow == null)
    {
      return;
    }
    transform.position = new Vector3(toFollow.position.x, toFollow.position.y, transform.position.z);
  }
}
