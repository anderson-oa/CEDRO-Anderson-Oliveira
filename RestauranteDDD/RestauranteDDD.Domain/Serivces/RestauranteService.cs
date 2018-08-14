using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Serivces
{
    public class RestauranteService : BaseService, IRestauranteService
    {
        private readonly IRestauranteRepository _restauranteRepository;

        public RestauranteService(IUnitOfWork unitOfWork, IRestauranteRepository restauranteRepository) : base(unitOfWork)
        {
            _restauranteRepository = restauranteRepository;
        }

        public void Adicionar(Restaurante restaurante)
        {
            BeginTransaction();

            _restauranteRepository.Adicionar(restaurante);

            Commit();
        }

        public void Atualizar(Restaurante restaurante)
        {
            BeginTransaction();

            var restauranteAtual = _restauranteRepository.ObterPorId(restaurante.RestauranteId);
            restauranteAtual.Update(restaurante);
            _restauranteRepository.Atualizar(restauranteAtual);

            Commit();
        }

        public void Deletar(int id)
        {
            BeginTransaction();

            var restaurante = _restauranteRepository.ObterPorId(id);
            _restauranteRepository.Deletar(restaurante);

            Commit();
        }

        public Restaurante ObterPorId(int id)
        {
            return _restauranteRepository.ObterPorId(id);
        }

        public IEnumerable<Restaurante> ObterTodos()
        {
            return _restauranteRepository.ObterTodos();
        }

        public void Dispose()
        {
            _restauranteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}