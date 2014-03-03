using System;
using System.Collections.Generic;
using System.Linq;

public interface IDocument
{
    string Name { get; }

    string Content { get; }

    void LoadProperty(string key, string value);

    void SaveAllProperties(IList<KeyValuePair<string, object>> output);

    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }

    void Encrypt();

    void Decrypt();
}

public abstract class Document : IDocument
{
    private string name;

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Invalid file name!");
            }
            this.name = value;
        }
    }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
        {
            this.Name = value;
        }
        else if (key == "content")
        {
            this.Content = value;
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name",this.Name));
        output.Add(new KeyValuePair<string, object>("content",this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        properties.Sort((x,y) => x.Key.CompareTo(y.Key));

        return string.Format("{0}[{1}]", this.GetType().Name,
            string.Join(";", properties.Where(x => x.Value != null).Select(doc => string.Format("{0}={1}", doc.Key, doc.Value))));
    }
}

public class TextDocument : Document, IEditable
{
    public string Charset { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
        {
            this.Charset = value;
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
}

public class BinaryDocument : Document
{
    public ulong? Size { get; private set; }
    
    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
        {
            this.Size = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("size", this.Size));
    }
}

public class PDFDocument : BinaryDocument, IEncryptable
{
    public ulong? Pages { get; private set; }

    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
        {
            this.Pages = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
    }
}

public abstract class OfficeDocuments : BinaryDocument, IEncryptable, IEditable
{
    public string Version { get; private set; }

    public bool IsEncrypted { get; private set; }

    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }

    public override void LoadProperty(string key, string value)
    {
        if (key == "version")
        {
            this.Version = value;
        }
        base.LoadProperty(key, value);
    }

    public void ChangeContent(string name)
    {
        this.Content = name;
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("version", this.Version));
    }
}

public class WordDocument : OfficeDocuments
{
    public ulong? Chars { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
        {
            this.Chars = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
    }
}

public class ExcelDocument : OfficeDocuments
{
    public ulong? Rows { get; private set; }

    public ulong? Cols { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "rows")
        {
            this.Rows = ulong.Parse(value);
        }
        else if (key == "cols")
        {
            this.Cols = ulong.Parse(value);
        }
        
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("rows", this.Rows));
        output.Add(new KeyValuePair<string, object>("cols", this.Cols));
    }
}

public abstract class MultimediaDocuments : BinaryDocument
{
    public ulong? Length { get; private set; }
    
    public override void LoadProperty(string key, string value)
    {
        if (key == "length")
        {
            this.Length = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("length", this.Length));
    }
}

public class AudioDocument : MultimediaDocuments
{
    public ulong? SampleRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRate = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
    }
}

public class VideoDocument : MultimediaDocuments
{
    public ulong? FrameRate { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "framerate")
        {
            this.FrameRate = ulong.Parse(value);
        }
        base.LoadProperty(key, value);
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate));
    }
}

public static class DocumentSystem
{
    private static IList<IDocument> documents = new List<IDocument>();
    
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
  
    private static void AddTextDocument(string[] attributes)
    {
        AddDocument(new TextDocument(), attributes);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        AddDocument(new PDFDocument(), attributes);
    }

    private static void AddWordDocument(string[] attributes)
    {
        AddDocument(new WordDocument(), attributes);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        AddDocument(new ExcelDocument(), attributes);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        AddDocument(new AudioDocument(), attributes);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        AddDocument(new VideoDocument(), attributes);
    }

    private static void ListDocuments()
    {
        if (documents.Count == 0)
        {
            Console.WriteLine("No documents found");
        }
        else
        {
            foreach (var doc in documents)
            {
                if (doc is IEncryptable && ((IEncryptable)doc).IsEncrypted)
                {
                    Console.WriteLine("{0}[encrypted]", doc.GetType().Name);
                }
                else
                {
                    Console.WriteLine(doc);
                }
            }
        }
    }

    private static void EncryptDocument(string name)
    {
        bool isDocFound = false;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
                isDocFound = true;
            }
        }

        if (!isDocFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void DecryptDocument(string name)
    {
        bool isDocFound = false;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEncryptable)
                {
                    ((IEncryptable)doc).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
                isDocFound = true;
            }
        }

        if (!isDocFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool isDocFound = false;

        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                ((IEncryptable)doc).Encrypt();
                isDocFound = true;
            }
        }

        if (isDocFound)
        {
            Console.WriteLine("All documents encrypted");
        }
        else
        {
            Console.WriteLine("No encryptable documents found");
        }
    }

    private static void ChangeContent(string name, string content)
    {
        bool isDocFound = false;

        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                if (doc is IEditable)
                {
                    ((IEditable)doc).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
                isDocFound = true;
            }
        }

        if (!isDocFound)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void AddDocument(IDocument doc, string[]attributes)
    {
        foreach (var att in attributes)
        {
            string[] atts = att.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries);
            doc.LoadProperty(atts[0], atts[1]);
        }
        if (doc.Name != null)
        {
            documents.Add(doc);
            Console.WriteLine("Document added: {0}", doc.Name);
        }
        else
        {
            Console.WriteLine("Document has no name");
        }
    }
}