using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using VkNet.Utils;

namespace VkNet.Model.Attachments
{
	/// <summary>
	/// Подкаст
	/// </summary>
	[Serializable]
	public class Podcast : MediaAttachment
	{
		/// <summary>
		/// Заметка пользователя.
		/// </summary>
		static Podcast()
		{
			RegisterType(typeof(Podcast), "podcast");
		}

		/// <summary>
		/// Исполнитель
		/// </summary>
		[JsonProperty("artist")]
		public string Artist { get; set; }

		/// <summary>
		/// Заголовок
		/// </summary>
		[JsonProperty("title")]
		public string Title { get; set; }

		/// <summary>
		/// Длительность
		/// </summary>
		[JsonProperty("duration")]
		public long? Duration { get; set; }

		/// <summary>
		/// Дата
		/// </summary>
		[JsonProperty("date")]
		[JsonConverter(typeof(UnixDateTimeConverter))]
		public DateTime? Date { get; set; }

		/// <summary>
		/// URL на подкаст
		/// </summary>
		[JsonProperty("url")]
		public Uri Url { get; set; }

		/// <summary>
		/// Идентификатор текста песни
		/// </summary>
		[JsonProperty("lyrics_id")]
		public long? LyricsId { get; set; }

		/// <summary>
		/// Не искать
		/// </summary>
		[JsonProperty("no_search")]
		public bool? NoSearch { get; set; }

		/// <summary>
		/// Высокое качество
		/// </summary>
		[JsonProperty("is_hq")]
		public bool? IsHq { get; set; }

		/// <summary>
		/// Явный
		/// </summary>
		[JsonProperty("is_explicit")]
		public bool? IsExplicit { get; set; }

		/// <summary>
		/// Информация о подкасте
		/// </summary>
		[JsonProperty("podcast_info")]
		public PodcastInfo PodcastInfo { get; set; }

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static Podcast FromJson(VkResponse response)
		{
			return new Podcast
			{
				Id = response["id"],
				OwnerId = response["owner_id"],
				Artist = response["artist"],
				Title = response["title"],
				Duration = response["duration"],
				Date = response["date"],
				Url = response["url"],
				LyricsId = response["lyrics_id"],
				NoSearch = response["no_search"],
				IsHq = response["is_hq"],
				IsExplicit = response["is_explicit"],
				PodcastInfo = response["is_explicit"]
			};
		}

		/// <summary>
		/// Разобрать из json.
		/// </summary>
		/// <param name="response"> Ответ сервера. </param>
		/// <returns> </returns>
		public static implicit operator Podcast(VkResponse response)
		{
			if (response == null)
			{
				return null;
			}

			return response.HasToken()
				? FromJson(response)
				: null;
		}
	}
}