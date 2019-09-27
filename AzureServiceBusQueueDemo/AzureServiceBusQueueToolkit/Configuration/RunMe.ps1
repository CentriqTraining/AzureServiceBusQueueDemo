# Promp for user login
az login 

# Create a resource group called CentriqAzureDemo
#   We'll use this only for our demo so we can easily clean up
az group create -n CentriqAzureDemo -l eastus

#  Create the AzureDemo Storage Account
az servicebus namespace create -n CentriqSBQueueDemo -g CentriqAzureDemo -l eastus

#  Create a Access Policy for the Listener Service
az servicebus queue authorization-rule create --queue-name testqueue --resource-group CentriqAzureDemo --namespace-name CentriqSBQueueDemo --name ListenerAccessKey --rights Manage, Send, Listen
 
#  Create a Access Policy for the Sender Service
az servicebus queue authorization-rule create --queue-name testqueue --resource-group CentriqAzureDemo --namespace-name CentriqSBQueueDemo --name SenderAccessKey --rights Send

# Query the Keys for this new Redis CAche and place it in a json file under our
#  configuration directory to be used when we run 
az servicebus queue authorization-rule keys list -n ListenerAccessKey --queue-name testqueue --namespace-name CentriqSBQueueDemo -g CentriqAzureDemo > ListenerConfig.json
az servicebus queue authorization-rule keys list -n SenderAccessKey --queue-name testqueue --namespace-name CentriqSBQueueDemo -g CentriqAzureDemo > SenderConfig.json

Write-Host "==============================================================="
Write-Host "Ready to use your Azure Service Bus Account..."
Write-Host "You can now build your project and run"