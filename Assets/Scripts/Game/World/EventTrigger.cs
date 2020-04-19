using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Used to detect the player
/// </summary>
public class EventTrigger : MonoBehaviour
{

    #region Fields

    /// <summary>
    /// Called when the trigger is entered
    /// </summary>
    public UnityEvent onEnter;

#pragma warning disable 649

    /// <summary>
    /// Whether the trigger should only fire once
    /// </summary>
    [SerializeField] private bool once = true;

#pragma warning restore 649

    /// <summary>
    /// Whether the trigger was already triggered
    /// </summary>
    private bool triggered;

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!once || !triggered)
        {
            onEnter.Invoke();
            triggered = true;
        }
    }

    #endregion

}
