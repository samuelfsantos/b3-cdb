FROM nginx:alpine

# Remover arquivos padrão do Nginx
RUN rm -rf /usr/share/nginx/html/*

# Copiar o arquivo index.html para o diretório do Nginx
COPY index.html /usr/share/nginx/html/index.html

CMD ["nginx", "-g", "daemon off;"]

EXPOSE 80
EXPOSE 443