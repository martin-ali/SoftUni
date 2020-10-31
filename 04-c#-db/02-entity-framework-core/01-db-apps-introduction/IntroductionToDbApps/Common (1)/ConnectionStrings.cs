using System;

namespace Common
{
    public class ConnectionStrings
    {
        private const string Template = "Server=NOTEBOOK-WIN;Database={0};Integrated Security=true";
        public static readonly string MasterDB = string.Format(Template, "Master");
        public static readonly string MinionsDB = string.Format(Template, "MinionsDB");
    }
}
