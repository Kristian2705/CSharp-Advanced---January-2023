namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();
            graphicEditor.DrawShape(new Triangle());
        }
    }
}
