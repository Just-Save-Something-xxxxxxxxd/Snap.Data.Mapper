﻿using Snap.Data.Mapper.Model.ExcelBinOutput;
using Snap.Data.Mapper.Model.ExcelBinOutput.Reliquary;
using Snap.Data.Mapper.Pipeline.Abstraction;
using Snap.Data.Mapper.Pipeline.Reliquary.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Snap.Data.Mapper.Pipeline.Reliquary;

public class ReliquarySetGenerator
{
    private readonly string outputFolder;
    private readonly JsonSerializerOptions options;

    private readonly IEnumerable<ReliquarySetExcelConfigData> requarySets;
    private readonly IDictionary<int, IEnumerable<EquipAffixExcelConfigData>> equipAffixMap;

    public ReliquarySetGenerator(
        string outputFolder,
        JsonSerializerOptions options,
        IEnumerable<ReliquarySetExcelConfigData> requarySets,
        IDictionary<int, IEnumerable<EquipAffixExcelConfigData>> equipAffixMap)
    {
        this.outputFolder = outputFolder;
        this.options = options;
        this.requarySets = requarySets;
        this.equipAffixMap = equipAffixMap;
    }

    public void Generate()
    {
        IEnumerable<ReliquarySet> resultCache = requarySets

            // filter out useless sets
            .Where(x => x.EquipAffixId.HasValue)

            .Select(r =>
            {
                IEnumerable<EquipAffixExcelConfigData> equipAffixDatas = equipAffixMap[r.EquipAffixId!.Value];

                return new ReliquarySet
                {
                    SetId = r.SetId,
                    NeedNumber = r.SetNeedNum,
                    Descriptions = equipAffixDatas.Select(data => data.DescTextMapHash.Value),
                };
            });

        IPipeline.GenerateFile<ReliquarySet>(resultCache, outputFolder, options);
    }
}
