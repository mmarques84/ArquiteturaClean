using Domain.Interfaces;
using Domain.Models;
using Domain.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace TestClient
{
    public class Tests
    {
        ClienteRepository _repository;
        ClienteService _clienteService;
        DBContext _context;
        [SetUp]
        public void Setup()
        {

            var options = new DbContextOptionsBuilder<DBContext>()
                .UseSqlServer("Server=DESKTOP-LV90RO3\\SQLEXPRESS;Database=Desafio;Integrated Security=SSPI;")
                .Options;


            _context = new DBContext(options);
            _repository = new ClienteRepository(_context);
            _clienteService = new ClienteService(_repository);

        }
        
        [Test]
        public void Test1()
        {
            var cliente = _repository.GetById(1);
            if (cliente != null)
            {
                Console.WriteLine("Cliente" + cliente.NomeCompleto);
            }
            else
            {
                Console.WriteLine("Cliente não existe");

            }
            Assert.IsNotNull(cliente);
           
        }
        [Test]
        public void post()
        {
            Cliente newcliente = new Cliente
            {
               NomeCompleto =  "m",
               Ativo=true,
               Endereco="treste",
               Documento=214656
              


            };
            try
            {
                _clienteService.Save(newcliente);
                if (newcliente.Id != 0)
                {
                    Console.WriteLine("Cliente" + newcliente.NomeCompleto);
                }
                else
                {
                    Console.WriteLine("Cliente não cadastrado");

                }
                Assert.IsNotNull(newcliente);
            }
            catch (Exception)
            {

                throw;
            }
           
            

        }
    }
}