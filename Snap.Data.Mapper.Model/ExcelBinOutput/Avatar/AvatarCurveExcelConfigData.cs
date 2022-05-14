﻿namespace Snap.Data.Mapper.Model.ExcelBinOutput.Avatar;

public class AvatarCurveExcelConfigData : DataObject
{
    [JsonPropertyName("level")]
    public int Level { get; set; }

    [JsonPropertyName("curveInfos")]
    public IList<CurveInfo> CurveInfos { get; set; } = default!;
}
