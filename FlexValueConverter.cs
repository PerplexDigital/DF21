using System;
using System.Text.Json;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.PropertyEditors.ValueConverters;

namespace DF21;

public class FlexValueConverter : PropertyValueConverterBase
{
    private readonly NestedContentSingleValueConverter _ncValueConverter;

    public FlexValueConverter(NestedContentSingleValueConverter ncValueConverter) => _ncValueConverter = ncValueConverter;

    public override bool IsConverter(IPublishedPropertyType propertyType)
        => propertyType.EditorAlias == "Perplex.Flex";

    public override Type GetPropertyValueType(IPublishedPropertyType propertyType)
        => typeof(IPublishedElement);

    public override object ConvertIntermediateToObject(IPublishedElement owner, IPublishedPropertyType propertyType, PropertyCacheLevel referenceCacheLevel, object inter, bool preview)
    {
        if (inter is not string json) return null;
        using var doc = JsonDocument.Parse(json);
        if (!doc.RootElement.TryGetProperty("block", out var block)) return null;
        var rawText = block.GetRawText();
        return _ncValueConverter.ConvertIntermediateToObject(owner, propertyType, referenceCacheLevel, rawText, preview);
    }
}
