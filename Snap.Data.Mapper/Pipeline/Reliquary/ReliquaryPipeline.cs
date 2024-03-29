﻿using Snap.Data.Mapper.Model.ExcelBinOutput;
using Snap.Data.Mapper.Model.ExcelBinOutput.Reliquary;
using Snap.Data.Mapper.Pipeline.Abstraction;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Snap.Data.Mapper.Pipeline.Reliquary;

internal class ReliquaryPipeline : IPipeline
{
    public void Run(string genshinDataFolder, string outputFolder, JsonSerializerOptions options)
    {
        IEnumerable<ReliquaryExcelConfigData> reliquaries = IPipeline
            .GetData<ReliquaryExcelConfigData>(genshinDataFolder, options);

        new ReliquaryGenerator(
            outputFolder,
            options,
            reliquaries)
            .Generate();

        IEnumerable<ReliquarySetExcelConfigData> requarySets = IPipeline
            .GetData<ReliquarySetExcelConfigData>(genshinDataFolder, options);

        IDictionary<int, IEnumerable<EquipAffixExcelConfigData>> equipAffixMap = IPipeline
            .GetData<EquipAffixExcelConfigData>(genshinDataFolder, options)
            .GroupBy(x => x.Id)
            .ToDictionary(group => group.Key, group => group.AsEnumerable());

        new ReliquarySetGenerator(
            outputFolder,
            options,
            requarySets,
            equipAffixMap)
            .Generate();

        IEnumerable<ReliquaryAffixExcelConfigData> reliquaryAffixes = IPipeline
            .GetData<ReliquaryAffixExcelConfigData>(genshinDataFolder, options);

        new ReliquaryAffixGenerator(
            outputFolder,
            options,
            reliquaryAffixes)
            .Generate();

        IEnumerable<ReliquaryMainPropExcelConfigData> reliquaryMainAffixes = IPipeline
            .GetData<ReliquaryMainPropExcelConfigData>(genshinDataFolder, options);

        new ReliquaryMainAffixGenerator(
            outputFolder,
            options,
            reliquaryMainAffixes)
            .Generate();
    }
}