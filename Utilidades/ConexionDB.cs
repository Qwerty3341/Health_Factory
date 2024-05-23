﻿using System.Runtime.InteropServices;

namespace Health_Factory.Utilidades
{
    public static class ConexionDB
    {
        public static string DevolverRuta(string nombreBaseDatos)
        {
            string rutaBaseDatos = string.Empty;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                string directorioDatos = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBaseDatos = Path.Combine(directorioDatos, nombreBaseDatos);
            }
            else if (DeviceInfo.Platform == DevicePlatform.Android)
            {
                rutaBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                rutaBaseDatos = Path.Combine(rutaBaseDatos, nombreBaseDatos);
            }
            else if (DeviceInfo.Platform == DevicePlatform.iOS)
            {
                rutaBaseDatos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                rutaBaseDatos = Path.Combine(rutaBaseDatos, "..", "Library", nombreBaseDatos);
            }
            return rutaBaseDatos;
        }
    }

}
