using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : PauseableObject {
    [Tooltip("Negative: moves to the left. Positive: Moves to the right")]
    [SerializeField] private float _movementSpeed = -1;

    private void Update() {
        if (_isPaused)
            return;
        Vector3 pos = transform.position;
        pos.x += _movementSpeed * Time.deltaTime;
        transform.position = pos;
    }

    public override void ToggleObjectPause() {
        _isPaused = !_isPaused;
        if (_isPaused)
            gameObject.layer = GameManager.GROUND_LAYER;
        else
            gameObject.layer = GameManager.DEFAULT_LAYER;
    }

}
