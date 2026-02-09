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

            Console.WriteLine("\n--- Información del Archivo ---");
            Console.WriteLine($"Nombre: {fileInfo.Name}");
            Console.WriteLine($"Tamaño: {fileInfo.Length} bytes");
            Console.WriteLine($"Fecha análisis: {DateTime.Now}");
            Console.WriteLine();

            string sha256Hash = ComputeHash(path, SHA256.Create());
            string md5Hash = ComputeHash(path, MD5.Create());

            Console.WriteLine("--- Hashes Calculados ---");
            Console.WriteLine($"SHA256: {sha256Hash}");
            Console.WriteLine($"MD5   : {md5Hash}");
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

    static string ComputeHash(string path, HashAlgorithm algorithm)
    {
        using (algorithm)
        using (FileStream stream = File.OpenRead(path))
        {
            byte[] hash = algorithm.ComputeHash(stream);
            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
