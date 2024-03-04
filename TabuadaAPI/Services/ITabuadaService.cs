namespace TabuadaAPI.Services
{
	public interface ITabuadaService
	{
		Task<List<string>> ProcessarTabuadasAsync(List<int> numeros);
	}
}
