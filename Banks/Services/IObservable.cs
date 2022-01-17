namespace Banks.Classes
{
    public interface IObservable
    {
        void AddObserver(IObserver notification);
        void RemoveObserver(IObserver notification);
        void NotifyObservers();
    }
}