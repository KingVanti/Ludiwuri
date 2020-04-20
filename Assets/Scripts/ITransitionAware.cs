namespace Gang1057.Ludiwuri
{

    public interface ITransitionAware
    {
        void OnSceneLoad();
        void OnTransitionCompleted();
        void OnTransitionStarted();
        void OnSceneUnload();
    }

}