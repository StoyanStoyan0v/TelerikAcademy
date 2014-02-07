namespace ExtensionSubstring
{
    using System.Text;

    public static class Extension
    {

        public static StringBuilder Substring (this StringBuilder sb,int index, int length)
        {
            return new StringBuilder(sb.ToString().Substring(index, length));
        }
    }
}
