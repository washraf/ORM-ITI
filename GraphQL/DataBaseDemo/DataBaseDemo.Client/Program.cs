using GraphQL;
using GraphQL.Client;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using GraphQL.Client.Serializer.Newtonsoft;
using System.Text.Json;

namespace DataBaseDemo.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            method().Wait();
        }

        public async static Task method()
        {
            var request = new GraphQLRequest()
            { Query = @"{
		                items {
			                id,title
		                }
	                }" };
            var graphQLClient = 
                new GraphQLHttpClient
                ("https://localhost:44382/graphql", new NewtonsoftJsonSerializer());
            var graphQLResponse = await graphQLClient.SendQueryAsync<ItemsResponse>(request);
            var response = graphQLResponse.Data;
            
            foreach (var item in response.Items)
            {
                Console.WriteLine($"Item {item.Id}:{item.Title}");
            }
        }

    }

    public class ItemsResponse
    {
        public List<SimpleItem> Items = new List<SimpleItem>();
    }

    public class SimpleItem
    {
        public int Id { set; get; }
        public string Title { set; get; }
    }
    
}
