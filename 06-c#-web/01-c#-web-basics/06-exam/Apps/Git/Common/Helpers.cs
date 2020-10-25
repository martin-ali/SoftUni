namespace Git.Common
{
    using System;

    public class Helpers
    {
        public static string NewId => Guid.NewGuid().ToString();
    }
}