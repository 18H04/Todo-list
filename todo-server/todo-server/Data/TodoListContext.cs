
namespace todo_server.Data
{
    using Microsoft.EntityFrameworkCore;
    using todo_server.Model;
    

    public class TodoListContext : DbContext
    {
        public TodoListContext(DbContextOptions<TodoListContext> options) : base(options)
        {
        }

        // DbSet cho mỗi model
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Các cấu hình khác có thể được thêm ở đây
        }
    }

}
