# Seele — Sistema de gestión de ventas de indumentaria con reportes FastReport

> Trabajo Práctico de **Lenguajes de Última Generación** · Facultad de Tecnología Informática · 2026
> Profesor: Ing. Darío Cardacci
> Repositorio: <https://github.com/Ozhammar/TP-Fast-Report>

---

## Índice

1. [About](#1-about)
2. [Paradigma y arquitectura](#2-paradigma-y-arquitectura)
3. [FastReport](#3-fastreport)
4. [Guía de instalación](#4-guía-de-instalación)
5. [About us](#5-about-us)

---

## 1. About

**Seele** es una aplicación de escritorio (Windows Forms, C# / .NET 10) que registra y analiza las ventas de un comercio de indumentaria.

**Qué problema resuelve.** El comercio vende prendas por dos canales (online y presencial), con distintos medios de pago, y necesita saber qué vende, a quién, cuánto factura y con qué stock cuenta. Seele centraliza esa información en una base de datos SQL Server y la convierte en reportes de gestión.

**Qué hace.**

| Módulo | Funcionalidad |
|---|---|
| Clientes | Alta, baja, modificación y consulta, con tipo de documento (DNI, CUIT, CUIL) y uno o más teléfonos. |
| Prendas | Catálogo en el que cada combinación de prenda, color y talle es una variante con su propio código, precio y stock. |
| Ventas | Registro de ventas con detalle, tipo de venta (online/presencial), medio de pago y estado. Al registrar una venta se descuenta el stock de forma transaccional (todo o nada). |
| Facturas | Una venta confirmada, despachada o entregada puede tener como máximo una factura (Emitida, Pagada, Anulada). |
| Reportes | Cinco reportes de gestión con vista previa en pantalla y exportación a PDF (ver [sección 3](#3-fastreport)). |

**Base de datos.** SQL Server, base `Seele`: 15 tablas en tercera forma normal, con restricciones de integridad (PK, FK, CHECK, índice único filtrado) y vistas `vw_*` que alimentan los reportes. El modelo no incluye usuarios ni roles: está pensado para un único operador del comercio.

**Estructura de la solución** (`TP - Fast Report.slnx`):

```
TP - Fast Report/
├── Entidades/          Clases de dominio, enums y la jerarquía de Reporte
├── DAO/                Acceso a datos (ADO.NET)
├── ORM/                Mappers: DataTable → objetos de Entidades
├── BLL/                Lógica de negocio y validaciones
├── Vista/              Windows Forms (UI MDI) + plantillas Reportes/*.frx
├── FastReport Designer/  Designer Community para editar las plantillas
└── BackUp DB SQL-Server.rar   Backup de la base Seele con datos de prueba
```

---

## 2. Paradigma y arquitectura

### Paradigma: Programación Orientada a Objetos

El sistema está modelado con POO sobre C#:

- **Encapsulamiento:** cada entidad (`Cliente`, `Prenda`, `Venta`, `DetalleVenta`, `Factura`) resguarda su estado y sus reglas. Por ejemplo, `Venta` le pide a cada `Prenda` que descuente su propio stock.
- **Herencia y clases abstractas:** `SQLKit` es la base abstracta de todos los DAO (conexión y comando compartidos) y `Reporte` es la base abstracta de los reportes.
- **Polimorfismo:** `Reporte` define `Tipo`, `Titulo`, `Archivo`, `Fuente` y `definirEncabezados()` como miembros abstractos, y cada subclase los resuelve. La UI trabaja siempre con `Reporte`, sin saber cuál es. Agregar un reporte nuevo implica crear una subclase, una vista SQL y una plantilla `.frx`, sin tocar el código existente.

### Arquitectura: cinco capas

Cada capa es un proyecto (ensamblado) independiente. Cada una solo referencia a la capa inferior y al proyecto transversal `Entidades`.

```
┌──────────────────────────────┐
│  Vista    (Windows Forms)    │  Formularios, captura de datos, lanza reportes
├──────────────────────────────┤
│  BLL      (Lógica de negocio)│  Validaciones, reglas de stock, catálogo de reportes
├──────────────────────────────┤
│  ORM      (Mappers)          │  DataTable → objetos de dominio
├──────────────────────────────┤
│  DAO      (Acceso a datos)   │  ADO.NET: SqlConnection/SqlCommand, consultas parametrizadas, transacciones
├──────────────────────────────┤
│  SQL Server  (base Seele)    │  15 tablas + vistas vw_*
└──────────────────────────────┘
   Entidades: proyecto transversal usado por todas las capas
```

Flujo de ejemplo al generar un reporte:
`vistaReportes → ReporteBLL.GenerarReporte() → ReporteMapper → ReporteDAO (vw_* → DataTable) → Reporte.exportarPDF()`

El acceso a datos usa ADO.NET en **modo conectado**: la conexión se abre lo más tarde posible y se cierra siempre en un bloque `finally`.

---

## 3. FastReport

### Qué es

[FastReport Open Source](https://github.com/FastReports/FastReport) es una librería .NET de generación de reportes **orientada a bandas** (licencia MIT). Los reportes se diseñan como plantillas XML (`.frx`) que luego se llenan con datos en tiempo de ejecución y se exportan a distintos formatos.

En Seele se usa para convertir los datos de la base en documentos **PDF** listos para imprimir o compartir.

### Cómo está implementado

- **Plantillas:** `Vista/Reportes/*.frx`, diseñadas con FastReport Designer Community (incluido en la carpeta `FastReport Designer/`). Se copian automáticamente al directorio de salida al compilar.
- **Bandas utilizadas:** Report Title, Page Header, Group Header, Data, Group Footer, Report Summary y Page Footer, con subtotales y total general, filas alternadas por color y formato condicional (por ejemplo, stock bajo en rojo).
- **Datos:** cada reporte se alimenta de una vista SQL (`vw_*`). El `ReporteDAO` ejecuta la consulta, devuelve un `DataTable` y la plantilla lo recibe vía `RegisterData`. El reporte no conoce la cadena de conexión.
- **Exportación:** `Reporte.exportarPDF()` ejecuta `Load` (plantilla) → `RegisterData` (datos) → `Prepare` → `Export` con `PDFSimpleExport`.
- **Vista previa:** la versión open source no incluye un visor integrable en Windows Forms, por lo que la vista previa de los datos se muestra en un `DataGridView` y el PDF generado se abre con el visor del sistema.

### Reportes disponibles

| # | Reporte | Plantilla | Vista SQL | Qué muestra |
|---|---|---|---|---|
| 1 | Ventas por período | `VentasPorPeriodo.frx` | `vw_ventas_por_periodo` | Ventas y montos por año, mes, tipo de venta y medio de pago. |
| 2 | Prendas más vendidas | `PrendasMasVendidas.frx` | `vw_prendas_mas_vendidas` | Unidades y monto vendido por variante de prenda. |
| 3 | Ranking de clientes | `RankingClientes.frx` | `vw_ranking_clientes` | Clientes ordenados por monto comprado. |
| 4 | Facturación por período | `FacturacionPorPeriodo.frx` | `vw_facturacion_por_periodo` | Cantidad e importe de facturas por mes y estado. |
| 5 | Stock disponible | `StockDisponible.frx` | `vw_stock_disponible` | Stock actual por variante y precio de catálogo. |

### Cómo usarlo

1. Ejecutar la aplicación y abrir **Reportes** desde el menú principal.
2. Elegir un reporte en el combo: se muestra la vista previa de los datos en la grilla.
3. Presionar **Generar**, elegir dónde guardar el archivo y confirmar. El nombre sugerido incluye fecha y hora (`<Reporte>_yyyyMMdd_HHmm.pdf`).
4. Opcionalmente, abrir el PDF generado desde el mensaje de confirmación.

Para modificar el diseño de un reporte, abrir el `.frx` correspondiente con `FastReport Designer/Designer.exe`.

---

## 4. Guía de instalación

### 4.1 Requisitos previos

| Requisito | Detalle |
|---|---|
| Sistema operativo | Windows (el proyecto apunta a `net10.0-windows` y usa Windows Forms). |
| .NET SDK | **.NET 10 SDK** |
| IDE | Visual Studio con la carga de trabajo *Desarrollo de escritorio de .NET*. Debe ser una versión que soporte el formato de solución `.slnx` y .NET 10. |
| Base de datos | **SQL Server** (la edición Express alcanza) |
| Herramienta SQL | SQL Server Management Studio (SSMS) o equivalente, para restaurar el backup. |
| Extractor de archivos | Para descomprimir el `.rar` del backup (7-Zip, WinRAR, etc.). |
| Internet | Solo la primera vez, para restaurar los paquetes NuGet. |

### 4.2 Paquetes NuGet

Se restauran automáticamente al compilar. Versiones utilizadas:

| Paquete | Versión | Usado en |
|---|---|---|
| `FastReport.OpenSource` | 2027.1.0 | Entidades, DAO, ORM, BLL, Vista |
| `FastReport.OpenSource.Export.PdfSimple` | 2027.1.0 | Entidades, DAO, ORM, BLL, Vista |
| `Microsoft.Data.SqlClient` | 7.1.1 | DAO |

Instalación manual, si hiciera falta (desde la Consola del Administrador de paquetes):

```powershell
Install-Package FastReport.OpenSource -Version 2027.1.0
Install-Package FastReport.OpenSource.Export.PdfSimple -Version 2027.1.0
Install-Package Microsoft.Data.SqlClient -Version 7.1.1
```

### 4.3 Pasos

**1. Obtener el código**

```bash
git clone https://github.com/Ozhammar/TP-Fast-Report.git
```

O copiar la carpeta `TP - Fast Report` de la entrega.

**2. Restaurar la base de datos**

1. Descomprimir `BackUp DB SQL-Server.rar`.
2. En SSMS: clic derecho en *Databases* → *Restore Database…* → *Device* → seleccionar el archivo de backup.
3. Nombrar la base de datos **`Seele`** (el nombre debe coincidir con el de la cadena de conexión).

La base incluye datos de prueba: 10 clientes, 13 variantes de prendas, 25 ventas y 19 facturas.

**3. Verificar la cadena de conexión**

Está definida en `DAO/SQLKit.cs`:

```csharp
new SqlConnection("Data Source=.;Initial Catalog=Seele;Integrated Security=True;Trust Server Certificate=True");
```

Usa la instancia local por defecto (`.`) con autenticación de Windows. Si SQL Server está instalado como instancia con nombre (por ejemplo, Express), cambiar `Data Source=.` por `Data Source=.\SQLEXPRESS` (o el nombre de la instancia).

**4. Abrir y compilar la solución**

- Con Visual Studio: abrir `TP - Fast Report.slnx`, establecer **Vista** como proyecto de inicio y compilar (`Ctrl + Shift + B`).
- Con la CLI de .NET:

```bash
cd "TP - Fast Report"
dotnet restore "TP - Fast Report.slnx"
dotnet build "TP - Fast Report.slnx" -c Release
```

**5. Ejecutar**

- Con Visual Studio: `F5`.
- Con la CLI: `dotnet run --project Vista/Vista.csproj`.

Desde el menú principal se accede a Clientes, Prendas, Ventas, Facturas y Reportes.

### 4.4 Problemas frecuentes

| Síntoma | Causa probable | Solución |
|---|---|---|
| Error de conexión al abrir un formulario | SQL Server apagado, o instancia o nombre de base distintos | Iniciar el servicio de SQL Server y revisar `DAO/SQLKit.cs`. |
| `No se encontró la plantilla del reporte` | Falta el `.frx` en la carpeta de salida | Recompilar la solución: los `.frx` de `Vista/Reportes` se copian al compilar. |
| Fallan los paquetes NuGet | Sin conexión o origen de paquetes sin configurar | Verificar que `nuget.org` esté habilitado como origen y ejecutar `dotnet restore`. |
| Visual Studio no abre el `.slnx` | Versión antigua del IDE | Actualizar Visual Studio o compilar con la CLI de .NET 10. |

---

## 5. About us

Somos estudiantes de la **Facultad de Tecnología Informática** y desarrollamos este proyecto en conjunto para la materia **Lenguajes de Última Generación** (2026), a cargo del Ing. Darío Cardacci.

| Integrante | Rol en el proyecto |
|---|---|
| **Federico Dermisache** | Desarrollador |
| **Mateo Masci** | Desarrollador |
| **Lucas Povolo** | Desarrollador |

Repositorio del proyecto: <https://github.com/Ozhammar/TP-Fast-Report>

---

<sub>Seele · Lenguajes de Última Generación . Facultad de Tecnología Informática · 2026</sub>
