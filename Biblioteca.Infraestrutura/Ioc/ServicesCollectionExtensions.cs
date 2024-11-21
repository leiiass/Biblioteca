using Biblioteca.Dominio.Interfaces;
using Biblioteca.Infraestrutura.Repositorios;
using Biblioteca.Servicos;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Raven.Client.Documents;

namespace Biblioteca.Infraestrutura.Ioc
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AdicionarRavenDB(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddSingleton<IDocumentStore>(x =>
            {
                var store = new DocumentStore
                {
                    Urls = new[] { "http://127.0.0.1:8080/" },
                    Conventions =
                    {
                        IdentityPartsSeparator = '-',
                        SaveEnumsAsIntegers = true
                    },
                    Database = "Biblioteca"
                };

                store.Initialize();

                return store;
            });

            return servicesCollection;
        }

        public static IServiceCollection AdicionarRepositorios(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddSingleton<ILeitorRepositorio, LeitorRepositorio>();
            return servicesCollection;
        }

        public static IServiceCollection AdicionarServicos(this IServiceCollection servicesCollection)
        {
            servicesCollection.TryAddScoped<ServicoLeitor>();
            return servicesCollection;
        }
    }
}
