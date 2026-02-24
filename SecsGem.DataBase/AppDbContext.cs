using Microsoft.EntityFrameworkCore;
using SecsGem.DataBase.Abstract;
using SecsGem.DataBase.Entities;
using SecsGem.DataBase.Entities.Command;
using SecsGem.DataBase.Entities.System;
using SecsGem.DataBase.Entities.Variable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecsGem.DataBase
{
    /// <summary>
    /// 默认数据库上下文
    /// </summary>
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<SecsGemSystemEntity> SystemConfigs { get; set; }


        public DbSet<CommandIDEntity> CommnadIDs{ get; set; }
        public DbSet<CEIDEntity> CEIDs { get; set; }
        public DbSet<ReportIDEntity> ReportIDs{ get; set; }
        public DbSet<VIDEntity> VIDs { get; set; }




        public DbSet<IncentiveEntity> IncentiveCommands { get; set; }

        public DbSet<ResponseEntity> ResponseCommands { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
