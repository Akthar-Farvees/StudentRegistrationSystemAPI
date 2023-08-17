using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace StudentRegistrationSystemAPI.Data
{
  public class DataContex : DbContext
  {
    public DataContex(DbContextOptions<DataContex> options) : base(options)
    {
    }

    public DbSet<StudentRegistration> RegisteredStudents => Set<StudentRegistration>();
  }
}
