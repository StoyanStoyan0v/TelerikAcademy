using System;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Collections.Generic;

namespace HTMLRenderer
{
    public interface IElement
    {
        string Name { get; }

        string TextContent { get; set; }

        IEnumerable<IElement> ChildElements { get; }

        void AddElement(IElement element);

        void Render(StringBuilder output);

        string ToString();
    }

    public interface ITable : IElement
    {
        int Rows { get; }

        int Cols { get; }

        IElement this[int row, int col] { get; set; }
    }

    public interface IElementFactory
    {
        IElement CreateElement(string name);

        IElement CreateElement(string name, string content);

        ITable CreateTable(int rows, int cols);
    }

    public class Element : IElement
    {
        private readonly IList<IElement> childElements;

        public Element(string name, string content=null)
        {
            this.childElements = new List<IElement>();
            this.Name = name;
            this.TextContent = content;
        }

        public string Name { get; private set; }

        public string TextContent { get; set; }

        public IEnumerable<IElement> ChildElements
        {
            get
            {
                return this.childElements;
            }
        }

        public void AddElement(IElement element)
        {
            if (element.Name != null)
            {
                this.childElements.Add(element);
            }
        }

        public virtual void Render(StringBuilder output)
        {
            StringBuilder content = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(this.TextContent))
            {
                for (int i = 0; i < this.TextContent.Length; i++)
                {
                    char symbol = this.TextContent[i];
                    switch (symbol)
                    {
                        case '<':
                            content.Append("&lt;");
                            break;
                        case '>':
                            content.Append("&gt;");
                            break;
                        case '&':
                            content.Append("&amp;");
                            break;
                        default:
                            content.Append(symbol);
                            break;
                    }
                }
            }
            output.AppendFormat("{0}{1}{2}{3}", !string.IsNullOrWhiteSpace(this.Name) ? "<"+this.Name+">" : null,
                content, string.Join("", this.ChildElements), !string.IsNullOrWhiteSpace(this.Name) ? "</"+this.Name+">" : null);
        }
        
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            
            this.Render(output);

            return output.ToString();
        }
    }

    public class Table : Element, ITable
    {
        private const string TableName = "table";
        private readonly IElement[,] table;
        private int rows;
        private int cols;
        
        public Table(int rows, int cols) : base(TableName)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.table = new IElement[this.Rows, this.Cols];
        }

        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Table rows cannot be negative");
                }
                this.rows = value;
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Table cols cannot be negative");
                }
                this.cols = value;
            }
        }

        public IElement this[int row, int col]
        {
            get
            {
                this.ValidateIndecies(row, col);
                return this.table[row, col];
            }
            set
            {
                this.ValidateIndecies(row, col);
                if (value == null)
                {
                    throw new ArgumentNullException("HTML element in table cell cannot be null!");
                }
                this.table[row, col] = value;
            }
        }

        public override void Render(StringBuilder output)
        {
            output.AppendFormat("<{0}>", this.Name);
            for (int row = 0; row < this.Rows; row++)
            {
                output.Append("<tr>");
                for (int col = 0; col < this.Cols; col++)
                {
                    output.Append("<td>" + this.table[row, col] + "</td>");
                }
                output.Append("</tr>"); 
            }
            output.AppendFormat("</{0}>", this.Name);
        }

        private void ValidateIndecies(int row, int col)
        {
            if (row < 0 || row >= this.Rows)
            {
                throw new IndexOutOfRangeException("Provided row is out of the boundaries of the HTML table!");
            }

            if (col < 0 || col >= this.Cols)
            {
                throw new IndexOutOfRangeException("Provided column is out of the boundaries of the HTML table!");
            }
        }
    }

    public class HTMLElementFactory : IElementFactory
    {
        public IElement CreateElement(string name)
        {
            return new Element(name);
        }

        public IElement CreateElement(string name, string content)
        {
            return new Element(name, content);
        }

        public ITable CreateTable(int rows, int cols)
        {
            return new Table(rows, cols);
        }
    }

    public class HTMLRendererCommandExecutor
    {
        static void Main()
        {
            string csharpCode = ReadInputCSharpCode();
            CompileAndRun(csharpCode);
        }

        private static string ReadInputCSharpCode()
        {
            StringBuilder result = new StringBuilder();
            string line;
            while ((line = Console.ReadLine()) != "")
            {
                result.AppendLine(line);
            }
            return result.ToString();
        }

        static void CompileAndRun(string csharpCode)
        {
            // Prepare a C# program for compilation
            string[] csharpClass =
            {
                @"using System;
                  using HTMLRenderer;

                  public class RuntimeCompiledClass
                  {
                     public static void Main()
                     {" +
                csharpCode + @"
                     }
                  }"
            };

            // Compile the C# program
            CompilerParameters compilerParams = new CompilerParameters();
            compilerParams.GenerateInMemory = true;
            compilerParams.TempFiles = new TempFileCollection(".");
            compilerParams.ReferencedAssemblies.Add("System.dll");
            compilerParams.ReferencedAssemblies.Add(Assembly.GetExecutingAssembly().Location);
            CSharpCodeProvider csharpProvider = new CSharpCodeProvider();
            CompilerResults compile = csharpProvider.CompileAssemblyFromSource(
                compilerParams, csharpClass);

            // Check for compilation errors
            if (compile.Errors.HasErrors)
            {
                string errorMsg = "Compilation error: ";
                foreach (CompilerError ce in compile.Errors)
                {
                    errorMsg += "\r\n" + ce.ToString();
                }
                throw new Exception(errorMsg);
            }

            // Invoke the Main() method of the compiled class
            Assembly assembly = compile.CompiledAssembly;
            Module module = assembly.GetModules()[0];
            Type type = module.GetType("RuntimeCompiledClass");
            MethodInfo methInfo = type.GetMethod("Main");
            methInfo.Invoke(null, null);
        }
    }
}