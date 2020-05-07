using DataBaseDemo.Model;
using GraphQL.Client;
using GraphQL.Client.Http;
using GraphQL.Common.Request;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


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
                new GraphQLHttpClient("http://localhost:44382/graphql");
            var graphQLResponse = await graphQLClient.SendQueryAsync(request);
            //Dynamic
            var dynamicitems = graphQLResponse.Data.items;
            //Typed
            var items = graphQLResponse.GetDataFieldAs<List<Item>>("items");
            foreach (var item in items)
            {
                Console.WriteLine(item.Id);
                Console.WriteLine(item.Title);

            }
        }

    }
    
}
