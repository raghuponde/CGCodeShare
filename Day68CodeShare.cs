
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


  Now i want to encrypt and decrypt a blob image of container 

  so use this prompt and get the code for this in local visual studio program 

  Lets forget now what i was asking now i will give u the task in proper order
so Now i am having a storage account raghustoragecg and data as container as shown in s1 image and now in side data container i want to add the image but i want to encrypt the image and add it and when i want to download or want to see the image i should decrypt the image and want to see for this in second image s2 I had created a key-vault with key key-cg so now i want to create an app in console visual studio 2026 to encrypt and decrypt the image which is to be kept in data container so in app registration i will create a new app and want to work with it as shown in image 3
I am having a sample program for just encrypting text as showin in image 4 but i want a simillar program like this where i can encrypt and decrypt image
so for this give me in detail all the steps in detail step by step with complete souce code of image encryption and decryption and what packages need to be added etc and what role to be assingned blob usage also mention


https://learn.microsoft.com/en-us/azure/storage/blobs/storage-encrypt-decrypt-blobs-key-vault?tabs=roles-azure-portal%2Cpackages-dotnetcli  //check this url also 
