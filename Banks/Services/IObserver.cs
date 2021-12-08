using System;

namespace Banks.Classes
{
    public interface IObserver
    {
        void Update(Account account, int percentage);
    }
}