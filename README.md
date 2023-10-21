# Ske-Project

## Introducción
Este proyecto proporciona una API la cual podrás utilizar para la administracion de una Tienda. Se cuenta con un sistema de autorizacion, restringiendo el acceso de información a determinados roles. En este caso solo aquel con el rol "Administrador" podrá regisrar, adregar, eliminar y demas para un usuario.

❗- Al momento de realizar el update de la base de datos y ejecutar por primera vez se insertaran los datos con los cuales nos daran la facilida de 
hacer las pruebas de funcionamiento mas rapido.

## Características 🌟

- Registro de usuarios.
- Autenticación con usuario y contraseña.
- Generación y utilización del token.
- CRUD completo para cada entidad. 
- Vista de las consultas requeridas.
- Para cada controlador GET se estan manejando dos versiones :fire: - 
  - 1.0 -> Esta version NO incluye paginacion en los metodos GET 
  - 1.1 -> Esta Version SI incluye paginacion en los metodos GET  :white_check_mark:

## Configuración del Proyecto

Antes de ejecutar el proyecto, asegúrate de configurar adecuadamente las siguientes variables de entorno o archivos de configuración:
  - Tener en cuenta que es muy probable que el puerto del localhost pueda cambiar :warning: - 

- **appsettings.json**: `server=localhost;user=root;password="AQUÍ";database=Veterinaria`
- **appsettings.Development.json**: `server=localhost;user=root;password="AQUÍ";database=Veterinaria`

## Ejecución del Proyecto

1. Clona este repositorio o descarga directamente los archivos del proyecto.

2. Configura las variables de entorno y archivos de configuración como se mencionó anteriormente en `appsettings.json` y `appsettings.Development.json`.

3. Para ejecutar la aplicación, abre una terminal utilizando Visual Studio y ejecuta el siguiente comando: `dotnet run --project .\ApiAuth\`.

4. Para realizar consultas y acceder a la API, utiliza los endpoints dentro de alguna extensión como Thunder o aplicación externa como Insomnia.
   
5. Listo, disfruta navegando y consultando.
   
## Endpoints API 🕹 

Una vez que el proyecto esté en marcha, puedes acceder a los diferentes endpoints que se describiran acontinuacion:<br>

### 1. Register de Usuario: 
 ⚠️ - Solo una persona con rol de administrador puede realizar esta accion.

        **Endpoint**: `http://localhost:5159/Api/User/register`

        **Método**: `POST`
        
        **Payload**:
        json
        `{
          "email": "Cris@gmail.com",
          "username": "Cris",
          "password": "6789"
        }`
Ingresa el token de un Usuario con Rol Administrador para que puedas hacer el endpoint.
![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/b526613e-50e2-4a0a-a34e-fe5e5f3dc739)
        
### 2. AddRole de Usuario.
  ⚠️ - Solo una persona con rol de administrador puede realizar esta accion.

        **Endpoint**: `http://localhost:5159/Api/User/addrole`

        **Método**: `POST`
        
        **Payload**:
        json
        `{
          "username": "Cris",
          "password": "6789",
          "role": "Administrador"
        }`
Ingresa el token de un Usuario con Rol Administrador para que puedas hacer el endpoint.
![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/b526613e-50e2-4a0a-a34e-fe5e5f3dc739)

  ### 3. Token de Usuario.
  ⚠️ - Todos necesitan generar su token para poder acceder a los endpoints.

        **Endpoint**: `http://localhost:5159/Api/User/token`

        **Método**: `POST`
        
        **Payload**:
        json
        `{
          "username": "Cris",
          "password": "6789"
          }`
     ![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/797ac0c8-a3f8-446f-b420-e29360135448)
Dependiendo del rol que tenga el usuario de este token se podrá hacer el Register, AddRole, Post, Put Y Delete de Usuario.
     

### 4. Refresh Token: 
![image](https://github.com/Danilop109/Backend-Vet/assets/124645738/6baf83af-9f52-409c-8096-1ba9421cc9ef)

Refresca despues de 1 MINUTO el token para seguur accediendo a los endpoints.

    **Endpoint**: `http://localhost:5159/Api/User/refresh-token`
  ⚠️ - En este caso no debes ingresar nada.    
### 5. Crud Usuario: Recuerda que para Post, put y Delete necesitas token de un usuario con rol de Administrador.
**Endpoints**

    Obtener Todos los Usuarios: GET `http://localhost:5159/Api/User`
    
    Obtener Usuario por ID: GET `http://localhost:5159/Api/User{id}`
    
    Actualizar Usuario: PUT `http://localhost:5159/Api/User{id}`
    
    Eliminar Usuario: DELETE `http://localhost:5159/Api/User{id}`

## Grupo 1. Listar los insumos que pertenecen a una prenda especifica. El usuario debe ingresar el código de la prenda.:

**Endpoint**: `http://localhost:5159/api/Prenda/GetInsumosByPrenda/{idPrenda}`

**Método**: `GET`

## Agradecimientos

¡Gracias por usar este proyecto! Si tienes alguna pregunta o sugerencia, no dudes en ponerte en contacto con la creadora.
Con cariño Daniela López.