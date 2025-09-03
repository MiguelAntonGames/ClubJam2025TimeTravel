using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class PauseableObject : MonoBehaviour, IPointerClickHandler {
    protected bool _isPaused;

    public void OnPointerClick(PointerEventData eventData) {
        ToggleObjectPause();
    }

    public abstract void ToggleObjectPause();

}
