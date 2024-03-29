﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _5413__ASP.NET.BLL
{
    public class Artigo
    {
        public int Id;
        public string Titulo;
        public string Subtitulo;
        public string Conteudo;
        public DateTime DataPublicacao;
        public bool Acessibilidade;
        public int CategoriaId; // Chave estrangeira para Categoria
        public int UtilizadorId; // Chave estrangeira para Utilizador

        public Artigo(string titulo, string subtitulo, string conteudo, DateTime DataPublicacao, bool acessibilidade, int categoriaID, int utilizadorID)
        {
            this.Titulo = titulo;
            this.Subtitulo = subtitulo;
            this.Conteudo = conteudo;
            this.DataPublicacao = DataPublicacao;
            this.Acessibilidade = acessibilidade;
            this.CategoriaId = categoriaID;
            this.UtilizadorId = utilizadorID;
        }

        public int getId()
        {
            return this.Id;
        }
        public string getTitulo()
        {
            return this.Titulo;
        }
        public string getSubtitulo()
        {
            return this.Subtitulo;
        }
        public string getConteudo()
        {
            return this.Conteudo;
        }
        public DateTime getDataPublicacao()
        {
            return this.DataPublicacao;
        }
        public bool getAcessibilidade()
        {
            return this.Acessibilidade;
        }
        public int getCategoriaId()
        {
            return this.CategoriaId;
        }
        public int getUtilizadorId()
        {
            return this.UtilizadorId;
        }
    }
}