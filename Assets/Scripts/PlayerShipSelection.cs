﻿using UnityEngine;
using System.Collections;

public class PlayerShipSelection : MonoBehaviour
{
  public Spaceship[] selectableShips;

  public Spaceship activePlayerShip { get; private set; }

  void Start()
  {
    activePlayerShip = selectableShips[0];
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Alpha1))
    {
      SetActiveSpaceship(selectableShips[0]);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha2))
    {
      SetActiveSpaceship(selectableShips[1]);
    }
    else if (Input.GetKeyDown(KeyCode.Alpha3))
    {
      SetActiveSpaceship(selectableShips[2]);
    }
  }

  public void SetActiveSpaceship(Spaceship spaceship)
  {
    spaceship.GetComponent<SpaceshipAI>().enabled = false;
    activePlayerShip.GetComponent<SpaceshipAI>().enabled = true;
    activePlayerShip = spaceship;
  }
}