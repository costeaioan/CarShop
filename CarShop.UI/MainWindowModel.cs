﻿using System.Collections.ObjectModel;
using Carshop.Core.Entities;
using CarShop.Infrastructure.Repositories;

namespace CarShop.UI
{
    public class MainWindowModel
    {
        private readonly IGenericRepository<Car> _carRepository;
        private readonly IGenericRepository<Client> _clientRepository;

        public ObservableCollection<Car> Cars { get; }
        public ObservableCollection<Client> Clients { get; }

        public MainWindowModel(IGenericRepository<Car> carRepository, IGenericRepository<Client> clientRepository)
        {
            _carRepository = carRepository;
            _clientRepository = clientRepository;

            Cars = new ObservableCollection<Car>(_carRepository.GetAll());
            Clients = new ObservableCollection<Client>(_clientRepository.GetAll());
        }

        public void AddCar(Car car)
        {
            _carRepository.Add(car);
            Cars.Add(car);
        }

        public void AddClient(Client client)
        {
            _clientRepository.Add(client);
            Clients.Add(client);
        }

        public void SaveChanges()
        {
            _carRepository.SaveChanges();
            _clientRepository.SaveChanges();
        }

        public void DeleteCar(int carId)
        {
            _carRepository.Delete(carId);
        }

        public void DeleteClient(int clientId) {
            _clientRepository.Delete(clientId);
        }

        public IEnumerable<Car> GetCars()
        {
            return _carRepository.GetAll();
        }

        public IEnumerable<Client> GetClients()
        {
            return _clientRepository.GetAll();
        }
    }
}
