Evidence Integrity Verifier / Verificador de Integridad de Evidencia

Console application built in C# (.NET 8) that implements a basic forensic integrity verification workflow using the SHA-256 cryptographic hash function.

Aplicación de consola desarrollada en C# (.NET 8) que implementa un flujo básico de verificación de integridad forense utilizando la función hash criptográfica SHA-256.

🇪🇸 Versión en Español
Descripción

Esta herramienta calcula el hash SHA-256 de un archivo digital y lo compara contra un hash de referencia para verificar si el archivo ha sido modificado.

El proyecto está orientado a contextos de informática forense y preservación de evidencia digital.

Características actuales

Cálculo de hash SHA-256 utilizando FileStream (lectura en streaming).

Comparación case-insensitive con hash esperado.

Validación de existencia del archivo.

Manejo básico de excepciones.

Visualización de metadata del archivo (nombre, tamaño y fecha de análisis).

Importancia en el ámbito forense

La verificación de integridad es fundamental en informática forense porque permite:

Preservar la cadena de custodia.

Detectar alteraciones no autorizadas.

Mantener la validez legal de la evidencia digital.

Garantizar reproducibilidad del análisis técnico.

El uso de funciones hash criptográficas asegura que cualquier modificación genere un valor hash completamente diferente.

Limitaciones actuales

No genera un reporte persistente en archivo.

No implementa firma digital del resultado.

No incluye sistema de auditoría.

No reemplaza herramientas forenses certificadas.

Este proyecto tiene fines educativos y demostrativos.

🇬🇧 English Version
Description

This tool calculates the SHA-256 hash of a digital file and compares it against a reference hash to verify whether the file has been modified.

The project is oriented toward digital forensics and evidence integrity validation contexts.

Current Features

SHA-256 hash calculation using streaming (FileStream).

Case-insensitive comparison with expected hash.

File existence validation.

Basic exception handling.

File metadata display (name, size, analysis timestamp).

Why It Matters

Integrity verification is fundamental in digital forensics because it allows investigators to:

Preserve chain of custody.

Detect unauthorized modifications.

Maintain legal validity of digital evidence.

Ensure reproducibility of technical analysis.

Technologies Used

C#

.NET 8

System.Security.Cryptography

Git (version control)

Future Improvements

Support additional hash algorithms (e.g., SHA-512).

Export verification report to JSON or TXT.

Add command-line argument support.

Use UTC timestamps.

Implement digital signature of generated reports.



How to Run / Cómo Ejecutar
🇪🇸 Ejecución

Clonar el repositorio:

git clone https://github.com/TU_USUARIO/IntegridadDeEvidencia.git


Ingresar al directorio del proyecto:

cd IntegridadDeEvidencia


Restaurar dependencias (si es necesario):

dotnet restore


Ejecutar la aplicación:

dotnet run


Ingresar la ruta del archivo cuando el programa lo solicite.

🇬🇧 Execution

Clone the repository:

git clone https://github.com/YOUR_USERNAME/IntegridadDeEvidencia.git


Navigate to the project directory:

cd IntegridadDeEvidencia


Restore dependencies (if required):

dotnet restore


Run the application:

dotnet run


Enter the file path when prompted.


Technical Notes / Notas Técnicas
🇬🇧 English

All timestamps are displayed in UTC to ensure consistency and avoid timezone-related discrepancies in forensic analysis.

On some Windows systems, Last Access Time may be disabled by default for performance reasons.
In those cases, the value may not accurately reflect recent file access activity.

The tool computes the hash directly from the file stream, ensuring the integrity calculation is performed on the exact file contents at the time of analysis.

SHA-256 is used as the primary integrity algorithm due to its strong collision resistance and widespread forensic acceptance.

🇪🇸 Español

Todas las marcas de tiempo se muestran en UTC para garantizar consistencia y evitar discrepancias relacionadas con zonas horarias en análisis forense.

En algunos sistemas Windows, la opción de Último Acceso (Last Access Time) puede estar deshabilitada por razones de rendimiento.
En esos casos, el valor podría no reflejar accesos recientes reales al archivo.

El hash se calcula directamente desde el flujo del archivo (file stream), asegurando que la verificación se realiza sobre el contenido exacto en el momento del análisis.

Se utiliza SHA-256 como algoritmo principal de integridad debido a su alta resistencia a colisiones y su amplia aceptación en el ámbito forense.


Author

Esteban González
Software Engineer
Argentina