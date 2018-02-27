FROM httpd:alpine

# Create dirs
RUN mkdir -p /var/log/apache2
RUN mkdir -p /etc/ssl/certs
RUN mkdir    /etc/ssl/private

# Copy apache2 config
COPY ./httpd.conf    /usr/local/apache2/conf/httpd.conf
COPY ./sites-enabled /usr/local/apache2/conf/sites-enabled

# Copy certs
## first copy the dev certs as default
COPY ./certs/scho-dot-com.selfsigned.dev.crt /etc/ssl/certs/stoyandimov.com.crt
COPY ./certs/scho-dot-com.selfsigned.dev.key /etc/ssl/private/stoyandimov.com.key
COPY ./certs/scho-dot-com.selfsigned.dev.crt /etc/ssl/certs/stoyandimov.com.chain.crt

## if production certs exist (git ignored) they will replace the dev ones
COPY ./certs/*.crt /etc/ssl/certs/
COPY ./certs/*.key /etc/ssl/private/

## Generate certificate chain
RUN cat /etc/ssl/certs/rootCA.crt /etc/ssl/certs/stoyandimov.com.crt > /etc/ssl/certs/stoyandimov.com.chain.crt

EXPOSE 80 443