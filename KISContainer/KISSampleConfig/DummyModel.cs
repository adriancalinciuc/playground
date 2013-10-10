using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KISSampleConfig
{
    #region Model Representation
    public class DummyModel
    {
        public DummyModel()
        {
            var window = new Window();
            var grid = new Grid();
            var panel = new Panel();
            var button = new Button();
            var textBox= new TextBox();
            var outher = new TextBox();
            window.AddChild(grid);
            grid.AddChild(panel);
            grid.AddChild(button);
            panel.AddChild(textBox);
        }
    }

    #endregion


    #region ModelElements


    public class Window : VisualElement
    {


    }

    public class Panel : VisualElement
    {

    }

    public class Grid : VisualElement
    {

    }

    public class TextBox : VisualElement
    {

    }

    public class Button : VisualElement
    {


    }
    #endregion


    #region Model Abstractization
    public interface IVisualElement
    {
        void AddChild(IVisualElement child);
        void AddParent(IVisualElement parent);

    }

    public class VisualElement : IVisualElement
    {
        private readonly List<IVisualElement> childs;
        IVisualElement parent;

        public VisualElement()
        {
            childs = new List<IVisualElement>();
        }

        public string Name { get; set; }

        public void AddChild(IVisualElement child)
        {
            this.childs.Add(child);
        }

        public void AddParent(IVisualElement parent)
        {
            this.parent = parent;
        }
    }
    #endregion

}
