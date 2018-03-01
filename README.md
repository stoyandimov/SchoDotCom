# SchoDotCom [![Travis](https://travis-ci.org/stoyandimov/SchoDotCom.svg?branch=master)](https://travis-ci.org/stoyandimov/SchoDotCom)

The source code of stoyandimov.com website.

## Run with .NET Core

### Prerequisites
Install [dotnet core cli](https://www.microsoft.com/net/download) (for your OS)

### Get the source, restore and run
```
git clone https://github.com/stoyandimov/SchoDotCom scho-dot-com
cd scho-dot-com/src/SchoDotCom.WebUI

# Restore packages and run the app
dotnet restore
dotnet run

# browse on http://localhost:5000
```

## Run with Docker
Install [docker](https://docs.docker.com/install/) (for your OS)

### Run website container

```
git clone https://github.com/stoyandimov/SchoDotCom scho-dot-com
cd scho-dot-com/src/SchoDotCom.WebUI

# Build container and run it
docker build -t scho-dot-com .
docker run -d -p 80:80 --name scho-dot-com scho-dot-com 

#browse on http://localhost (:80)
```

## Issues
Please, submit bug or suggestions to the [issue tracker](https://github.com/stoyandimov/SchoDotCom/issues)
