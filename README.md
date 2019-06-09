# Tutorial Asp.net Web API Core
Por: Ramiro Andrés Bedoya Escobar

Tutorial de asp.net web api 
Conceptos Generales de [Asp.Net](http://Asp.Net) Web Api Creación del un proyecto con VS 2017

Repositorio final

https://github.com/Whistler092/SocialNetwork

----------
## Pre-requisitos

Para la realización de la siguiente guía, es necesario cumplir con los siguientes requerimientos. Todos los pasos serán ejecutados en el sistema operativo Windows 10, pero el código será compatible con los entornos Linux y MacOS.

Para **Windows** bastará solamente con ingresar al [sitio web oficial](https://visualstudio.microsoft.com/vs/) y descargar la versión Community: 

NOTA 1: Para macOS también hay una versión llamada Visual Studio for Mac.
NOTA 2: Para Linux, no hay una versión del IDE pero se podrá programar con el editor de texto [Visual Studio Code](https://code.visualstudio.com/).
 

- [Visual Studio 2019](https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16) [](https://visualstudio.microsoft.com/downloads/)
- [.NET Core SDK 2.2 or later](https://www.microsoft.com/net/download/all)

**Instalación**
Al ejecutar el instalador en Windows por primera vez, el instalador realizará una validación inicial y después presentará una serie de opciones para instalar. Se seleccionarán las siguientes:

![ASP.NET and web development (en Web & Cloud)](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554350941271_image.png)

![.NET Core cross-platform development (en Other Toolsets)](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554350961113_image.png)


Y procedemos a ejecutar la instalación.


**Instalación de la base de datos Microsoft SQL Server**

Para la siguiente guía, se recomienda la instalación del motor SQL Server 2017 Developer, el cual, es una edición gratuita con todas las funciones, con licencia para su uso como base de datos de desarrollo y prueba en un entorno no productivo.


https://www.microsoft.com/en-us/sql-server/sql-server-downloads



## Creación de un proyecto

Después de haber tenido instalado el **Visual Studio,** seleccionamos en la vista principal la opción “**Create a new project**” y podemos encontrar las siguientes opciones:


- **Applications** para Windows, Linux y Mac usando .NET Core


- Aplicaciones para Windows usando **.NET Framework**

**Con Visual Studio:** 
Al abrir el Visual Studio, se encuentra una serie de templates como lo muestra la siguiente imagen.

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554353544838_image.png)


En este caso se elegirá **“ASP.NET Core Web Application”** con el tag **C#.** Establecemos el nombre del proyecto y seleccionamos el template **API:**


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554354469068_image.png)


Y damos click en **Crear.** La estructura del proyecto creada será esta:

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554354564642_image.png)


**Con Visual Studio Code (Windows, Linux y macOS):**

Para este proyecto, abrimos la terminal y como se ve en la siguiente imagen, se puede detallar todos los proyectos que podemos crear con .Net Core

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554355004322_image.png)


La imagen anterior permite mostrar la variedad de proyectos que se pueden crear desde la consola. Para la finalidad de este proyecto se creará ejecutando los siguientes comandos:

- PS C:\workspace> **dotnet new webapi -o SocialNetworkDotnet**
- PS C:\workspace> **cd .\SocialNetworkDotnet\**
- PS C:\workspace\SocialNetworkDotnet> **dotnet restore**
- PS C:\workspace> **code .\SocialNetworkDotnet\**



## Estructura de un proyecto ASP.NET Web API

Después de haber creado el API del proyecto podemos encontrar una serie de archivos que serán descritos a continuación: 


| **Archivos y Carpetas**    | **Proposito**                                                                                                                              |
| -------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------ |
| El folder **/Controllers** | En esta carpeta se pondrán las clases Controladoras para manejar las peticiones (Requests).                                                |
| El archivo **Program.cs**  | Este es el punto de entrada para la ejecución de la aplicación usando el método Main.                                                      |
| El archivo **Startup.cs**  | Esto es necesario para configurar la configuración y para conectar los servicios que utilizará la aplicación                               |
| El .**csprojfile**         | Este es un archivo de proyecto C#, el cual contiene la configuración del proyecto y referencias a los archivos utilizados por el proyecto. |

## Agregando una conexión a la base de datos.

Uno de los principios básicos para crear un API RESTful es el de poder realizar consultas, actualizar y guardando información en la base de datos. Para dicha tarea en un proyecto .Net se puede realizar de multiples formas, pero de la forma más practica es usar el ORM ( Mapeo objeto-relacional) Entity Framework, que permite conectarse a una gran variedad motores de bases de datos como SQL Server, MySQL o Oracle.

Se puede crear una base de datos a partir desde un modelo o simplemente generar un modelo basado en una base de datos existente. 

**Recursos:**

    Creación de una base de datos a partir de un modelo: https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/new-db?tabs=visual-studio 
    Creación de un modelo a partir de una base de datos: https://docs.microsoft.com/en-us/ef/core/get-started/aspnetcore/existing-db

**Instalando Entity Framework Core**

Para instalar EF Core, es necesario instalar el paquete para los proveedores de base de datos de EF Core a los que desea dirigirse. Existe gran variedad de proveedores, en este proyecto se usará SQL Server pero puedes consultar la lista completa de proveedores en el siguiente Link: https://docs.microsoft.com/en-us/ef/core/providers/index

Usado en este proyecto: [Microsoft.EntityFrameworkCore.SqlServer](https://docs.microsoft.com/en-us/ef/core/providers/sql-server/index)

En **Visual Studio,** ingresar a la opción 

- **Tools > NuGet Package Manager > Package Manager Console**
![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560085624399_image.png)

- Después se abrirá una consola en la parte inferior y pegamos el siguiente comando de PowerShell


    Install-Package Microsoft.EntityFrameworkCore.SqlServer


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560085783119_image.png)


**NOTA**: Si se creó el proyecto a partir de una linea de  commandos(.NET Core CLI), se debe ejecutar el siguiente comando en la terminal del sistema:


    dotnet add package Microsoft.EntityFrameworkCore.SqlServer

**Creación de un modelo**

Para crear un modelo, se debe crear una carpeta **Models** en el proyecto, dando click derecho en el proyecto,  Seleccionar **Add > New Folder.**

Para agregar una clase, se debe dar click derecho sobre la carpeta Models, seleccionar **Add > Class.** Entrar el nombre **ModelContext.cs** y dar click en **OK.**

Agregamos el siguiente contenido en el archivo: 


    using Microsoft.EntityFrameworkCore;
    
    namespace SocialNetwork.Models
    {
        public class ModelContext : DbContext
        {
            public ModelContext(DbContextOptions<ModelContext> options)
                : base(options)  {  }
    
            public DbSet<User> Users { get; set; }        
            public DbSet<Profile> Profiles { get; set; }
            public DbSet<Publication> Publications { get; set; }
        }
    }
    

 Y se crean las siguientes 3 clases: 
 

    using System.Collections.Generic;
    
    namespace SocialNetwork.Models
    {
        public class User
        {
    
            public int UserId { get; set; }
            public bool Active { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
    
            // Profile relationship
            public int ProfileId { get; set; }
            public Profile Profile { get; set; }
    
            // User Friends Relationship
            public ICollection<User> Friends { get; set; }
        }
    }

 

    using System;
    using System.Collections.Generic;
    
    namespace SocialNetwork.Models
    {
        public class Profile
        {
            public int ProfileId { get; set; }
            public string Names { get; set; }
            public string LastNames { get; set; }
            public string Photo { get; set; }
            public DateTime BirthDate { get; set; }
            public string Sex { get; set; }
    
            // Publications Relationship
            public ICollection<Publication> Publications { get; set; }
        }
    }

 

    using System;
    
    namespace SocialNetwork.Models
    {
        public class Publication
        {
            public int PublicationId { get; set; }
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime CreationDate { get; set; }
    
            public int ProfileId { get; set; }
            public Profile Profile { get; set; }
        }
    }

 
**Diseño del modelo de base de datos**

La idea principal de este proyecto es una red social, que tiene un perfil, dicho perfil podrá realizar publicaciones y agregar amigos. 

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554616839986_image.png)



**Registrar el contexto de datos en la inyección de dependencias  en la aplicación**

Para poder hacer disponible el contexto **ModelContext** en el proyecto, se debe de registrar en el archivo **Startup.cs**
 
Por tal razón, agregamos en el inicio del archivo las siguientes lineas:
 

    using SocialNetwork.Models;
    using Microsoft.EntityFrameworkCore;

 
 Y, Agregue el siguiente código resaltado al método **ConfigureServices**:
 

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
    
        var connection = @"Server=DESKTOP-U5GUB10;Database=SocialNetwork;Trusted_Connection=True;";
        services.AddDbContext<ModelContext>(options => options.UseSqlServer(connection));
    }

 
 La cadena de conexión se compone de la siguiente forma:

    Server=DESKTOP-U5GUB10;
    Database=SocialNetwork;

 
 Server= Nombre del servidor.
 Database = Base de datos creada.
 
 Si la configuración de la base de datos es diferente a lo standard, en el siguiente Link se puede detallar:  https://www.connectionstrings.com/sql-server/
 
