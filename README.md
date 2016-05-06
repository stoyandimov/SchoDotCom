#SchoDotCom [![Travis](https://travis-ci.org/stoyandimov/SchoDotCom.svg?branch=master)](https://travis-ci.org/stoyandimov/SchoDotCom)
## Configuration Setup
As in most ASP.NET web applications the application configuration is provided in a `Web.config` file.
`SchoDotCom` uses [Web.config transformations] (https://msdn.microsoft.com/en-us/library/dd465326%28v=vs.110%29.aspx) to build configuration file, by applying transformations from `Web.[ConfigName].config` to a `Web.Base.config` and saving the output in a `Web.config` file.

Review [Configuration Setup (Web.Config) page] (https://github.com/stoyandimov/SchoDotCom/wiki/Configuration-Setup-%28Web.config%29) for more details.
