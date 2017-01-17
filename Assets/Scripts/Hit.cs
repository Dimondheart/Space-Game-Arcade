using UnityEngine;
using System.Collections;

public class Hit
{
  public readonly Collision2D collision2D;

  public Hit(Collision2D collision2D)
  {
    this.collision2D = collision2D;
  }
}
