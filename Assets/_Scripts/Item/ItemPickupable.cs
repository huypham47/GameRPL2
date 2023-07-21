using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ItemPickupable : _MonoBehaviour
{
    [SerializeField] protected BoxCollider collider;

    public ItemCtrl itemCtrl;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if (this.collider != null) return;
        this.collider = GetComponent<BoxCollider>();
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemCodeParse.FromString(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.itemCtrl.itemSpawner.Despawn(transform.parent);
    }
}
