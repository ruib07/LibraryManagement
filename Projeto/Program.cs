using Projeto.Consultar;
using Projeto.Livros;
using Projeto.Apresentacao;
using Projeto.Utilizadores;
using Projeto.Listas;

#region Data

UtilizadoresData ud = new UtilizadoresData();
LivrosData ld = new LivrosData();

#endregion

#region Lists

ListasLivrosUsers l = new ListasLivrosUsers();

#endregion

#region Management

GestaoUtilizadores gu = new GestaoUtilizadores(l);
GestaoLivros gl = new GestaoLivros(l);

#endregion

#region Buy/Sell or Consult

CompraVendaLivros cvl = new CompraVendaLivros(l);
Consultas c = new Consultas(l);

#endregion

#region UI

Interface i = new Interface(ud, c, gu, gl, cvl);
i.MostrarOpcoes();

#endregion

Console.ReadKey();