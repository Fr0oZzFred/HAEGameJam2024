using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorChanger : Prop {
    [SerializeField] Transform newPos;
    public override void OnPlayerTouched(Player player) {
        base.OnPlayerTouched(player);
        player.transform.position = newPos.position;
    }
}
