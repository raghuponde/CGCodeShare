
Azure key Vault :
------------------
  It is a managed servcie that can be used to store secret information ,encryption keys and creating certificates 

  
First create an Azure key vault in azure portal and then you will see there three things keys,secrets and certificates 
so after creeating key vault and one key and create a dummy app go to console application and create an project with the same name of app 


Add these packages in console app

Azure.Identity 1.21.0 stable version add it 

Azure.Security.KeyVault.Keys  4.9.0 version 

add this much basic template into the console application 

 string tenantId = ""
 string clientId = "";
 string clientSecret = "";


 var credential = new ClientSecretCredential(tenantId,clientId,clientSecret);

 string vaultUrl = "https://key-vault-cg.vault.azure.net/";
 string keyName = "key-cg";


 var keyClient = new KeyClient(new Uri(vaultUrl), credential);
