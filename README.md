📚 Librería Don César – Sistema de Gestión

Un sistema de gestión integral para librerías, desarrollado en C# (.NET Framework / WinForms) con arquitectura en capas (Presentación, Negocio, Datos) y soporte de SQL Server para la persistencia de datos.

Este proyecto tiene como objetivo facilitar la administración de inventario, ventas, clientes y procesos clave dentro de una librería, ofreciendo una interfaz intuitiva y funcionalidades avanzadas para optimizar la gestión del negocio.

🚀 Características principales

✅ Gestión de inventario: registrar, actualizar y dar de baja productos.

✅ Gestión de clientes y proveedores.

✅ Procesamiento de ventas y compras.

✅ Reportes en base a transacciones y estadísticas.

✅ Arquitectura en capas para mejorar mantenibilidad y escalabilidad.

🏗️ Arquitectura del sistema

El sistema sigue el patrón multicapa:

CapaEntidad → Define las entidades y modelos de datos.

CapaDatos → Maneja la conexión con la base de datos y procedimientos almacenados.

CapaNegocios → Contiene la lógica de negocio y validaciones.

LibreriaDonCesarPresentacion → Capa de presentación (interfaz de usuario en Windows Forms).

🗄️ Base de datos

La solución incluye los scripts para crear la base de datos en SQL Server:

SISTEMALIBRERIA.sql → Creación de tablas y relaciones.

PROC SISTEMALIBRERIA.sql → Procedimientos almacenados para operaciones CRUD.

👉 Antes de ejecutar la aplicación, asegúrate de:

Crear la base de datos ejecutando los scripts.

Configurar la cadena de conexión en la capa de datos (CapaDatos).

⚙️ Instalación y configuración

Clonar el repositorio:

git clone https://github.com/williamcortez07/LibreriaDonCesarPresentacion.git


Abrir la solución en Visual Studio:

LibreriaDonCesarPresentacion.sln


Restaurar dependencias y compilar el proyecto.

Configurar la cadena de conexión a tu instancia de SQL Server.

Ejecutar el proyecto desde la capa de presentación.

📊 Requisitos

Visual Studio 2019 o superior

.NET Framework 4.7.2 o superior

SQL Server 2016 o superior

🤝 Contribuciones

Las contribuciones son bienvenidas. Si deseas colaborar:

Haz un fork del proyecto.

Crea una rama con tu nueva funcionalidad (git checkout -b feature/nueva-funcionalidad).

Realiza un commit con cambios claros.

Haz un pull request para revisión.
