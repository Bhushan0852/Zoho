using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkDemo.Core.Interfaces;
using UnitOfWorkDemo.Services.Interfaces;
using Zoho.Domain;

namespace UnitOfWorkDemo.Services
{
    public class ClientService : IClientService
    {
        public IUnitOfWork _unitOfWork;


        public ClientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //public Task<bool> DeleteClient(Client client)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<bool> CreateClient(Client Client)
        //{
        //    if (Client != null)
        //    {
        //        await _unitOfWork.Clients.Add(Client);

        //        var result = _unitOfWork.Save();

        //        if (result > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    return false;
        //}

        //public async Task<bool> DeleteClient(Client client)
        //{
        //    if (client.Id > 0)
        //    {
        //        var Client = await _unitOfWork.Clients.GetById(client.Id);
        //        if (Client != null)
        //        {
        //            Client.IsDeleted = true;

        //            _unitOfWork.Clients.Delete(Client);
        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}

        //public async Task<IEnumerable<Client>> GetAllClients(Client client)
        //{
        //    List<Client> ClientList = new List<Client>(); // await _unitOfWork.Clients.GetAll(Client);
        //    return ClientList;
        //}

        //public Task<IEnumerable<Client>> GetAllClients()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<Client> GetClientById(int ClientId)
        //{
        //    if (ClientId > 0)
        //    {
        //        var Client = await _unitOfWork.Clients.GetById(ClientId);
        //        if (Client != null)
        //        {
        //            return Client;
        //        }
        //    }
        //    return null;
        //}

        //public async Task<bool> UpdateClient(Client client)
        //{
        //    if (client != null)
        //    {
        //        var clientd = await _unitOfWork.Clients.GetById(client.Id);
        //        if(clientd != null)
        //        {
        //            clientd.ClientName= client.ClientName;
        //            //clientd.= client.ClientDescription;
        //            //clientd.ClientPrice= client.ClientPrice;
        //            //clientd.ClientStock= client.ClientStock;

        //            _unitOfWork.Clients.Update(clientd);

        //            var result = _unitOfWork.Save();

        //            if (result > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    return false;
        //}

    }
}
