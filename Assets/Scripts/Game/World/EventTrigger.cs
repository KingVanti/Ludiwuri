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
    /// <summary>
    /// Called when the trigger is exited
    /// </summary>
    public UnityEvent onExit;

    #endregion

    #region Methods

    private void OnTriggerEnter2D(Collider2D collision)
    {
        onEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        onExit.Invoke();
    }

    #endregion

}
