using System.Data;

namespace API_PetShop.Contexts
{
    public class SqlConnection
    {
        public string ConnectionString { get; internal set; }
        public ConnectionState State { get; internal set; }
    }
}