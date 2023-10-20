helm upgrade --install --cleanup-on-fail emerch-backend ./ --create-namespace --namespace emerch-backend --values values.modified.yaml
helm uninstall emerch-backend -n emerch-backend