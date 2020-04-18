using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to publish and subscribe to event
/// </summary>
public class EventAggregator : MonoBehaviour
{

    #region Static Properties

    /// <summary>
    /// This scenes instance of the event aggregator
    /// </summary>
    public static EventAggregator Instance { get; private set; }

    #endregion

    #region Methods

    private void Awake()
    {
        Instance = this;
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    #endregion

}
