# Use uma imagem Node.js oficial como base para a construção
FROM node:21.6.1 AS build

# Defina o diretório de trabalho no contêiner
WORKDIR /app

# Copie os arquivos do projeto Angular para o contêiner
COPY package*.json ./

# Instale as dependências do Angular
RUN npm install

# Copie todo o código fonte do projeto Angular para o contêiner
COPY . .

# Construa o projeto Angular
RUN npm run build --prod

# Use uma imagem Nginx oficial como base para o servidor web
FROM nginx:alpine

# Remova a configuração padrão do Nginx
RUN rm -rf /usr/share/nginx/html/*

# Copie os arquivos de build do Angular para o diretório do Nginx
COPY --from=build /app/dist/B3CdbSite /usr/share/nginx/html

# Exponha a porta 80
EXPOSE 80

# Comando padrão para iniciar o Nginx
CMD ["nginx", "-g", "daemon off;"]
