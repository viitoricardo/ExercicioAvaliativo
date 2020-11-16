using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Patrimonios.Services.Impl;
using Patrimonios.Services.Interface;

namespace Teste
{
    public class Tests
    {
        IExercio1Service Service;
        [SetUp]
        public void Setup()
        {
            
            Service = new Exercicio1Service();
           
        }

        [Test]
        public void TesteParaNumeroFuncional()
        {
            var n = Service.ObterMaiorNumeroIrmao(1234);
            Assert.IsTrue(n == 4321);
        }

        [Test]
        public void TesteParaNumeroMaior10000000()
        {
            var n = Service.ObterMaiorNumeroIrmao(100000001);
            Assert.IsTrue(n == -1, "Não é permitido geração de número maior que 100000000");
        }

        [Test]
        public void TesteParaNumeroNegativo()
        {
            var n = Service.ObterMaiorNumeroIrmao(-10);
            Assert.IsTrue(n == -1, "Não é permitido geração de número negativo");
        }
    }
}