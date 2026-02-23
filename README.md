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
```

### 🏃 Ejecución y Primeros Pasos

Una vez configurada la base de datos, sigue estas instrucciones para interactuar con el sistema:

### 1. Iniciar la Aplicación
* **Desde Visual Studio:** Presiona `F5` (asegúrate de que ambos proyectos, API y Client, estén configurados como inicio).
* **Desde Terminal:** Ejecuta `dotnet run` en ambas carpetas. Por defecto, el cliente abrirá en `https://localhost:7123` (o similar).

### 2. Verificación de la API (Swagger)
Para confirmar que el backend está funcionando y explorar los endpoints disponibles:
* Navega a `https://localhost:[PUERTO_API]/swagger` (ej. `https://localhost:7001/swagger`).
* Aquí podrás probar manualmente los métodos GET, POST, PUT y DELETE de cada entidad.

### 3. Navegación en el Sistema
Una vez cargada la interfaz en el navegador:

1.  **Dashboard (Inicio):** Verás las estadísticas generales (Total de docentes, aulas, etc.) alimentadas por los datos de semilla (*Seed*).
2.  **Configuración:** Haz clic en el ícono de engranaje ⚙️ en el menú lateral.
    * **Pestaña Centro:** Actualiza el nombre y RNC de tu institución.
    * **Pestañas Maestras:** Navega entre Docentes, Aulas y Asignaturas para agregar nuevos registros.
3.  **Gestión de Horarios:** Ve a la sección de "Horarios" para visualizar el calendario semanal. Los bloques se mostrarán organizados por día y hora.

---

## 🛠️ Guía de Uso Post-Setup

### ¿Cómo agregar un nuevo Horario?
Para que el sistema registre un bloque de clase correctamente, sigue este flujo lógico:
1.  **Crea el Aula:** Asegúrate de que el código del salón (ej: "Lab-02") exista.
2.  **Crea el Docente:** Registra al profesor y su especialidad.
3.  **Asigna la Materia:** Define la asignatura y sus horas semanales.
4.  **Genera el Bloque:** En la pantalla de Horarios, selecciona los elementos creados anteriormente y define el rango de tiempo.


---

## 🔍 Solución de Problemas Comunes

* **Error de Conexión SQL:** Si el programa falla al iniciar, verifica que el servicio de SQL Server esté corriendo y que el nombre de la instancia en `appsettings.json` sea correcto.
* **Pantalla en Blanco (Client):** Revisa la consola del navegador (F12). Si ves errores de CORS, asegúrate de que el proyecto API esté corriendo antes que el Client.
* **Datos no aparecen:** Si las tablas están vacías, ejecuta `dotnet ef database update` nuevamente para asegurar que el *Seeding* se haya aplicado.