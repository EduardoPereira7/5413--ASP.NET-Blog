﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class UtilizadorBLL
    {
        public string sqlCommand;

        public bool criarUtilizador(string nome, string email, string password)
        {
            sqlCommand = "Insert into Utilizadores values('" 
                + nome + "','" 
                + email + "','"
                + password + "',"
                + 0 + ","
                + 0 + ")";

            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlCommand);
        }//-------------------------------------------------------------------------------------------------------------

        public Utilizador LoginUtilizador(string email, string password)
        {
            DAL.DAL dal = new DAL.DAL();
            sqlCommand = "SELECT * FROM Utilizadores WHERE Email = '" + email + "' AND Password = '" + password + "'";
            DataSet ds = dal.obterDs(sqlCommand);

            if (ds.Tables[0].Rows.Count > 0)
            {
                // Se houver pelo menos uma linha de resultado, cria um objeto Utilizador com os dados obtidos do banco de dados.
                DataRow row = ds.Tables[0].Rows[0];
                Utilizador user = new Utilizador(
                    Convert.ToInt32(row["Id"]),
                    row["Nome"].ToString(),
                    row["Email"].ToString(),
                    row["Password"].ToString(),
                    Convert.ToBoolean(row["Verificado"]),
                    Convert.ToBoolean(row["Admin"])
                );
                return user;
            }
            return null;
        }//-------------------------------------------------------------------------------------------------------------

        public DataSet obterUtilizadores(bool verificacao)
        {
            if (verificacao)
            {
                sqlCommand = "select * from Utilizadores where Verificado = 1";
            }
            else
            {
                sqlCommand = "select * from Utilizadores where Verificado = 0";
            }
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlCommand);
        }//-------------------------------------------------------------------------------------------------------------

        public bool alterarVerificacao(int userId, bool verificado)
        {
            string sqlcommand = "UPDATE Utilizadores SET Verificado = " + (verificado ? "1" : "0") + " WHERE Id = " + userId;
            DAL.DAL dal = new DAL.DAL();
            return(dal.crud(sqlcommand));
        }//-------------------------------------------------------------------------------------------------------------

        public bool eliminarUtilizador(int userId)
        {
            string sql = "DELETE FROM Utilizadores WHERE Id = " + userId;
            DAL.DAL dal = new DAL.DAL();
            return(dal.crud(sql));
        }//-------------------------------------------------------------------------------------------------------------

        public int verSeEmailJaExiste(string email)
        {
            string sql = "select count(*) FROM Utilizadores WHERE email = '" + email + "'";
            DAL.DAL dal = new DAL.DAL();
            return dal.countRows(sql);
        }//-------------------------------------------------------------------------------------------------------------

        public int verSeAdmin(int userId)
        {
            string sql = "select count(*) FROM Utilizadores WHERE id = " + userId + " AND admin = 1";
            DAL.DAL dal = new DAL.DAL();
            int rows = dal.countRows(sql);
            return rows;
        }//-------------------------------------------------------------------------------------------------------------

        public int contaAdmins()
        {
            string sql = "select count(*) FROM Utilizadores WHERE admin = 1";
            DAL.DAL dal = new DAL.DAL();
            int rows = dal.countRows(sql);
            return rows;
        }//-------------------------------------------------------------------------------------------------------------

        public int alterarAdmin(int userId) 
        {
            int admin = 0;

            if (verSeAdmin(userId) == 0)//Não é admin
                admin = 1;
            if (admin == 0 && contaAdmins() == 1) //unico admin
            return 0;

            string sqlcommand = "UPDATE Utilizadores SET admin = " + admin + " WHERE Id = " + userId;
            DAL.DAL dal = new DAL.DAL();
            dal.crud(sqlcommand);
            return 1;
        }
        public DataSet obterUtilizador(int userID)
        {
            string sqlCommand = "select * from Utilizadores where id = " + userID ;
         
            DAL.DAL dal = new DAL.DAL();
            return dal.obterDs(sqlCommand);
        }//-------------------------------------------------------------------------------------------------------------
        public bool editarUtilizador(int userID, string nome, string email, string password, int verificado , int admin)
        {
            sqlCommand = "update Utilizadores SET nome = '" + nome 
                + "',email = '" + email 
                + "',password = '" + password 
                + "',verificado = " + verificado 
                + ",admin = " + admin 
                + " where id = " + userID + ";";

            DAL.DAL dal = new DAL.DAL();
            return dal.crud(sqlCommand);
        }//-------------------------------------------------------------------------------------------------------------
    }
}