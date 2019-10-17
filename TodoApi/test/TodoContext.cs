using Microsoft.EntityFrameworkCore;

namespace TodoApi.test
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Todoitemsecond> Todoitemseconds { get; set; }
    }
}