﻿namespace Program;

using ClassLibrary;

/// <summary>
/// Un programa que implementa un bot de Discord.
/// </summary>
internal static class Program
{
    /// <summary>
    /// Punto de entrada al programa.
    /// </summary>
    private static void Main()
    {
        BotLoader.LoadAsync().GetAwaiter().GetResult();
    }
}
 