**Protip:** Lo recomendable es guardar las cadenas de conexión en los archivos de configuración. Aquí podemos encontrar información recomendada: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-strings
 
**Conexión y creación de la base de datos**
 
Ingresar a la base de datos por medio de la aplicación **Microsoft SQL Server Management** y conectarse a la instancia local.


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554614580864_image.png)


Y ejecutar el siguiente Script.
 

    USE MASTER;
    
    CREATE DATABASE [SocialNetwork];

 
**Creación de la base de datos.**

Para que se pueda generar las tablas de la base de datos, se realiza una serie de pasos por medio de las **Migraciones,** el cual, sincroniza las modificaciones del modelo con la base de datos.

Para ver más información respecto a las migraciones ver: https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/index

En **Visual Studio,** ingresar a la opción 

- **Tools > NuGet Package Manager > Package Manager Console**
- Correr los siguientes commandos:


      - Add-Migration InitialCreate
      - Update-Database


    - El comando **Add-Migration** organiza una migración para crear el conjunto inicial de tablas para el modelo. El comando **Update-Database** crea la base de datos y aplica la nueva migración.

Si se creó el proyecto a partir de una linea de commandos (.NET Core CLI), se debe ejecutar el siguiente comando: 


    dotnet ef migrations add InitialCreate
    dotnet ef database update


    - El comando **ef migrations** organiza una migración para crear el conjunto inicial de tablas para el modelo. El comando **ef database update** crea la base de datos y aplica la nueva migración.

