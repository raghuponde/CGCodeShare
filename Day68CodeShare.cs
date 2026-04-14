
create an resouce of azure cosmos db with the name raghucosmosdb 

and then go to Data Explorer section and create a database name with DemoDB and by clicking on same database add container inside this database which is nothing but a table here 

items and partion key as id and manual u select and say OK now for creating container okay 

so here id i had taken as partion key and here id is also primary key of table also 

now in cosmos db only come to settings and in that go to keys and from there copy and paste the follwing things in notepad for reference 


URI (endpoint ) 

https://raghucosmosdb.documents.azure.com:443/

copy now primary key over here 

not pasting as github will give error so paste it in visual studio from cosmos portal

  then copy primary connection string here 

not pasting as github will give error so paste it in visual studio from cosmos portal

so all these is neeed to establish connection with asp.net core mvc code which will talk to cosmos db okay here 



now come to visual studio and open and create asp.net core mvc project now okay ...with name CosmosDB-Demo 

Add required paramters over here in app settings file first 

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "CosmosDb": {
    "Endpoint": "https://raghucosmosdb.documents.azure.com:443/",
    "PrimaryKey": "",//not pasting as github will give error so paste it in visual studio from cosmos portal

     "DatabaseName": "DemoDB",
    "ContainerName": "items"
  }
}


next add necessary packages required for the application 

in the search just type newton and then add this below package of version 8.0.24 only install as it is compatible with .net core 8.0 which we are using it okay 
so this is required becasue cosmos db is primary json based structured document okay 


Microsoft.AspNetCore.Mvc.NewtonsoftJson 

again in search type cosmos and install the package Microsoft.Azure.Cosmos anything which is latest u can install here 


Now go to Models folder and add a model with the name Itemmodel

using Newtonsoft.Json;

namespace CosmosDB_Demo.Models
{
    public class Itemmodel
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }
    }
}

here as we store in json format all things we have to write like this only 

Now i want to add data layer so create one folder with the name Data and in that add an class with the name CosmosDbService and 

  so the complete code of CosmosDbService class will be like this 


using Microsoft.Azure.Cosmos;
using CosmosDB_Demo.Models;
namespace CosmosDB_Demo.Data
{
    
        public class CosmosDbService
        {
            private Container _container;

            public CosmosDbService(CosmosClient cosmosClient,
                string databaseName, string containerName)
            {
                _container = cosmosClient.GetContainer(databaseName, containerName);
            }

            public async Task AddItemAsync(Itemmodel item)
            {
                await _container.CreateItemAsync(item, new PartitionKey(item.Id));
            }


            public async Task<Itemmodel> GetItemAsync(string id)
            {
                ItemResponse<Itemmodel> response = await
                    _container.ReadItemAsync<Itemmodel>(id, new PartitionKey(id));

                return response.Resource;
            }


            public async Task<IEnumerable<Itemmodel>> GetItemsAsync(string queryString)
            {
                var query = _container.GetItemQueryIterator<Itemmodel>(new QueryDefinition(queryString));
                List<Itemmodel> results = new List<Itemmodel>();

                while (query.HasMoreResults)
                {
                    var response = await query.ReadNextAsync();
                    results.AddRange(response.ToList());
                }

                return results;
            }


            public async Task UpdateItemAsync(string id, Itemmodel item)
            {
                await _container.UpsertItemAsync(item, new PartitionKey(id));
            }

            public async Task DeleteItemAsync(string id)
            {
                await _container.DeleteItemAsync<Itemmodel>(id, new PartitionKey(id));
            }



    }
    
}

next go to program.cs file 

on the top add following namespaces 

using CosmosDB_Demo.Data;
using Microsoft.Azure.Cosmos;

and then add code after this below line to impelement dependency 


   builder.Services.AddControllersWithViews(); //after this add 

   builder.Services.AddSingleton<CosmosDbService>(options =>
   {
       var _configuration = builder.Configuration;

       var cosmosClient = new CosmosClient(
           _configuration["CosmosDb:Endpoint"],
           _configuration["CosmosDb:PrimaryKey"]);

       return new CosmosDbService(
           cosmosClient,
           _configuration["CosmosDb:DatabaseName"],
           _configuration["CosmosDb:ContainerName"]);
   });


so this is the settings which i had done in my json file that only i am using it here okay

Now just build and run the application once to check whether any error is there on not all things are proeprly set or not for that purpose we have to do this

  
  so till now i checked it is working fine next task 
