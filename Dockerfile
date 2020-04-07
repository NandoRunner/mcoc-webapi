FROM mysql:5.7.22
EXPOSE 3306
COPY WebApi/db/migrations/ /home/database/
COPY WebApi/db/dataset/ /home/database/
COPY WebApi/ci/init_database.sh /docker-entrypoint-initdb.d/init_database.sh