using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Newtonsoft.Json;
using RestSharp;

namespace APIs_Provincias
{
    class Program
    {
        static void Main(string[] args)
        {
			ProvinciasMMN provsMMN = getProvinciasMMN();
			ProvinciasMeLi provsMeLi = getProvinciasMeLi();
			
			imprimirProvinciasMMN(provsMMN);
			imprimirProvinciasMeLi(provsMeLi);
		}
		private static void imprimirProvinciasMMN(ProvinciasMMN provs)
		{
			Console.WriteLine("Provincias segun Ministerio de Modernizacion de la Nacion:");
			foreach (Provincia prov in provs.provincias)
			{
				Console.WriteLine("    " + "Nombre: " + prov.nombre + "(id: " +prov.id + "), centroide: (" + prov.centroide.lat + ", " + prov.centroide.lon+")");
			}
		}

		private static void imprimirProvinciasMeLi(ProvinciasMeLi provs)
		{
			Console.WriteLine("Provincias segun Mercado Libre:");
			foreach (State prov in provs.states)
			{
				Console.WriteLine("    " + "Nombre: " + prov.name + "(id: " + prov.id + ")");
			}
		}

		private static ProvinciasMMN getProvinciasMMN()
		{
			var client = new RestClient("https://apis.datos.gob.ar/georef/api/");
			var request = new RestRequest("provincias");
			request.RequestFormat = DataFormat.Json;
			var response = client.Get(request).Content;
			return JsonConvert.DeserializeObject<ProvinciasMMN>(response);
		}


		private static ProvinciasMeLi getProvinciasMeLi()
		{
			var client = new RestClient("https://api.mercadolibre.com/");
			var request = new RestRequest("classified_locations/countries/AR");
			request.RequestFormat = DataFormat.Json;
			var response = client.Get(request).Content;
			return JsonConvert.DeserializeObject<ProvinciasMeLi>(response);
		}
	}
}

