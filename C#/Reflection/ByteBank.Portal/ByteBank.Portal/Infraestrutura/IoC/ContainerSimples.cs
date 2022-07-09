using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura.IoC
{
    public class ContainerSimples : IContainer
    {
        private readonly Dictionary<Type, Type> mapaDeTipos = new Dictionary<Type, Type>();
        public object Recuperar(Type tipoOrigem)
        {
            var tipoOrigemFoiMapeado = this.mapaDeTipos.ContainsKey(tipoOrigem);
            if (tipoOrigemFoiMapeado)
            {
                var tipoDestino = this.mapaDeTipos[tipoOrigem];
                return Recuperar(tipoDestino);
            }

            var construtores = tipoOrigem.GetConstructors();
            var construtorSemParametros = 
                construtores.FirstOrDefault(construtor => construtor.GetParameters().Any() == false);

            if (construtorSemParametros != null)
            {
                var instanciaSemParametros = construtorSemParametros.Invoke(Array.Empty<object>());
                return instanciaSemParametros;
            }

            var construtor = construtores[0];
            var parametrosDoConstrutor = construtor.GetParameters();
            var valoresDeParametros = new object[parametrosDoConstrutor.Count()];

            for (int i = 0; i < parametrosDoConstrutor.Count(); i++)
            {
                var parametro = parametrosDoConstrutor[i];
                var tipoParametro = parametro.ParameterType;

                valoresDeParametros[i] = Recuperar(tipoParametro);
            }

            var instanciaComParametros = construtor.Invoke(valoresDeParametros);
            return instanciaComParametros;
        }

        public void Registrar(Type tipoOrigem, Type tipoDestino)
        {
            if (this.mapaDeTipos.ContainsKey(tipoOrigem))
            {
                throw new InvalidOperationException("Tipo já mapeado!");
            }

            this.VerificarHierarquiaOuLancarExcecao(tipoOrigem, tipoDestino);
            this.mapaDeTipos.Add(tipoOrigem, tipoDestino);
        }

        public void Registrar<TOrigem, TDestino>() where TDestino : TOrigem
        {
            if (this.mapaDeTipos.ContainsKey(typeof(TOrigem)))
            {
                throw new InvalidOperationException("Tipo já mapeado!");
            }

            this.mapaDeTipos.Add(typeof(TOrigem), typeof(TDestino));

        }

        private void VerificarHierarquiaOuLancarExcecao(Type tipoOrigem, Type tipoDestino)
        {
            if (tipoOrigem.IsInterface)
            {
                var tipoDestinoImplementaInterface = 
                    tipoDestino
                        .GetInterfaces()
                        .Any(tipoInterface => tipoInterface == tipoOrigem);

                if (!tipoDestinoImplementaInterface)
                {
                    throw new InvalidOperationException("O tipo destino não implementa a interface!");
                }

            }
            else
            {
                var tipoDestinoHerdaTipoOrigem = tipoDestino.IsSubclassOf(tipoOrigem);
                if (!tipoDestinoHerdaTipoOrigem)
                {
                    throw new InvalidOperationException("O tipo destino não herda o tipo de origem!");
                }
            }
        }
    }
}
