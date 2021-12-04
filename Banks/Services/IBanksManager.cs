using System;
using Banks.Classes;

namespace Banks.Services
{
    public interface IBanksManager
    {
        Client CreateClient(string name, string surname, Guid id);
        void AddClientAddess(Client client, string address);
        void AddClientPassport(Client client, int passport);
    }
}