
FROM node:latest AS build

WORKDIR /app

COPY package*.json ./

RUN npm install

COPY . .

RUN npm run build -- --configuration=production

FROM nginx:alpine

RUN rm -rf /usr/share/nginx/html/*

COPY --from=build /app/dist/b3-cdb-site/browser /usr/share/nginx/html

CMD ["nginx", "-g", "daemon off;"]

EXPOSE 80
EXPOSE 443
