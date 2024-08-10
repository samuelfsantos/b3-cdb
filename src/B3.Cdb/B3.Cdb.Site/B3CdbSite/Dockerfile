
FROM node:21.6.1 AS build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build --prod

FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*

COPY --from=build /app/dist/b3-cdb-site /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]

EXPOSE 80
EXPOSE 443
