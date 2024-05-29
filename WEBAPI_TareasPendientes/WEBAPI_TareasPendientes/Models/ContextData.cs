using Microsoft.EntityFrameworkCore;

namespace WEBAPI_TareasPendientes.Models
{
    public class ContextData:DbContext
    {
        public ContextData(DbContextOptions<ContextData> options):base(options)
        {

        }
        public DbSet<TareasPendientes> TareasPendientes { get; set; } = null;
    }
}
