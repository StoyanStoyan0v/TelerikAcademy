using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DifferenceBetweenCSharpAndOtherLanguages
{
    class DifferenceBetweenCSharpAndOtherLanguages
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide a short list with information about the most popular programming        languages. How do they differ from C#?");
            Console.WriteLine();
            Console.WriteLine("Answer:");
            Console.WriteLine("By design, C# is the programming language that most directly reflects the        underlying Common Language Infrastructure (CLI). Most of its intrinsic types   correspond to value-types implemented by the CLI framework. However, the        language specification does not state the code generation requirements of  the  compiler: that is, it does not state that a C# compiler must target a Common    Language Runtime, or generate Common Intermediate Language (CIL), or generate   any other specific format. Theoretically, a C# compiler could generate machine  code like traditional compilers of C++ or Fortran..");
        }
    }
}
