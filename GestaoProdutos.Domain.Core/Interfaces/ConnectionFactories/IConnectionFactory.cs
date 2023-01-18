using System.Data;
using System.Threading.Tasks;

namespace GestaoProdutos.Domain.Core.Interfaces.ConnectionFactories
{
	public interface IConnectionFactory
	{
		Task<IDbConnection> AbrirConexaoAsync(string banco, bool webConfig = false, string dbAddress = null);
		IDbConnection AbrirConexao(string banco, bool webConfig = false, string dbAddress = null);
	}
}
