📚 Librería Don César – Sistema de Gestión
Un sistema de gestión integral para librerías, desarrollado en C# (.NET Framework / WinForms) con arquitectura en capas (Presentación, Negocio, Datos) y soporte de SQL Server para la persistencia de datos.

Este proyecto tiene como objetivo facilitar la administración de inventario, ventas, clientes y procesos clave dentro de una librería, ofreciendo una interfaz intuitiva y funcionalidades avanzadas para optimizar la gestión del negocio.

🚀 Características principales
✅ Gestión de inventario: Registrar, actualizar y dar de baja productos.

✅ Gestión de clientes y proveedores: Administrar la información de contacto y el historial de transacciones.

✅ Procesamiento de ventas y compras: Registrar transacciones de manera eficiente.

✅ Reportes y estadísticas: Generar informes basados en transacciones para la toma de decisiones.

✅ Arquitectura en capas: Diseño que mejora la mantenibilidad y escalabilidad del software.

🏗️ Arquitectura del sistema
El sistema sigue un patrón de diseño multicapa para separar responsabilidades y facilitar su mantenimiento:

CapaEntidad: Define las entidades y modelos de datos que se utilizan en toda la aplicación.

CapaDatos: Se encarga de toda la interacción con la base de datos, incluyendo la conexión y la ejecución de procedimientos almacenados.

CapaNegocios: Contiene toda la lógica de negocio, reglas y validaciones del sistema.

LibreriaDonCesarPresentacion: Es la capa de presentación (interfaz de usuario), desarrollada con Windows Forms.

🗄️ Base de datos
La solución incluye los scripts necesarios para configurar la base de datos en SQL Server.

SISTEMALIBRERIA.sql: Script para la creación de las tablas, relaciones y la estructura general de la base de datos.

PROC SISTEMALIBRERIA.sql: Script que contiene todos los procedimientos almacenados para las operaciones CRUD (Crear, Leer, Actualizar, Eliminar).

👉 Importante: Antes de ejecutar la aplicación, asegúrate de:

Crear la base de datos ejecutando los scripts en el orden mencionado.

Configurar correctamente la cadena de conexión (connection string) en la CapaDatos para que apunte a tu instancia de SQL Server.

⚙️ Instalación y configuración
Sigue estos pasos para poner en marcha el proyecto en tu entorno local:

Clonar el repositorio:

Bash

git clone https://github.com/williamcortez07/LibreriaDonCesarPresentacion.git
Abrir la solución:
Abre el archivo LibreriaDonCesarPresentacion.sln con Visual Studio.

Restaurar y compilar:
Restaura los paquetes NuGet necesarios y compila la solución para asegurar que no haya errores.

Configurar la base de datos:
Ejecuta los scripts SQL proporcionados y ajusta la cadena de conexión en el proyecto CapaDatos.

Ejecutar el proyecto:
Establece LibreriaDonCesarPresentacion como proyecto de inicio y ejecuta la aplicación.

📊 Requisitos
IDE: Visual Studio 2019 o superior

Framework: .NET Framework 4.7.2 o superior

Base de datos: SQL Server 2016 o superior

🤝 Contribuciones
Las contribuciones son siempre bienvenidas. Si deseas colaborar con el proyecto, por favor sigue estos pasos:

Haz un Fork del proyecto.

Crea una nueva rama para tu funcionalidad (git checkout -b feature/nueva-funcionalidad).

Realiza un Commit con tus cambios (git commit -m 'Agrega nueva funcionalidad').

Haz un Push a tu rama (git push origin feature/nueva-funcionalidad).

Abre un Pull Request para que tus cambios puedan ser revisados.
