using System.Data;
using System.Data.Common;

namespace WebApplication7.Data
{
    public interface IDatabaseContext
    {
        DbConnection CreateConnection();
    }
}
