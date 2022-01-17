using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public interface IObserver
    {
        void Update(Account account, int percentage);
    }
}