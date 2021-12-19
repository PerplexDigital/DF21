using Umbraco.Cms.Core.PropertyEditors;
namespace DF21;

[DataEditor(
    name: "Flex",
    alias: "Perplex.Flex",
    view: "/App_Plugins/Perplex.Flex/perplex.flex.html",
    ValueType = ValueTypes.Json
)]
public class FlexPropertyEditor : DataEditor
{
    public FlexPropertyEditor(IDataValueEditorFactory dataValueEditorFactory) : base(dataValueEditorFactory) { }
}
