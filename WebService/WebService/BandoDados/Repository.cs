using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebService.BandoDados;
using WebService.Models;

namespace WebService
{
    public class Repository : LegadoBase, IRepository
    {
        string database = "dbprojeto";
        public Repository() => db.DataBase = database;
        private Data NovaData()
        {
            this.DATA();
            db.DataBase = database;
            return db;
        }
        protected static string GetStringConexao()
        {
            return ConfigurationManager.ConnectionStrings["dbprojeto"].ConnectionString;
        }

        public string GetUsuario(string email, string senha)
        {

            List<Usuario> GetDadosUsuario = new List<Usuario>();
            var _GetDadosUsuario = new Usuario();
            {
                Usuario AddUsuario = new Usuario();
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT *from usuario where no_email = '" + email + "' and no_senha = '" + senha + "'", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                if (dr.HasRows == true)
                                {
                                    return "Logado com Sucesso!";
                                }
                                else
                                {
                                    return "Usuario não encontrado";
                                }
                            }
                            else
                            {
                                return "Ocorreu um erro, tente novamente!";
                            }

                        }
                    }
                }
            }

        }

        public Usuario GetEndereco()
        {

            List<Usuario> GetDadosUsuario = new List<Usuario>();
            var _GetDadosUsuario = new Usuario();
            {
                Usuario AddUsuario = new Usuario();
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT *from usuario", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    _GetDadosUsuario.id_usuario = Convert.ToInt32(dr["id_usuario"].ToString());
                                    _GetDadosUsuario.no_nome = dr["no_nome"].ToString();
                                    _GetDadosUsuario.no_email = dr["no_email"].ToString();
                                    _GetDadosUsuario.no_sexo = dr["no_sexo"].ToString();
                                    _GetDadosUsuario.num_telefone = dr["num_telefone"].ToString();
                                    GetDadosUsuario.Add(_GetDadosUsuario);
                                }
                            }
                            return GetDadosUsuario[0];
                        }

                    }
                }
            }

        }

        public List<Validade_Lote> GetValidadeLote()
        {
            //Status 0 = VENCIDO;
            //Status 1 = PERTO PRAZO VALIDADE;
            //Status 2 = DENTRO DO PRAZO DE VALIDADE;

            List<Validade_Lote> validade_lote = new List<Validade_Lote>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT  vencimento  as Vencimento, numero as Led" +
                        " FROM Enderecamento INNER JOIN Produto ON Enderecamento.id_produto" +
                        " = Produto.id_produto INNER JOIN Endereco ON Enderecamento.id_endereco" +
                        " = Endereco.id_endereco INNER JOIN Led ON Endereco.id_led = Led.id_led", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Validade_Lote _GetValidadeLote = new Validade_Lote();
                                    // Data de vencimento cadastrada
                                    var data = Convert.ToDateTime(dr["Vencimento"]);
                                    _GetValidadeLote.led = Convert.ToInt32(dr["led"].ToString());
                                    // Data atual
                                    int result = DateTime.Compare(data, DateTime.Now);
                                    if (result <= 0)
                                    {
                                        _GetValidadeLote.statusLed = 0;
                                    }
                                    else if (result > 0 && result < 30)
                                    {
                                        _GetValidadeLote.statusLed = 1;
                                    }
                                    else if (result > 30)
                                    {
                                        _GetValidadeLote.statusLed = 2;
                                    }


                                    validade_lote.Add(_GetValidadeLote);
                                }
                            }
                            return validade_lote;
                        }

                    }
                }
            }

        }
        //RETORNA PRODUTOS QUE AINDA NAO FOI ENDEREÇADO

        public List<Produto> GetComboProdutos()
        {
            List<Produto> produto = new List<Produto>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "DECLARE @qtdRegistros int; " +
                        "SELECT @qtdRegistros = COUNT(*) FROM ENDERECAMENTO " +
                        "SELECT  E.id_produto,E.descricao,E.quantidade,E.lote,E.vencimento FROM Produto as E  " +
                        "INNER JOIN Enderecamento AS A ON E.id_produto != A.id_produto " +
                        "GROUP BY E.id_produto,E.descricao,E.quantidade,E.lote,E.vencimento " +
                        "having count(*) > ( @qtdRegistros  - 1) ", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Produto _produto = new Produto();
                                    // Data de vencimento cadastrada
                                    var data = Convert.ToDateTime(dr["Vencimento"]);
                                    _produto.id_produto = Convert.ToInt32(dr["id_produto"].ToString());
                                    _produto.descricao = dr["descricao"].ToString();
                                    _produto.quantidade = Convert.ToInt32(dr["quantidade"].ToString());
                                    _produto.lote = dr["lote"].ToString();
                                    _produto.vencimento = data;
                                    produto.Add(_produto);
                                }
                            }
                            return produto;
                        }
                    }
                }
            }
        }

        public List<Endereco> GetComboEnderecos()
        {
            List<Endereco> endereco = new List<Endereco>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "DECLARE @qtdRegistros int; " +
                        "SELECT @qtdRegistros = COUNT(*) FROM ENDERECAMENTO " +
                        "SELECT E.id_endereco,e.descricao, E.id_rua,E.id_coluna,E.id_nivel,E.id_led " +
                        "FROM Endereco as E INNER JOIN Enderecamento AS A ON E.id_endereco != A.id_endereco " +
                        "GROUP BY E.id_endereco,E.descricao, E.id_rua,E.id_coluna,E.id_nivel,E.id_led " +
                        "having count(*) > ( @qtdRegistros  - 1)", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Endereco _endereco = new Endereco();
                                    _endereco.id_endereco = Convert.ToInt32(dr["id_endereco"].ToString());
                                    _endereco.descricao = dr["descricao"].ToString();
                                    _endereco.id_rua = Convert.ToInt32(dr["id_rua"].ToString());
                                    _endereco.id_coluna = Convert.ToInt32(dr["id_coluna"].ToString());
                                    _endereco.id_nivel = Convert.ToInt32(dr["id_nivel"].ToString());
                                    _endereco.id_led = Convert.ToInt32(dr["id_led"].ToString());
                                    endereco.Add(_endereco);
                                }
                            }
                            return endereco;
                        }
                    }
                }
            }
        }

        public List<ProdutoQtde> getProdutosQtde()
        {
            List<ProdutoQtde> produtoqtde = new List<ProdutoQtde>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "SELECT CO.nome_coluna as coluna,RU.nome_rua as rua,SUM(P.QUANTIDADE) AS total " +
                        "FROM Enderecamento AS EDC " +
                        "JOIN Endereco AS EN ON EDC.id_endereco = EN.id_endereco " +
                        "JOIN Coluna as CO ON CO.id_coluna = EN.id_coluna " +
                        "JOIN Produto AS P ON P.id_produto = EDC.id_produto " +
                        "join Rua AS RU ON EN.id_rua = RU.id_rua " +
                        "group by CO.nome_coluna, RU.nome_rua", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    ProdutoQtde _produtoQtde = new ProdutoQtde();
                                    _produtoQtde.total = Convert.ToInt32(dr["total"].ToString());
                                    _produtoQtde.rua = dr["rua"].ToString();
                                    _produtoQtde.coluna = dr["coluna"].ToString();

                                    produtoqtde.Add(_produtoQtde);
                                }
                            }
                            return produtoqtde;
                        }
                    }
                }
            }
        }

        public List<EnderecamentoAPI> getEnderecamento()
        {
            List<EnderecamentoAPI> list = new List<EnderecamentoAPI>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        " SELECT En.descricao AS descricao_endereco, C.nome_coluna AS descricao_column, " +
                        "R.nome_rua AS descricao_rua, N.numero_nivel AS descricao_nivel, " +
                        "P.descricao AS descricao_produto, P.quantidade AS quantidade,P.vencimento AS vencimento " +
                        "FROM Enderecamento AS E JOIN Produto AS P ON E.id_produto = P.id_produto  " +
                        "JOIN Endereco AS En ON E.id_endereco = En.id_endereco JOIN Rua AS R ON En.id_rua = R.id_rua  " +
                        "JOIN Coluna AS C ON En.id_coluna = c.id_coluna JOIN Nivel as N ON En.id_nivel = N.id_nivel ", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    //teste
                                    EnderecamentoAPI _enderecamento = new EnderecamentoAPI();
                                    _enderecamento.descricao_endereco = dr["descricao_endereco"].ToString();
                                    _enderecamento.descricao_column = dr["descricao_column"].ToString();
                                    _enderecamento.descricao_rua = dr["descricao_rua"].ToString();
                                    _enderecamento.descricao_nivel = dr["descricao_nivel"].ToString();
                                    _enderecamento.descricao_produto = dr["descricao_produto"].ToString();
                                    _enderecamento.quantidade = dr["quantidade"].ToString();
                                    _enderecamento.vencimento = DateTime.Parse( dr["vencimento"].ToString()).ToString("dd/MM/yyyy");

                                    list.Add(_enderecamento);
                                }
                            }
                            return list;
                        }
                    }
                }
            }
        }

        public dynamic postEnderecamento(string idproduto, string idendereco)
        {
            {
                List<dynamic> list = new List<dynamic>();
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "INSERT INTO Enderecamento(id_produto,id_endereco) " +
                        "VALUES (" + idproduto + "," + idendereco + ")", con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                if (dr.RecordsAffected == 1)
                                {
                                    list.Add("Endereçamento Registrado com Sucesso!");
                                    return list;
                                }
                                else
                                {
                                    list.Add("Ocorreu um erro ao registrar, tente novamente");
                                    return list;
                                }
                            }
                            else
                            {
                                list.Add("Ocorreu um erro, tente novamente!");
                                return list;
                            }

                        }
                    }
                }
            }

        }

        public dynamic deleteEnderecamento(string idenderecamento)
        {
            {
                List<dynamic> list = new List<dynamic>();
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(
                        "DELETE FROM Enderecamento " +
                        "Where id_enderecamento = " + idenderecamento, con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                if (dr.RecordsAffected == 1)
                                {
                                    list.Add("Endereçamento Excluido com Sucesso!");
                                    return list;
                                }
                                else
                                {
                                    list.Add("Endereço inválido!");
                                    return list;
                                }
                            }
                            else
                            {
                                list.Add("Ocorreu um erro, tente novamente!");
                                return list;
                            }

                        }
                    }
                }
            }

        }


        public List<Produto> GetProdutos(string descricao)
        {
            //SELECT* FROM PRODUTO WHERE descricao like '%%'
            List<Produto> list = new List<Produto>();
            {
                using (SqlConnection con = new SqlConnection(GetStringConexao()))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(

                        "DECLARE @qtdRegistros int; "+
                       "SELECT @qtdRegistros = COUNT(*) FROM ENDERECAMENTO " +
                       "SELECT  E.id_produto,E.descricao,E.quantidade,E.lote,E.vencimento FROM Produto as E  " +
                       "INNER JOIN Enderecamento AS A ON E.id_produto != A.id_produto " +
                       "WHERE e.descricao like '%" + descricao + "%' " +
                       "GROUP BY E.id_produto,E.descricao,E.quantidade,E.lote,E.vencimento " +
                       "having count(*) > ( @qtdRegistros  - 1) " , con))
                    {
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Produto _produto = new Produto();
                                    _produto.id_produto = int.Parse(dr["id_produto"].ToString());
                                    _produto.descricao = dr["descricao"].ToString();
                                    _produto.lote = dr["lote"].ToString();
                                    _produto.quantidade = int.Parse( dr["quantidade"].ToString());
                                    _produto.vencimento = DateTime.Parse(dr["vencimento"].ToString());
                                    list.Add(_produto);
                                }
                            }
                            return list;
                        }
                    }
                }
            }
        }
    }
}