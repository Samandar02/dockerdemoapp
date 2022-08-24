FROM node AS build
WORKDIR /app
COPY package.json .
RUN npm install
COPY . .
RUN npm run build
FROM nginx
EXPOSE 80 
COPY --from=build /app/dist/simple-app /usr/share/nginx/html

