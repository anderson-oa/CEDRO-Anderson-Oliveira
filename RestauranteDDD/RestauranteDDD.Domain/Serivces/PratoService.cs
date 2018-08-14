using RestauranteDDD.Domain.Entities;
using RestauranteDDD.Domain.Interfaces;
using RestauranteDDD.Domain.Interfaces.Repositories;
using RestauranteDDD.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace RestauranteDDD.Domain.Serivces
{
    public class PratoService : BaseService, IPratoService
    {
        private readonly IPratoRepository _pratoRepository;

        public PratoService(IUnitOfWork unitOfWork, IPratoRepository pratoRepository) : base(unitOfWork)
        {
            _pratoRepository = pratoRepository;
        }

        public void Adicionar(Prato prato)
        {
            BeginTransaction();

            _pratoRepository.Adicionar(prato);

            Commit();
        }

        public void Atualizar(Prato prato)
        {
            BeginTransaction();

            var pratoAtual = _pratoRepository.ObterPorId(prato.PratoId);
            pratoAtual.Update(prato);
            _pratoRepository.Atualizar(pratoAtual);

            Commit();
        }

        public void Deletar(int id)
        {
            BeginTransaction();

            var prato = _pratoRepository.ObterPorId(id);
            _pratoRepository.Deletar(prato);

            Commit();
        }

        public Prato ObterPorId(int id)
        {
            return _pratoRepository.ObterPorId(id);
        }

        public IEnumerable<Prato> ObterTodos()
        {
            return _pratoRepository.ObterTodos();
        }

        public void Dispose()
        {
            _pratoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}