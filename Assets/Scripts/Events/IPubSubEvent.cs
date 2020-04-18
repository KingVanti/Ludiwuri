namespace Gang1057.Ludiwuri.Events
{

    /// <summary>
    /// Interface implemented by all pub/sub events
    /// </summary>
    public interface IPubSubEvent { }

    /// <summary>
    /// Interface implemented by all pub/sub events
    /// </summary>
    /// <typeparam name="T">The events payload type</typeparam>
    public interface IPubSubEvent<T> : IPubSubEvent { }

}
