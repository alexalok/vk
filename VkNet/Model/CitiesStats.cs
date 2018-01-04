﻿using System;
using Newtonsoft.Json;

namespace VkNet.Model
{
    /// <summary>
    /// Статистика по городу
    /// </summary>
    [Serializable]
    public class CitiesStats
    {
        /// <summary>
        /// идентификатор города;
        /// </summary>
        [JsonProperty("city_id")]
        public ulong CityId { get; set; }

        /// <summary>
        /// число переходов из этого города
        /// </summary>
        [JsonProperty("views")]
        public ulong Views { get; set; }
    }
}