Resultado: 

![Resultado de la consola Package Manager Console](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554616007278_image.png)

![Diagrama de base de datos generada por SQL Server management studio](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554616118262_image.png)


Posterior a esto, en el proyecto se creó una carpeta llamada **Migrations:**

![Son creados los archivos 20190407054548_InitialCreate.cs y ModelContextModelSnapshot.cs](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554616344936_image.png)




## Creación de los API Controller y consulta de las API’s con Postman

En la sección anterior se ha creado el modelo que usaremos en nuestra aplicación, y se había generado por defecto un controlador simple llamado **ValuesController.cs** dentro de la carpeta **Controllers.** Los controladores se encargan de recibir todas las peticiones HTTP y enviar una respuesta de vuelta a que lo invocó. 

Los Web Api Controllers son una clase que que se crearán dentro de la carpeta **Controllers** o en cualquier otra carpeta, pero por uniformidad del código se mantendrá así, mientras sea dentro del folder principal. El nombre de un controlador debe terminar con la palabra “**Controller”** y deberá extender de la clase System.Web.Http.**ApiController** en asp.net clasico y desde Microsoft.AspNetCore.Mvc.**ControllerBase** en asp.net core (El que usa este proyecto).

Todos los métodos públicos que contendrán este Controlador se llamarán **Métodos de acción** o **Action Methods.**

Para agregar un nuevo controlador con acciones usando Entity Framework (Scafolding), se debe dar click derecho sobre la carpeta **Controllers**, seleccionar **Add > Controller...** Y se selecciona la siguiente opción**:**

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554651274836_image.png)


Y se seleccionan las opciones para el controlador a crear: 


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554651336779_image.png)


Esto generará un archivo llamado **UsersController.cs.** De las características principales de este archivo es que posee un decorador llamado **[ApiController]** que permitirá agregarle a dicho controlador todas las características para soportar peticiones HTTP en formato RESTful.

El haber utilizado el Scaffold para agregar el controlador, agregará varios métodos. Cada uno soportará un Estado HTTP, de los estados más comunes son: GET, POST, PUT y DELETE


    // GET: api/Users
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
        ...
    }
    
    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] int id)
    {
        ...
    }
    
    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
    {
         ...
    }
    
    // POST: api/Users
    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
        ...
    }
    
    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        ...
    } 

