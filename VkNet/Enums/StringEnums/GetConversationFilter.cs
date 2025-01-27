﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using VkNet.Utils;

namespace VkNet.Enums.StringEnums;

/// <summary>
/// Фильтр беседы
/// </summary>
[StringEnum]
[JsonConverter(typeof(StringEnumConverter), typeof(SnakeCaseNamingStrategy))]
public enum GetConversationFilter
{
	/// <summary>
	/// Все беседы.
	/// </summary>
	[VkNetDefaultValue]
	All,

	/// <summary>
	/// Беседы с непрочитанными сообщениями;
	/// </summary>
	Unread,

	/// <summary>
	/// Беседы, помеченные как важные (только для сообщений сообществ);
	/// </summary>
	Important,

	/// <summary>
	/// Беседы, помеченные как неотвеченные (только для сообщений сообществ).
	/// </summary>
	Unanswered
}