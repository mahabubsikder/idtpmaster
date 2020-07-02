1. Go to Azure Web Portal and create new resource > Key Vault
2. Select A resource group and give a vault name 
3. Select a retention period which CANNOT BE Changed later
4. Hit Review+Create

Once created go to the resource with the vault name
1. Then on the left panel there is "Secrets"
2. In secrets we can add new name and a secret value

In the left panel, there is also "Access Policy" 
1. Clicking that, we will get a page where we can "+Add Access Policy"
2. Select which permissions we need our app to have (e.g get,list secrets)
3. Select Principal ==> this is where we select our hosted webapp/service** which can access the secrets

** To have our app show up in select principal we need to go to our App> Identity and turn on System Assigned Managed Identity On
then we we will get an object id which allows us to add it to access key vault
4. Finally click Add
Now our deployed web app will have access to the key vault and secrets
In the KeyVaultManagement.cs class, the method to access the secret from code is written.


TO DO EVERYTHING WITH AZURE CLI:
https://docs.microsoft.com/en-us/azure/key-vault/general/tutorial-net-create-vault-azure-web-app
To get secret from deployed app's APP SETTINGS WE CAN USE KEY VAULT REFERENCE:
https://docs.microsoft.com/en-us/azure/app-service/app-service-key-vault-references