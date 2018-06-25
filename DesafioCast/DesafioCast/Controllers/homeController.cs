using DesafioCast.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesafioCast.Controllers
{
    public class homeController : Controller
    {
        // GET: home


        public ActionResult Index()
        {

            try

            {


                ViewBag.ultimodisponivel = GetLastAnimal();

                #region ùltima adocao;

                adocao ultimo = GetLastAdocao();

                if (ultimo != null)
                {
                    ViewBag.ultimaadocao = "Nosso último animal adotado foi: " + ultimo.animal.nome + ", adotado por: " + ultimo.pessoa.nome + " parabéns";
                }
                else
                {
                    ViewBag.ultimaadocao = "Sem nenhum animal adotado no momento.";
                }


                #endregion

                #region Animal com maior tempo se adoção.

                animal animal = Getanimallongtime();

                if (animal != null)
                {
                    ViewBag.longtime = "Por favor adotem " + animal.nome + " ele está conosco desde: " + animal.dataEntrada;
                }
                else
                {
                    ViewBag.longtime = "Todos os animais forão adotados. ";
                }

                #endregion
               

            }
            catch {
                ViewBag.ultimaadocao = "Sem nenhum animal adotado no momento.";
                ViewBag.longtime = "Todos os animais forão adotados. ";
                ViewBag.ultimodisponivel = null;
            }
           

            return View();


        }

        /// <summary>
        /// retorna Nome do último animal adicionado
        /// </summary>
        /// <returns>string</returns>
        public string GetLastAnimal()
        {
            string animal = null;

            try
            {
                //Instancia classe de acesso a dados.
                DbDesafioCastContext obj = new DbDesafioCastContext();

                List<animal> list = obj.animals.ToList();

                animal = list[1].nome;

                //Usando linq para pegar o último valor da tabela.
                var resultado = (from p in list select p).Last();

                //retornado apenas o nome do animal
                animal = resultado.nome;

                return animal;
            }
            catch
            {
                return animal;
            }
        }


        /// <summary>
        /// retorna  objeto do tipo adocao, com o último registro do banco.
        /// </summary>
        /// <returns>adocao</returns>
        public adocao GetLastAdocao()
        {
            adocao adocao = null;

            try
            {
                //Instancia classe de acesso a dados.
                DbDesafioCastContext obj = new DbDesafioCastContext();

                List<adocao> list = obj.adocaos.ToList();

                adocao = new adocao();

                //forma manual para pegar o último registro da tabela.
                adocao = list[(list.Count() - 1)];

                if (list.Count() == 0)
                {
                    adocao = null;
                }

                return adocao;
            }
            catch
            {
                return adocao;
            }
        }



        /// <summary>
        /// retorna  objeto do tipo animal com o mair tempo se adoção.
        /// </summary>
        /// <returns>animal</returns>
        public animal Getanimallongtime()
        {
            animal animal = null;

            try
            {
                //Instancia classe de acesso a dados.
                DbDesafioCastContext obj = new DbDesafioCastContext();

                List<animal> list = obj.animals.ToList();

                //ordena a lista de forma decrecente pelo id de registro.
                var listaOrdenada = list.OrderBy(e => e.Id);

                //procura pelo primeiro animal que deu entrada no banco.
                foreach (animal lista in listaOrdenada)
                {
                    if (Getadotado(lista.Id) == true)
                    {
                        animal = lista;
                        break;
                    }
                }

                return animal;
            }
            catch
            {
                return animal;
            }
        }


        /// <summary>
        /// Verifica se um animal foi adotado.
        /// </summary>
        /// <param name="Idanimal"></param>
        /// <returns>true or false</returns>
        public bool Getadotado(int Idanimal)
        {
            bool result = true;

            try
            {

                //Instancia classe de acesso a dados.
                DbDesafioCastContext obj = new DbDesafioCastContext();

                //seleciona o animal com o id informado.
                var animal = obj.adocaos.Where(x => x.animalId == Idanimal);

                if (animal.Count() > 0)
                {
                    //O animal informado já foi adotado.
                    result = false;
                }


                return result;
            }
            catch
            {
                return result;
            }
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            ViewBag.conteudo = "ola mundo";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}