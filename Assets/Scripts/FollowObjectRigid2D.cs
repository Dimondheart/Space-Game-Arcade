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
      Spaceship go = gameController.GetComponent<PlayerShipSelection>().activePlayerShip;
      if (go == null)
      {
        toFollow = null;
      }
      else
      {
        toFollow = go.transform;
      }
    }
    if (toFollow != null)
    {
      transform.position = new Vector3(toFollow.position.x, toFollow.position.y, transform.position.z);
    }
  }
}
