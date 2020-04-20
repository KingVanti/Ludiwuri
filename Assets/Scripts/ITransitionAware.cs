namespace Gang1057.Nyctophobia
{

    public interface ITransitionAware
    {
        void OnSceneLoad();
        void OnTransitionCompleted();
        void OnTransitionStarted();
        void OnSceneUnload();
    }

}