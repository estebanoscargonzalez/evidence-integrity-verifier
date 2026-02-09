# Evidence Integrity Verifier

Console application built in C# (.NET 8) to generate SHA-256 hashes for digital files and verify integrity against an expected hash.

## Purpose

This tool simulates a basic forensic workflow:
- Generate cryptographic hash (SHA-256)
- Compare with known reference hash
- Detect file modification

## Why it matters

In digital forensics, verifying file integrity is essential to:
- Preserve chain of custody
- Ensure evidence was not altered
- Maintain legal validity

## Technologies Used

- C#
- .NET 8
- System.Security.Cryptography
- Git for version control

## Future Improvements

- Add MD5 and SHA-1 support
- Export report to file
- Accept command-line arguments
