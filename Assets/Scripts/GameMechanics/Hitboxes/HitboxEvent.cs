using UnityEngine;
using System.Collections;
/// <summary>
/// Attach this interface to scripts that need to react to a hitbox, such as for damage or other special events
/// </summary>
public interface HitboxEvent {
    void onHitBoxEntered(Hitbox hBox);
    void onHurtBoxEntered(Hitbox hBox);
    void onHitboxExit(Hitbox hBox);
    void onHurtboxExit(Hitbox hBox);
}
