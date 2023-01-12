using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jean_Guilherme_Reval.Api
{
    class clientesController
    {

        //Aqui vamos cria as rotas como se fosse api (post, update, delete, get)

        public static Cadastros.clsOperations.Clientes_Schema Clientes_Schema;
        public static string MyConnection = "datasource=localhost;port=3306;username=root;password=1234";
        public static MySqlConnection MyConn = new MySqlConnection(MyConnection);

       
        
        //[Post] Inserir novo registro
        public static Cadastros.clsOperations.Clientes_Schema Inserir(string nome, string telefone, string rg,
            string cidade, string cpf_cnpj, string email, string bairro, string rua, string numero, string bloqueado )
        {
            var result = new Cadastros.clsOperations.Clientes_Schema();

            try
            {

                string Query = "insert into db_reval.tb_clientes(nome,telefone,rg,cidade,cpf_cnpj,email,bairro,rua,numero,bloqueado) " +
                "values('"+nome+"','"+telefone+"','"+rg+ "','" + cidade + "','" + cpf_cnpj + "','" + email + "','" + bairro + "','" + rua + "'" +
                ",'" + numero + "','" + bloqueado + "');";
                             
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader2;
                MyConn.Open();
                MyReader2 = MyCommand2.ExecuteReader();

                //Vamos pegar o id do ultimo insert
                result.id = (int)MyCommand2.LastInsertedId;
                
            }
            catch (Exception erro)
            {
                throw;
            }


            MyConn.Close();
            return result;
        }


        //[Get] pegar todos os registro
        public static DataTable GetAllClientes()
        {
            var result = new DataTable();

            try
            {
          
                MySqlCommand bdcomando = new MySqlCommand("SELECT * FROM db_reval.tb_clientes;", MyConn);
                bdcomando.CommandType = CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(bdcomando);
                DataTable clientes = new DataTable();
                da.Fill(clientes);
                result = clientes;

            }
            catch (Exception)
            {
                throw;
            }


            MyConn.Close();
            return result;
        }


        //[Post] Atualizar registro
        public static Boolean Upadate(int id, string nome, string telefone, string rg,
            string cidade, string cpf_cnpj, string email, string bairro, string rua, string numero, string bloqueado )
        {
            bool result = false;

            try
            {

                string Query = "update db_reval.tb_clientes set nome='" + nome + "',telefone='" + telefone + "',rg='" + rg + "'," +
                     "cidade='" + cidade + "',cpf_cnpj='" + cpf_cnpj + "',email='" + email + "',rua='" + rua + "',numero='" + numero + "',bloqueado='" + bloqueado + "'" +
                     " where id='" + id + "';";

                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader2;
                MyConn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                result = true;

            }
            catch (Exception erro)
            {
                throw;
            }


            MyConn.Close();
            return result;

        }


        //[Post] Excluir registro
        public static Boolean Delete(int id)
        {
            bool result = false;

            try
            {

                string Query = "DELETE FROM db_reval.tb_clientes WHERE id='" + id + "';";


                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn);
                MySqlDataReader MyReader2;
                MyConn.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                result = true;

            }
            catch (Exception erro)
            {
                throw;
            }


            MyConn.Close();
            return result;

        }


        //[Post] consulta por nome like
        public static DataTable searchClientesName(string key)
        {
            var result = new DataTable();

            try
            {

                MySqlCommand bdcomando = new MySqlCommand("SELECT * FROM db_reval.tb_clientes where nome like '%"+key+"%';", MyConn);
                bdcomando.CommandType = CommandType.Text;

                MySqlDataAdapter da = new MySqlDataAdapter(bdcomando);
                DataTable clientes = new DataTable();
                da.Fill(clientes);
                result = clientes;

            }
            catch (Exception)
            {
                throw;
            }


            MyConn.Close();
            return result;
        }
    }
}
