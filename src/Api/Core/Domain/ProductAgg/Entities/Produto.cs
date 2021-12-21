using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using MediatR;
using Poo.Api.Core.Application.ProductAgg.Contracts;
using Poo.Api.Core.Domain.ProductAgg.Events;
using Poo.Api.Core.Domain.Shared;

namespace Poo.Api.Core.Domain.ProductAgg.Entities;

    public class Produto : IAggregateRoot
    {
        private ICollection<INotification> _domainEvents;

        private Produto()
        {
        }
        public Produto(string nome, long valor) : this()
        {
            ExternalId = Guid.NewGuid().ToString();
            Nome = nome;
            Valor = valor;
            Status = "Ativo";
            _domainEvents = new List<INotification>();
            RaiseDomainEvent(new ProdutoCriado(this));
        }

        public long Id { get; private set; }
        public string ExternalId { get; private set; }
        public string Nome { get; private set; }
        public string Status { get; private set; }
        public long Valor { get; private set; }

        public void Atualizar(IAtualizarProduto atualizarProduto)
        {
            Nome = atualizarProduto.Nome;
            Valor = atualizarProduto.Valor;
        }

        internal void Deletar()
        {
            Status = "Inativo";
        }

        private void RaiseDomainEvent(INotification notification)
        {
            _domainEvents.Add(notification);
        }

        public ICollection<INotification> GetDomainEvents()
        {
            return _domainEvents.ToImmutableList();
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
