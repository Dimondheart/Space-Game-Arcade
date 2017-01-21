using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ThrustControl))]
public class Spaceship : MonoBehaviour, DestructableHitHandler
{
  public WeaponMount[] weaponMounts;
  public TurretMount[] turretMounts;
  public int maxHP;

  public int hp { get; set; }

  private int shieldHP;

  void Start()
  {
    hp = maxHP;
    shieldHP = 1000;
  }

  void DestructableHitHandler.HandleHit(Hit hit)
  {
    int damageNegated = HitShields(hit, 0);
    damageNegated += HitArmour(hit, damageNegated);
    HitHull(hit, damageNegated);
    if (hp == 0)
    {
      GameObject.Destroy(gameObject);
    }
  }

  private int HitShields(Hit hit, int negatedDamage)
  {
    Destructable otherD = hit.collision2D.gameObject.GetComponent<Destructable>();
    int damage = 10;
    if (otherD.hitType == Hit.Type.ENERGY)
    {
      damage = 50;
      if (shieldHP < damage)
      {
        damage = shieldHP;
        shieldHP = 0;
      }
      else
      {
        shieldHP -= damage;
      }
    }
    else
    {
      if (shieldHP < damage)
      {
        damage = shieldHP;
        shieldHP = 0;
      }
      else
      {
        shieldHP -= damage;
      }
    }
    return damage;
  }

  private int HitArmour(Hit hit, int negatedDamage)
  {
    return 0;
  }

  private void HitHull(Hit hit, int negatedDamage)
  {
    hp = Mathf.Max(0, hp - Mathf.Max(0, 100 - negatedDamage));
  }
}
