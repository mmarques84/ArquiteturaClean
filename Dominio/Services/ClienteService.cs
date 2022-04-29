using Domain.Interfaces;
using Domain.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

namespace Domain.Services
{
    public class ClienteService
    {
        private readonly IRepository<Cliente> _clienteRepository;
        public ClienteService(IRepository<Cliente> clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public class ClienteValidator : AbstractValidator<Cliente> 
        {
            public ClienteValidator()
            {
                RuleFor(p => p.NomeCompleto)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("{PropertyName} is Empty")
                .Length(2, 50).WithMessage("Length ({TotalLength}) of {PropertyName} Invalid");

                RuleFor(p => p.Documento).NotEmpty().WithMessage("{PropertyName} is Empty");
             
            }
        }
        protected bool BeAValidName(string name)
        {
            name = name.Replace(" ", "");
            name = name.Replace("-", "");
            return name.All(Char.IsLetter);
        }
        public bool Save(Cliente cli)
        {
            var clie = _clienteRepository.GetDOC(cli.Documento);
            if (clie.Count() > 0)
            {
                return false;
            }
            var cliente = _clienteRepository.GetById(cli.Id);
            try
            {
                if (cliente == null)
                {
                    _clienteRepository.Save(cli);
                    return true;
                }
                else
                    _clienteRepository.UPDATE(cli);
                return true;
            }
            catch (Exception ex)
            {

                throw;
                return false;
            }
        }

        public IEnumerable<Cliente> getDoc(int doc)
        {
            var cliente = _clienteRepository.GetDOC(doc);
            return cliente;
        }

    }
}
