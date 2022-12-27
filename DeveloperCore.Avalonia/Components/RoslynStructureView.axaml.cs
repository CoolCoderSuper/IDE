using Avalonia.Controls;
using System.Collections.ObjectModel;

namespace DeveloperCore.Avalonia
{
    public partial class RoslynStructureView : UserControl
    {
        public ObservableCollection<StructureNode> Symbols { get; }

        public RoslynStructureView()
        {
            InitializeComponent();
            Symbols = new ObservableCollection<StructureNode>() { new StructureNode() { Name = "test1", Nodes = new ObservableCollection<StructureNode> { new StructureNode() { Name = "test3"} } }, new StructureNode() { Name = "test2"} };
            tvStructure.Items = Symbols;
        }
    }
    public class StructureNode
    {
        public string Name { get; set; }

        public ObservableCollection<StructureNode> Nodes { get; set; }
    }
}
