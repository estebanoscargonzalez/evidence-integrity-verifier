using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Evidence Integrity Verifier ===\n");

        Console.Write("Ingrese la ruta del archivo: ");
        string path = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
        {
            Console.WriteLine("\n[ERROR] El archivo no existe o la ruta es inválida.");
            Console.WriteLine("Presione cualquier tecla para salir...");
            Console.ReadKey(true);
            return;
        }

        try
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("\n--- Metadatos del Archivo ---");
            Console.WriteLine($"Nombre: {fileInfo.Name}");
            Console.WriteLine($"Ruta absoluta: {fileInfo.FullName}");
            Console.WriteLine($"Tamaño: {fileInfo.Length} bytes");

            Console.WriteLine($"Fecha de creación (UTC): {fileInfo.CreationTimeUtc:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Última modificación (UTC): {fileInfo.LastWriteTimeUtc:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"Último acceso (UTC): {fileInfo.LastAccessTimeUtc:yyyy-MM-dd HH:mm:ss}");

            Console.WriteLine($"Fecha y hora de análisis (UTC): {DateTime.UtcNow:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine();

            string sha256Hash = ComputeSha256(path);

            Console.WriteLine("--- Hashes Calculados ---");
            Console.WriteLine($"SHA256: {sha256Hash}");
            
            Console.WriteLine();

            Console.Write("Ingrese hash SHA256 esperado (opcional): ");
            string expectedHash = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(expectedHash))
            {
                if (sha256Hash.Equals(expectedHash, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("\n[OK] Integridad verificada. Los hashes coinciden.");
                }
                else
                {
                    Console.WriteLine("\n[ALERTA] El hash NO coincide. Posible alteración.");
                }
            }
            else
            {
                Console.WriteLine("No se ingresó hash esperado.");
            }

            Console.WriteLine("\nReporte generado.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[ERROR] Ocurrió una excepción: {ex.Message}");
        }

        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey(true);
    }

    static string ComputeSha256(string path)
    {
        using FileStream stream = File.OpenRead(path);
        using SHA256 sha = SHA256.Create();
        byte[] hash = sha.ComputeHash(stream);
        return Convert.ToHexString(hash).ToLowerInvariant();
    }
}