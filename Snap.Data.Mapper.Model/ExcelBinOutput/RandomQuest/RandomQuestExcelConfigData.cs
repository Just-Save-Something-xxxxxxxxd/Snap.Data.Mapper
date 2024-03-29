﻿using Snap.Data.Mapper.Model.Common.Param;

namespace Snap.Data.Mapper.Model.ExcelBinOutput.RandomQuest;

public class RandomQuestExcelConfigData : DataObject
{
    [JsonPropertyName("subId")]
    public int SubId { get; set; }

    [JsonPropertyName("mainId")]
    public int MainId { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("titleTextMapHash")]
    public Text TitleTextMapHash { get; set; }

    [JsonPropertyName("descTextMapHash")]
    public Text DescTextMapHash { get; set; }

    [JsonPropertyName("acceptCond")]
    public IList<TypeParam<int>> AcceptCond { get; set; } = default!;

    [JsonPropertyName("finishCond")]
    public IList<TypeParamParamStrCount<string>> FinishCond { get; set; } = default!;

    [JsonPropertyName("failCond")]
    public IList<TypeParamParamStrCount<string>> FailCond { get; set; } = default!;

    [JsonPropertyName("guide")]
    public Guide Guide { get; set; } = default!;

    [JsonPropertyName("failParent")]
    public bool FailParent { get; set; }

    [JsonPropertyName("failParentShow")]
    public string FailParentShow { get; set; } = default!;

    [JsonPropertyName("awardItems")]
    public IList<AwardItem> AwardItems { get; set; } = default!;

    [JsonPropertyName("beginExec")]
    public IList<TypeParam<string>> BeginExec { get; set; } = default!;

    [JsonPropertyName("finishExec")]
    public IList<TypeParam<string>> FinishExec { get; set; } = default!;

    [JsonPropertyName("failExec")]
    public IList<TypeParam<string>> FailExec { get; set; } = default!;

    [JsonPropertyName("isRewind")]
    public bool? IsRewind { get; set; }

    [JsonPropertyName("showType")]
    public string ShowType { get; set; } = default!;

    [JsonPropertyName("finishCondComb")]
    public string FinishCondComb { get; set; } = default!;

    [JsonPropertyName("finishParent")]
    public bool? FinishParent { get; set; }

    [JsonPropertyName("exclusiveNpcPriority")]
    public int? ExclusiveNpcPriority { get; set; }

    [JsonPropertyName("acceptCondComb")]
    public string AcceptCondComb { get; set; } = default!;
}
