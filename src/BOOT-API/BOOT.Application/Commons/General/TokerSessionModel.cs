﻿// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Ecomerce.Models.General;
//
//    var tokerSessionModel = TokerSessionModel.FromJson(jsonString);

namespace BOOT.Application.Commons.General
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class TokerSessionModel
    {
        [JsonProperty("userid")]
        public int Userid { get; set; }

        [JsonProperty("dataExpired")]
        public string DataExpired { get; set; }
    }

    public partial class TokerSessionModel
    {
        public static TokerSessionModel FromJson(string json) => JsonConvert.DeserializeObject<TokerSessionModel>(json, BOOT.Application.Commons.General.TokerSessionModelConverter.Settings);
    }

    public static class TokerSessionModelSerialize
    {
        public static string ToJson(this TokerSessionModel self) => JsonConvert.SerializeObject(self, BOOT.Application.Commons.General.TokerSessionModelConverter.Settings);
    }

    internal static class TokerSessionModelConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}