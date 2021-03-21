using System;
using System.Collections.Generic;
using System.Linq;

namespace MyBank.Domain
{
    public static class ExceptionCatcher
    {
        private static List<Exception> exceptions = new List<Exception>();

        public static void add(Exception e)
        {
            exceptions.Add(e);
        }

        public static void viewAllExceptionsMessagen()
        {
            if(countException() > 0)
            {
                Console.WriteLine("\nMessage Exception:");
                foreach (Exception e in exceptions)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("\n");
            }
            clean();
        }

        public static int countException()
        {
            return exceptions.Count();
        }

        public static void clean()
        {
            exceptions = new List<Exception>();
        }

        
    }
}