**Resultado de la API creada:**

| API                    | Descripción                           | Cuerpo de la solicitud | Cuerpo de la respuesta |
| ---------------------- | ------------------------------------- | ---------------------- | ---------------------- |
| GET /api/users         | Obtener todas las usuarios creados    | Ninguna                | Matriz de los usuarios |
| GET /api/users/{id}    | Obtener un elemento por identificador | Ninguna                | Usuario                |
| POST /api/users        | Incorporación de un nuevo elemento    | Un objeto de usuario   | Usuario                |
| PUT /api/users/{id}    | Actualizar un elemento existente      | Un objeto de usuario   | Ninguna                |
| DELETE /api/users/{id} | Eliminar un elemento                  | Ninguna                | Ninguna                |



**Ejecutar la aplicación**

En el Visual Studio, se puede dar **F5** o **Debug > Start Without Debugging,** esto iniciará un servidor IIS Express con la aplicación.

Si se creó el proyecto a partir de una linea de commandos (.NET Core CLI), se debe ejecutar el siguiente comando: 


    dotnet run

**Warning:** Cuando se ejecuta por primera vez el aplicativo, el proyecto está configurado para trabajar sobre SSL (https), por tal razón saldrá el siguiente mensaje:

![Mensaje de Instalación del Certificado SSL sobre IIS Express](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554653247216_image.png)


Y el siguiente mensaje instalará el certificado SSL:

![Instalación del Certificado SSL](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554653272154_image.png)


**Probando el API de Users y que son los Status Code**

La forma más fácil para hacer dichas peticiones es a través de la aplicación [POSTMAN](https://www.getpostman.com/) que es una aplicación de escritorio creada para facilitar el desarrollo de API’s. Para instalarlo se debe descargar el instalador desde su pagina web: https://www.getpostman.com/downloads/ 

Despues de instalada, para obtener todos los registros, se ingresa a Postman y ejecutamos la siguiente URL

_> https://localhost:44305/api/users

**NOTA**: Por defecto, los Certificado SSL Auto-firmados son bloqueados, para actualizar esto se debe apagar la verificación yendo a **File > Settings > General** y desactivando la opción  **'SSL certificate verification’**


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554654164938_image.png)


De las principales cosas que hay que notar es que el Web Service devolvió un Status 200 OK, Los Status Code de HTTP son formas livianas y fáciles de responder mensajes. Haya varios tipos de Status Code y HTTP implementa una amplia variedad de códigos de estados agrupados en 5 tipos distinguidos por el primer número del código:

**Códigos 1XX**: Códigos informativos. Rara vez se utiliza en aplicaciones web modernas.
**Códigos 2XX**: Códigos de éxito. Le dice al cliente que la solicitud tuvo éxito.
**Códigos 3XX**: Códigos de redireccionamiento. Le dice al cliente que puede necesitar redirigir a otra ubicación.
**Códigos 4XX**: Códigos de error del cliente. Le dice al cliente que algo andaba mal con lo que envió al servidor.
**Códigos 5XX**: Códigos de error del servidor. Le dice al cliente que algo salió mal en el lado del servidor, para que el cliente pueda volver a intentar la solicitud, posiblemente en un momento posterior.

**Seleccionando el Código Adecuado**

No existe una forma única forma de seleccionar el código de estado adecuado, y básicamente depende de las reglas actuales del negocio. Pero a menos de que los requerimientos del negocio requieran algo diferente, es adecuado devolver un código más especifico que un código genérico.

**Retornando el objeto - 200 OK**

Existen cierto tipo de Respuestas automáticas generadas por un controlador. Por ejemplo cuando el método retorna una lista por ejemplo: 


    public IEnumerable<User> GetUsers()

El por defecto devolverá un **200 - OK** automáticamente. Porque si se retorna algún objeto serializable desde un Web Api, la respuesta convertirá automáticamente en 200 - OK, con el objeto escrito en el cuerpo de la respuesta. Aunque si se desea responder explícitamente ese código de respuesta, todo lo que se necesita es cambiar el tipo de retorno del método a **IActionResult** Y se encapsula la respuesta en un método **Ok**


    // GET: api/Users
    [HttpGet]
    public IActionResult GetUsers()
    {
        return Ok(_context.Users);
    }

