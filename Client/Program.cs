// See https://aka.ms/new-console-template for more information

using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

string token = "";
string urlBase = "https://localhost:7050/api/";

//Obtem o token de autenticação
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    string json = JsonConvert.SerializeObject(new { login = "admin", password = "admin" });

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PostAsync("Auth/login", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        token = mensagem;
        Console.WriteLine($"Token adqurido.\n");
    }
    else
    {
        Console.WriteLine($"Erro ao obter o token: {mensagem}");
    }
}


//GET
/*using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    var resposta = await client.GetAsync("Numero/numero");
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(mensagem);

        Console.WriteLine("///GET///\nLISTA DE NÚMEROS:");

        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o GET: {mensagem}");
    }
}*/

//POST
/*using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    string json = JsonConvert.SerializeObject(new { numero = 10 });

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PostAsync("Numero/numero", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(mensagem);
        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o POST: {mensagem}");
    }
}*/


//PUT
/*using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    string json = JsonConvert.SerializeObject(new { numeroAtual = "10", numeroNovo = "100" });

    var body = new StringContent(json, Encoding.UTF8, "application/json");

    var resposta = await client.PutAsync("Numero/numero", body);
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(mensagem);

        foreach (string numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o PUT: {mensagem}");
    }
}*/


//DELETE
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri(urlBase);

    client.DefaultRequestHeaders.Authorization =
                       new AuthenticationHeaderValue("Bearer", token);

    var resposta = await client.DeleteAsync("Numero/numero?numero=10");
    var mensagem = resposta.Content.ReadAsStringAsync().Result;

    if (resposta.IsSuccessStatusCode)
    {
        List<int> lista = JsonConvert.DeserializeObject<List<int>>(mensagem);

        foreach (int numero in lista)
        {
            Console.WriteLine(numero);
        }
    }
    else
    {
        Console.WriteLine($"Erro ao realizar o DELETE: {mensagem}");
    }
}

Console.WriteLine("Pressione qualquer tecla para encerrar...");
Console.ReadKey();