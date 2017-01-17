using UnityEngine;
using System.Collections;

/** Handles carrying out the effects of a hit on an object. */
public interface DesructableHitHandler
{
  /** Handle causing the effects of the specified hit on this object. */
  void HandleHit(Hit hit);
}
