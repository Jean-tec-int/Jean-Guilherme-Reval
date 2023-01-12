using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jean_Guilherme_Reval.Cadastros
{
    class clsOperations
    {

        //Nosso modelo de dados
        public class Clientes_Schema
        {
            public int id { get; set; }
            public string nome { get; set; }
            public string telefone { get; set; }
            public string rg { get; set; }
            public string cidade { get; set; }
            public string cpf_cnpj { get; set; }
            public string email { get; set; }
            public string bairro { get; set; }
            public string rua { get; set; }
            public string numero { get; set; }
            public string bloqueado { get; set; }
        }

        //CLIENTES - INCLUIR REGISTRO

        public static Boolean Adicionar_Cliente(string nome, string telefone,
            string rg, string cidade, string cpf_cnpj, string email, string bairro, string rua, string numero, string bloqueado)
        {
            Boolean return_function = false;

           
            try
            {
                //Aqui vamos fazer uma chamada como se fosse uma api ok?
                Clientes_Schema clientes_Schema = Api.clientesController.Inserir(nome,telefone,rg,
                    cidade,cpf_cnpj,email,bairro,rua,numero,bloqueado);

                if (clientes_Schema.id != 0)
                {
                    return_function = true;
                }
            }
            catch (Exception)
            {

                return return_function;
                throw;
            }
            

            return return_function;
        }

        //CLIENTES - ATUALIZAR REGISTRO
        public static Boolean Atualizar_Cliente(int id,string nome, string telefone,
            string rg, string cidade, string cpf_cnpj, string email, string bairro, string rua, string numero, string bloqueado)
        {
            Boolean return_function = false;

            try
            {
                //Aqui vamos fazer uma chamada como se fosse uma api ok?
                if (Api.clientesController.Upadate(id, nome, telefone, rg,
                    cidade, cpf_cnpj, email, bairro, rua, numero, bloqueado))
                {
                    return_function = true;
                }

            }
            catch (Exception)
            {

                return return_function = false ;
                throw;
            }


            return return_function;
        }

        //CLIENTES - EXCLUIR REGISTRO
        public static Boolean Excluir_Cliente(int id)
        {
            Boolean return_function = false;

            
            try
            {
                //Aqui vamos fazer uma chamada como se fosse uma api ok?
                if (Api.clientesController.Delete(id))
                {
                    return_function = true;
                }

            }
            catch (Exception)
            {
                return return_function;
                throw;
            }
            

            return return_function;
        }


        //CLIENTES - PESQUISAR POR NOMES RETORNANDO EM LISTA
         public static DataTable Pesquisar_Cliente_Nome(string key)
         {  
            DataTable table_cliente = new DataTable();
            try
            {
                table_cliente = Api.clientesController.searchClientesName(key);
            }
            catch (Exception)
            {

                throw;
            }


            return table_cliente;
 

         }

       
        //CLIENTES - PEGAR TODOS OS CLIENTES
        
        public static DataTable Lista_de_clientes()
        {
            DataTable table_cliente = new DataTable();
            try
            {
                table_cliente = Api.clientesController.GetAllClientes();
            }
            catch (Exception)
            {

                throw;
            }
           

            return table_cliente;

        }
    }
}
