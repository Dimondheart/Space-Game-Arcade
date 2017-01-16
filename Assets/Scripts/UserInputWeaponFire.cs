using UnityEngine;
using System.Collections;

public class UserInputWeaponFire : MonoBehaviour
{
  public Spaceship spaceship
  {
    get
    {
      return gameController.GetComponent<PlayerShipSelection>().activePlayerShip;
    }
  }

  private GameObject gameController;

  void Start()
  {
    gameController = GameObject.FindGameObjectWithTag("GameController");
  }

  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      foreach (WeaponMount mount in spaceship.weaponMounts)
      {
        if (mount.mountedWeapon != null)
        {
          mount.mountedWeapon.Fire();
        }
      }
    }
  }
}
