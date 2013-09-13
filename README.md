DevMentor.NPlayJS
=================

Webtest framework with jquery language support for ASP.NET / ASP.NET MVC

Configuration
=================

```xml
<appSettings>
    <add key="DevMentor.NPlayJS.RequireJQuery" value="true"/>
    <add key="DevMentor.NPlayJS.RequireAmplify" value="true"/>
    <add key="DevMentor.NPlayJS.Dev.Use" value="true"/>
    <add key="DevMentor.NPlayJS.Dev.Path" value="..\..\Source\DevMentor.NPlayJS"/>
    <add key="DevMentor.NPlayJS.Path" value="~\nplayjs"/>
    <add key="DevMentor.NPlayJS.Path.IncludeSubfolder" value="false"/>
</appSettings>
```

```xml
<system.web>
    <httpModules>
      <add name="NPlayJS" type="DevMentor.NPlayJS.NPlayJsModule,  DevMentor.NPlayJS"/>
    </httpModules>
    <httpHandlers>      
        <add verb="*" path="*.NPlayJS.js,*.NPlay.js,*.NPlayJS.css,*.NPlay.css" 
        type="DevMentor.NPlayJS.NPlayJsHandler,  DevMentor.NPlayJS" />      
    </httpHandlers>
    ...
</system.web>
```

```xml
  <system.webServer>
    <modules runAllManagedModulesForAllRequests="true">
      <add name="NPlayJS" type="DevMentor.NPlayJS.NPlayJsModule,  DevMentor.NPlayJS"/>
    </modules>
    <handlers>
      <add verb="*"  path="*.NPlayJS.js,*.NPlay.js,*.NPlayJS.css,*.NPlay.css" 
      type="DevMentor.NPlayJS.NPlayJsHandler,  DevMentor.NPlayJS" name="NPlayJsHanlder"  />
    </handlers>
  </system.webServer>
```
