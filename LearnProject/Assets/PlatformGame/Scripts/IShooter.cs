using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShooter {

    Color GetBulletColor();

    List<IKillable> GetKillable();
}
