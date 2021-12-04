using System;
using System.Collections.Generic;
using Banks.Classes;

namespace Banks.Services
{
    public class BanksManager : IBanksManager
    {
        private List<Client> _doubtfulClients = new List<Client>();
        public Client CreateClient(string name, string surname, Guid id)
        {
            var builder = new Client.ClientBuilder();
            Client.ClientBuilder clientToBuild = Client.ToBuild(builder);
            clientToBuild.WithName(name)
                .WithSurname(surname)
                .WithAddress(null)
                .WithPassport(0)
                .WithId(id)
                .WithAccount(null);
            Client newClient = clientToBuild.Build();
            _doubtfulClients.Add(newClient);
            return newClient;
        }

        public void AddClientAddess(Client client, string address)
        {
            client.SetAddress(address);
        }

        public void AddClientPassport(Client client, int passport)
        {
            client.SetPassport(passport);
        }
    }
}