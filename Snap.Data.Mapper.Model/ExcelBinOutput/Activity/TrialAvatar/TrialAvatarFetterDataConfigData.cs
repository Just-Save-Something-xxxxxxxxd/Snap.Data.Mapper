﻿using Snap.Data.Mapper.Model.Common.Param;

namespace Snap.Data.Mapper.Model.ExcelBinOutput.Activity.TrialAvatar;

public class TrialAvatarFetterDataConfigData : DataObject
{
    [JsonPropertyName("avatarId")]
    public int AvatarId { get; set; }

    [JsonPropertyName("HKAMALMFNDH")]
    public int HKAMALMFNDH { get; set; }

    [JsonPropertyName("finishCond")]
    public CondTypeParamList FinishCond { get; set; } = default!;
}
