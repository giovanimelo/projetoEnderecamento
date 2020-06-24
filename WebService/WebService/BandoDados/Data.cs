using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace WebService
{
    public class Data
    {
        private string STR_Conexao = "";
        private SqlConnection SQL_Con = new SqlConnection();
        private SqlCommand SQL_Com;
        public StringBuilder STB_SQL = new StringBuilder();

        private MySqlConnection MySql_Con = new MySqlConnection();

        private string STR_Servidor;
        private Int32 INT_Porta;
        private string STR_Instancia;
        private string STR_DataBase;
        private string STR_Usuario;
        private string STR_Senha;
        private string STR_Tipo;

        #region Campos
        /// <summary>
        /// Endereço do servidor do banco de dados 
        /// </summary>
        public string Servidor
        {
            get { return STR_Servidor; }
            set { STR_Servidor = value; }
        }

        /// <summary>
        /// Porta comunicação com o servidor do banco de dados
        /// </summary>
        public Int32 Porta
        {
            get { return INT_Porta; }
            set { INT_Porta = value; }
        }

        /// <summary>
        /// Nome da instancia do servidor SQL
        /// </summary>
        public string Instancia
        {
            get { return STR_Instancia; }
            set { STR_Instancia = value; }
        }

        /// <summary>
        /// Nome do banco de dados
        /// </summary>
        public string DataBase
        {
            get { return STR_DataBase; }
            set { STR_DataBase = value; }
        }

        /// <summary>
        /// Usuário de acesso ao servidor
        /// </summary>
        public string Usuario
        {
            get { return STR_Usuario; }
            set { STR_Usuario = value; }
        }

        /// <summary>
        /// Senha de acesso ao servidor
        /// </summary>
        public string Senha
        {
            get { return STR_Senha; }
            set { STR_Senha = value; }
        }

        /// <summary>
        /// Tipo do banco de dados
        /// MySQL - SQL
        /// </summary>
        public string Tipo
        {
            get { return STR_Tipo; }
            set { STR_Tipo = value; }
        }
        #endregion Campos

        /// <summary>
        /// Inicia uma conexão com o banco de dados
        /// </summary>
        private void ConectaBanco()
        {
            try
            {
                if (STR_Tipo.ToUpper() == "SQL")
                {
                    if (STR_Conexao == "")
                    {
                        STR_Conexao = "Data Source=" + STR_Servidor;
                        if (INT_Porta != 0) STR_Conexao += ", " + INT_Porta.ToString();
                        if (STR_Instancia != null) STR_Conexao += "\\" + STR_Instancia;
                        STR_Conexao += ";Initial Catalog=" + STR_DataBase;
                        STR_Conexao += ";User Id=" + STR_Usuario;
                        STR_Conexao += ";Password=" + STR_Senha;
                    }
                    if (SQL_Con.State == ConnectionState.Closed)
                    {
                        SQL_Con = new SqlConnection();
                        SQL_Con.ConnectionString = STR_Conexao;
                        SQL_Con.Open();
                    }
                }
                else
                {
                    if (STR_Conexao == "")
                    {
                        STR_Conexao = "server=" + STR_Servidor + ";";
                        STR_Conexao += "database=" + STR_DataBase + ";";
                        STR_Conexao += "UID=" + STR_Usuario + ";";
                        STR_Conexao += "password=" + STR_Senha + ";";
                    }
                    if (MySql_Con.State == ConnectionState.Closed)
                    {
                        MySql_Con = new MySqlConnection();
                        MySql_Con.ConnectionString = STR_Conexao;
                        MySql_Con.Open();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Encerra a conexão com o banco de dados
        /// </summary>
        private void DesconectaBanco()
        {
            try
            {
                if (SQL_Con.State != ConnectionState.Closed) SQL_Con.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Executa uma consulta no banco de dados
        /// </summary>
        /// <param name="STR_SQL">Instrução para a consulta - quando não informado, utiliza a variavel STB_SQL</param>
        /// <param name="DTA_Data">DataTable para retorno dos dados - quando não informado, retorna na variavel DTA_Dados</param>
        public DataTable FU_Query(string STR_SQL = "")
        {
            DataTable LDTT_Return = null;
            try
            {
                if (STR_Tipo.ToUpper() == "SQL")
                {
                    if (SQL_Con.State == ConnectionState.Closed)
                        ConectaBanco();
                    if (STR_SQL == "")
                        STR_SQL = STB_SQL.ToString();
                    SQL_Com = new SqlCommand(STR_SQL, SQL_Con);
                    SqlDataReader SQL_Dad = SQL_Com.ExecuteReader();
                    LDTT_Return = new DataTable();
                    LDTT_Return.Load(SQL_Dad);
                }
                else
                {
                    if (MySql_Con.State == ConnectionState.Closed)
                        ConectaBanco();
                    if (STR_SQL == "")
                        STR_SQL = STB_SQL.ToString();

                    MySqlDataAdapter MySql_Ada = new MySqlDataAdapter();
                    MySql_Ada.SelectCommand = new MySqlCommand(STR_SQL, MySql_Con);
                    DataSet dSet = new DataSet();
                    MySql_Ada.Fill(dSet);
                    LDTT_Return = dSet.Tables[0];
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return LDTT_Return;
        }

        /// <summary>
        /// Executa um alteração no banco de dados
        /// </summary>
        /// <param name="STR_SQL">Instrução a ser executado no banco - quando não informado, utiliza a variavel STB_SQL</param>
        public void CSQL(string STR_SQL = "")
        {
            try
            {
                if (STR_Tipo.ToUpper() == "SQL")
                {
                    if (SQL_Con.State == ConnectionState.Closed)
                        ConectaBanco();
                    if (STR_SQL == "")
                        STR_SQL = STB_SQL.ToString();

                    SQL_Com = new SqlCommand(STR_SQL, SQL_Con);
                    SQL_Com.ExecuteNonQuery();
                }
                else
                {
                    if (MySql_Con.State == ConnectionState.Closed)
                        ConectaBanco();
                    if (STR_SQL == "")
                        STR_SQL = STB_SQL.ToString();

                    MySqlCommand MySQL_Com = new MySqlCommand(STR_SQL, MySql_Con);
                    MySQL_Com.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void FU_Where(ref StringBuilder STB_SQL, string STR_Field, string STR_Operator, object OBJ_Value, string STR_Type)
        {
            if (Convert.ToString(OBJ_Value) != "")
            {
                string STR_Value = "";
                if (STR_Type.ToUpper() == "DATETIME") STR_Value = Convert.ToDateTime(OBJ_Value).ToString("yyyy/MM/dd HH:mm");
                else if (STR_Type.ToUpper() == "STRING") STR_Value = OBJ_Value.ToString();
                else if (STR_Type.ToUpper() == "NUMERIC") STR_Value = OBJ_Value.ToString();

                if (STB_SQL.ToString().Contains("Where")) STB_SQL.AppendLine("And");
                else STB_SQL.AppendLine("Where");
                STB_SQL.Append(" " + STR_Field);

                if (STR_Operator == "like") STB_SQL.Append(" " + STR_Operator + " '%" + STR_Value + "%'");
                else STB_SQL.Append(" " + STR_Operator + " '" + OBJ_Value.ToString() + "'");
            }
        }
    }
}