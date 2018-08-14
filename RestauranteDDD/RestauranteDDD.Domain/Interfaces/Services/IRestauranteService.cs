using RestauranteDDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Interfaces.Services
{
    public interface IRestauranteService : IDisposable
    {
        void Adicionar(Restaurante restaurante);
        void Atualizar(Restaurante restaurante);
        void Deletar(int id);
        Restaurante ObterPorId(int id);
        IEnumerable<Restaurante> ObterTodos();
    }
}