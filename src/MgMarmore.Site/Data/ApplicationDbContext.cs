using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MgMarmore.Business.Models;
using MgMarmore.Site.ViewModels;
using MgMarmore.Site.Areas.Administracao.ViewModels;

namespace MgMarmore.Site.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }             
        public DbSet<MgMarmore.Site.Areas.Administracao.ViewModels.CategoriaMaterialViewModel> CategoriaMaterialViewModel { get; set; }
        public DbSet<MgMarmore.Site.Areas.Administracao.ViewModels.CategoriaProdutoViewModel> CategoriaProdutoViewModel { get; set; }
        public DbSet<MgMarmore.Site.Areas.Administracao.ViewModels.ProdutoViewModel> ProdutoViewModel { get; set; }
       
       
    }
}
