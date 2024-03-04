namespace TabuadaAPI.Services
{
	public class TabuadaService : ITabuadaService
	{
		public async Task<List<string>> ProcessarTabuadasAsync(List<int> numeros)
		{
			string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TesteTabuada");
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			var tasks = numeros.Select(ProcessarTabuadaAsync);
			await Task.WhenAll(tasks);

			// Criar lista para armazenar as tabuadas
			var tabuadas = new List<string>();

			foreach (var numero in numeros)
			{
				string filePath = Path.Combine(directory, $"tabuada_de_{numero}.txt");
				// Ler o conteúdo do arquivo
				string tabuada = await File.ReadAllTextAsync(filePath);
				// Adicionar a tabuada à lista
				tabuadas.Add(tabuada);
			}

			return tabuadas;
		}

		private async Task ProcessarTabuadaAsync(int numero)
		{
			string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "TesteTabuada", $"tabuada_de_{numero}.txt");
			using (StreamWriter writer = new StreamWriter(filePath))
			{
				for (int i = 1; i <= 10; i++)
				{
					int resultado = numero * i;
					await writer.WriteLineAsync($"{numero} x {i} = {resultado}");
				}
			}
		}
	}
}
