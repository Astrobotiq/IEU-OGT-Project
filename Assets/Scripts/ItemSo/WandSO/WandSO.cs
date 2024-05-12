using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WandSO : ItemSo
{
    public int amount;
    public abstract void onUse(Vector3 playerPos,Vector3 mousePos);
}
