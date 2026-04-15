
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


after writing above code properly write below lines 

   KeyVaultKey key;

   key = await keyClient.GetKeyAsync(keyName);

   string originalText = "Sensitive order data for CloudXeus Technology Services";
   byte[] plaintextBytes = Encoding.UTF8.GetBytes(originalText);

   var cryptoClient = new CryptographyClient(key.Id, credential);

   EncryptResult encryptResult = await cryptoClient.EncryptAsync(
       EncryptionAlgorithm.RsaOaep,
       plaintextBytes);

   Console.WriteLine("Encrypted text (Base64):");
   Console.WriteLine(Convert.ToBase64String(encryptResult.Ciphertext));

   DecryptResult decryptResult = await cryptoClient.DecryptAsync(
       EncryptionAlgorithm.RsaOaep,
       encryptResult.Ciphertext);

   string decryptedText = Encoding.UTF8.GetString(decryptResult.Plaintext);

   Console.WriteLine("\nDecrypted text:");
   Console.WriteLine(decryptedText);

   Console.ReadLine();

convert your main method like this 

     static async Task Main(string[] args)
