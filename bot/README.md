# To build image run this
docker build -t registry.nakodeelee.ru/emerch-bot:v0 .

# To push image run this:
docker push registry.nakodeelee.ru/emerch-bot:v0

# To deploy run this
kubectl create -f ./deployment.yaml