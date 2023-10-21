docker run --rm -it -v ${PWD}:/local countingup/nswag swagger2csclient /input:local/swagger.json /output:local/Dtos.Generated.cs /namespace:EmerchAPI.Models.Dtos /ContractsOutput:local/Dtos.Generated.cs /GenerateClientClasses:false /JsonLibrary:SystemTextJson /GenerateExceptionClasses:false

https://emerch.nakodeelee.ru/api/swagger/index.html

helm upgrade --install --cleanup-on-fail emerch-backend ./ --create-namespace --namespace emerch-backend --values values.modified.yaml
helm uninstall emerch-backend -n emerch-backend
