using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBase : MonoBehaviour
{
    public PoolObjectType bulletType = PoolObjectType.Bullet;

    public float fireInterval = 1.0f;

    protected Transform fireTransform;

    protected IEnumerator PeriodFire()
    {
        while (true)
        {
            Factory.Instance.GetObject(bulletType, fireTransform.position, fireTransform.rotation.eulerAngles);
            yield return new WaitForSeconds(fireInterval);
        }
    }
}
