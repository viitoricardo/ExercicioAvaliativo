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
        public void Test1()
        {
            var n = Service.ObterMaiorNumeroIrmao(123);
            Assert.IsTrue(n == 321);
        }
    }
}