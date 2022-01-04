using System;
using System.Collections.Generic;

namespace Banks.Classes
{
    public interface IObserverBanks
    {
        void UpdateBanks(CentralBank bank);
    }
}