**Otros tipos de Objectos por retornar**

Existe una gran variedad de métodos de para referirse a un conjunto de métodos que devuelven clases que implementan **IActionResult**. Los siguientes métodos responderán códigos de estados comunes de HTTP:


    **BadRequest()**: Devuelve 400 - Solicitud incorrecta.
    **NotFound()**: Devuelve 404 - No encontrado.
    **InternalServerError()**: devuelve 500 - Error interno del servidor.

También hay un método que puede devolver cualquier código de estado HTTP:


    **StatusCode (HttpStatusCode statusCode)**: devuelve el código de estado especificado.

**Guardar un objeto en el API de Users**

Usando Postman, se guardará el Usuario y en la misma transacción el objeto Profile relacionado a si mismo. Asegúrate de poner el Objeto JSON que se guardará en la pestaña Body, seleccionar la opción RAW y JSON (application/json). Para avisarle al Backend que el objeto a enviar será de ese tipo. También se debe de cambiar el **HTTP método** por **POST.**


    {
        "Active" : true,
        "Username": "whistler",
        "Password" : "12345",
        "Email": "hi@ramirobedoya.me",
        "Profile": {
            "Names": "Ramiro Andrés",
            "LastNames" : "Bedoya Escobar",
            "Photo" : "https://avatars0.githubusercontent.com/u/6548822?s=460&v=4",
            "BirthDate": "1991/01/01",
            "Sex": "M"
        }
    }
![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1554658266089_image.png)


Al crear el item, el servidor retornará el Status Code **201 - Created** y el objeto creado con sus Id’s asignados.

**Ejercicio:** Crear los siguientes Controladores a partir de las indicaciones anteriores. 

- Profile
- Publication


## Enrutamiento y las URL Paths

Como pudiste haber notado en el punto anterior, hemos invocado el API de Users simplemente ejecutando la siguiente URL 


    https://localhost:44305/api/users

Dicha URL fue creado por medio de un **Middleware** de enrutamiento que contiene por defecto que tiene asp.net core. El se encarga de buscar las direcciones URL entrantes y asignarla a los controladores y las acciones. Dichas rutas se definen en el código de inicio o en los atributos de cada acción. EJ.


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560087788040_image.png)


La plantilla de ruta por defecto utilizada es **"{controller}/{action}/{id?}”** y se podría decir que genera una ruta como la que estamos usando 


    api/Users/id

Y si queremos recibir parametros por URL, se debe especificar en el HttpGet

![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560094459468_image.png)


O en el caso de enviar parametros por URL y desde el cuerpo, se configura el método de la siguiente forma


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560094797243_image.png)


Usando los decoradores, **[FromRoute]** y **[FromBody]** podemos interactuar de una forma personalizada con nuestros Actions


## Documentación con Swagger/OpenAPI

La idea principal de crear un API RESTful, es la de poder tener una serie de servicios web capaces de poder ser consumidos desde una variedad de fuentes como lo son aplicaciones móviles o páginas web. Cuando creamos estos servicios web, existe una gran variedad de formas de crearlos y puede resultar complicado comprender sus diversos métodos, eso depende de los estándares del proyecto o el estilo de programación del equipo.

