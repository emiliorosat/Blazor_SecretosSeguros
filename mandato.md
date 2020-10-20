# Tarea 5

Realiza una aplicación web usando Blazor para registrar secretos personales. Estos secretos son privados y solamente le autor debe verlos.

* El usuario se podra registrar en la pagina, usando su numero de cedula y clave de su elección, el nombre, apellido y foto lo conseguirá usando el api. *

Cuando el usuario ingrese a la plataforma en algun lado vera su nombre, su foto y la listas de secretos que ha confesado en la aplicacion. Para registrar un secreto el usuario debe ingresar los siguientes campos.

Titulo. => Es el titulo de su secreto.
Descripcion => Es lo que paso o detalles de lo que no quiere olvidar.
Valor monetario. => Que cantidad de dinero esta involucrada en ese "secreto"
Fecha => En que fecha aprox paso esto.
Lugar => En donde paso.
Lat y Lng => coordenadas de done paso ese secreto.
La base de datos a usar sera SQLITE. y por esta via sube tu proyecto completo. Debe hacerse usando Blazor, puedes usar el IDE de tu preferencia.

Vamos que esta facil, no dejes pasar la oportunidad. Se que seguramente encontraras esta aplicación hecha en internet, pero anímate a aceptar el desafío de completar esta tarea y demostrarte a ti mismo que eres un estudiante de ITLA.

## comandos

- dotnet add package Microsoft.EntityFrameworkCore.Sqlite
- dotnet ef migrations add InitialCreate
- dotnet ef database update

### identity

- dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 5.0.0-rc.2.20475.17
- dotnet add package Microsoft.AspNetCore.Identity.UI --version 5.0.0-rc.2.20475.17

### seguridad manual

- dotnet add package BCrypt.Net-Core --version 1.6.0
- dotnet add package JsonWebToken *no usada*
- dotnet add package JWT.Extensions.AspNetCore --version 7.1.0-beta2
