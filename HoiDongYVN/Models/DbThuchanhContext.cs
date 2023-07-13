using HoiDongYVN.Models;
using Microsoft.EntityFrameworkCore;
public partial class DbThuchanhContext : DbContext
{
    public DbThuchanhContext()
    {
    }

    public DbThuchanhContext(DbContextOptions<DbThuchanhContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Post> tblPost { get; set; }


}