[Swagger](https://swagger.io/), el cual es un proyecto OpenSource donado a la iniciativa [OpenAPI](https://www.openapis.org/), resuelve el problema de generar páginas útiles de ayuda y documentación relacionadas a las API Web por medio de una documentación interactiva. El resultado principal que genera la herramienta swagger es un archivo llamado swagger.json, el cual describe las funcionalidades del API y como tener acceso a ellos con HTTP.

Puedes encontrar varias formas de implementarlo en un proyecto .net core en la siguiente [URL](https://docs.microsoft.com/es-es/aspnet/core/tutorials/web-api-help-pages-using-swagger?view=aspnetcore-2.2), en este caso implementaremos **Swashbuckle.**
 
 Hay tres componentes principales de Swashbuckle:

- [Swashbuckle.AspNetCore.Swagger](https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/): modelo de objetos de Swagger y middleware para exponer objetos `SwaggerDocument` como puntos de conexión JSON.
- [Swashbuckle.AspNetCore.SwaggerGen](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerGen/): generador de Swagger que genera objetos `SwaggerDocument` directamente desde las rutas, controladores y modelos. Se suele combinar con el middleware de punto de conexión de Swagger para exponer automáticamente el JSON de Swagger.
- [Swashbuckle.AspNetCore.SwaggerUI](https://www.nuget.org/packages/Swashbuckle.AspNetCore.SwaggerUI/): versión insertada de la herramienta de interfaz de usuario de Swagger. Interpreta el JSON de Swagger para crear una experiencia enriquecida y personalizable para describir la funcionalidad de la API web. Incluye herramientas de ejecución de pruebas integradas para los métodos públicos.

Instalación: En **Visual Studio,** ingresar a la opción 

- **Tools > NuGet Package Manager > Package Manager Console**
- Correr el siguiente comando:


    Install-Package Swashbuckle.AspNetCore

Despues, vamos al archivo **Startup.cs,** en el método **ConfigureServices** y registramos a Swagger como Middleware y en el método Configure inicializamos el Swagger. La modificación deberá lucir así: 


    ...
    using Swashbuckle.AspNetCore.Swagger;
    
    namespace SocialNetwork
    {
      public class Startup
      {
        ...
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          //Resto del Método.
    
          // Registrar el generador Swagger
          services.AddSwaggerGen(c =>
          {
              c.SwaggerDoc("v1", new Info { Title = "Mi Red Social", Version = "v1" });
              // Guarda la ruta de los comentarios para el Swagger JSON y la UI.
              var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
              var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
              c.IncludeXmlComments(xmlPath);
          });
        }
    
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
          //Resto del Método.
    
          // Permitir que el middleware sirva Swagger generado un Endpoint en Json
          app.UseSwagger();
    
          // Habilita el Middleware para servir el swagger-ui (HTML, JS, CSS, etc.), 
          // especifica el Endpoint del JSON de Swagger.
          app.UseSwaggerUI(c =>
          {
              c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi Red Social v1");
          });
    
          //Resto del Método.
          app.UseHttpsRedirection();
          app.UseMvc();
        }
      }
    }
    

Ejecutamos la aplicación y accedemos a la siguiente URL: https://localhost:44305/swagger

Lo primero que encontramos es una aplicación web que lee el archivo swager.json


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560099855410_image.png)


y si expandimos cada uno, podemos ver en detalle información del API 


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560100091121_image.png)


y al final encontramos los modelos.


![](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560099895711_image.png)


**Personalizando nuestros métodos.** 

Para poder agregar comentarios a nuestros métodos y que se puedan ver reflejados en el swagger debemos habilitar el proyecto para que los comentarios se almacenen en un archivo XML. 

En Visual Studio: 

- Haga clic con el botón derecho en el **Explorador de soluciones** y seleccione **Editar <nombre_de_proyecto>.csproj**.
- Agregue manualmente las líneas resaltadas al archivo *.csproj*


    <PropertyGroup>
      <GenerateDocumentationFile>true</GenerateDocumentationFile>
      <NoWarn>$(NoWarn);1591</NoWarn>
    </PropertyGroup>

Estas modificaciones se hacen con el fin de habilitar comentarios XML para miembros y tipos pùblicos sin documentación.  Y para evitar las advertencias a nivel de proyecto. Ahora si podemos agregar comentarios a nuestros métodos como por ejemplo: 


![Comentarios básicos en Código](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560101189966_image.png)


Y podremos verlo reflejado así: 

![Comentarios básicos en Swagger](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560101163956_image.png)


También podemos extender los comentarios agregando ejemplos de la siguiente forma: 


![Comentarios de la función](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560101658212_image.png)


Y lo vemos reflejado de la siguiente forma:


![Petición de ejemplo](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560101712196_image.png)

![Respuestas del API](https://paper-attachments.dropbox.com/s_89174DDDF7262C2B179DB61DFC52A1A64FDD6201EFF8F1A2E8B37CACA5FC093E_1560101731083_image.png)


**Para poder ver más opciones de personalización visita la documentación oficial.**


https://docs.microsoft.com/es-es/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio

## 
## Enlaces Recomendados

https://fullstackmark.com/post/18/building-aspnet-core-web-apis-with-clean-architecture


https://docs.microsoft.com/es-es/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.2

https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-aspnet-mvc3/cs/adding-validation-to-the-model

https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation?view=aspnetcore-2.2


