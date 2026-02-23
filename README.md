# 📅 HorarioEducativoWeb - Sistema de Gestión Escolar

**HorarioEducativoWeb** es una plataforma integral diseñada para centralizar la gestión de horarios académicos, recursos físicos y personal docente en centros educativos. Esta herramienta permite a los administradores organizar la carga horaria de manera eficiente, evitando conflictos y asegurando la integridad de los datos institucionales.

---

## 🚀 Tecnologías Utilizadas

* **Backend:** .NET 8 Web API
* **Frontend:** Blazor WebAssembly
* **Base de Datos:** SQL Server
* **ORM:** Entity Framework Core (Code-First)
* **Estilos:** Bootstrap 5 & Bootstrap Icons

---

## 🛠️ Requisitos del Sistema

Antes de iniciar, asegúrate de tener instalados los siguientes componentes:

1.  **SDK de .NET 8.0:** [Descargar aquí](https://dotnet.microsoft.com/download/dotnet/8.0)
2.  **SQL Server:** LocalDB (incluido en Visual Studio) o SQL Server Express.
3.  **Entity Framework Core Tools:** Instálalos mediante la terminal:
    ```bash
    dotnet tool install --global dotnet-ef
    ```

---

## ⚙️ Configuración e Instalación

Sigue estos pasos para poner en marcha el entorno de desarrollo:

### 1. Preparación de la Base de Datos
Tienes dos opciones para inicializar la estructura y los datos de prueba (*Seeding*):

* **Vía Migraciones (Recomendado):**
    Abre una terminal en la carpeta del proyecto `HorarioEducativoWeb.API` y ejecuta:
    ```bash
    dotnet ef database update
    ```
* **Vía Script SQL:**
    Ejecuta el archivo `Entrega_BaseDeDatos.sql` incluido en la carpeta de documentación en tu manejador de base de datos (SSMS).

### 2. Cadena de Conexión
Verifica el archivo `appsettings.json` en el proyecto **API**. Ajusta el `Server` si tu instancia de SQL Server tiene un nombre distinto:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=HorarioEducativoDb;Trusted_Connection=True;"
}