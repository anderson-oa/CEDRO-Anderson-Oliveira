using RestauranteDDD.Domain.Entities;
using System;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Interfaces.Services
{
    public interface IPratoService : IDisposable
    {
        void Adicionar(Prato prato);
        void Atualizar(Prato prato);
        void Deletar(int id);
        Prato ObterPorId(int id);
        IEnumerable<Prato> ObterTodos();
    }
}