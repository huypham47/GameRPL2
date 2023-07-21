using UnityEngine;

public class BulletDamageSender : AllBulletDamageSender
{
    private void OnEnable()
    {
        if (this.allBulletCtrl == null)
        {
            this.damage = 5;
            return;
        }
        this.damage = this.allBulletCtrl.BulletSO.damage;

    }

    public override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.allBulletCtrl.bulletSpawner.Despawn(transform.parent);
    }
}
