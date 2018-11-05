﻿using System.Collections.ObjectModel;
using VkNet.Model;

namespace VkNet.Abstractions
{
	/// <summary>
	/// Методы для работы со статистикой.
	/// </summary>
	public interface IStatsCategory : IStatsCategoryAsync
	{
		/// <summary>
		/// Возвращает статистику сообщества или приложения.
		/// </summary>
		/// <param name = "getParams">
		/// Входные параметры запроса.
		/// </param>
		/// <returns>
		/// После успешного выполнения возвращает объект с данными статистики.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stats.get
		/// </remarks>
		ReadOnlyCollection<StatsPeriod> Get(StatsGetParams getParams);

		/// <summary>
		/// Добавляет данные о текущем сеансе в статистику посещаемости приложения..
		/// </summary>
		/// <returns>
		/// В случае успешной обработки данных метод вернет <c> true </c>.
		/// </returns>
		/// <remarks>
		/// Страница документации ВКонтакте http://vk.com/dev/stats.trackVisitor
		/// </remarks>
		bool TrackVisitor();

		/// <summary>
		/// Возвращает статистику для записи на стене.
		/// </summary>
		/// <param name="ownerId">
		/// Идентификатор сообщества — владельца записи. Указывается
		/// со знаком «минус».
		/// </param>
		/// <param name="postId">
		/// Идентификатор записи. Обратите внимание — данные по статистике доступны только
		/// для 300
		/// последних(самых свежих) записей на стене сообщества.
		/// </param>
		/// <returns>
		/// Возвращает результат выполнения метода.
		/// </returns>
		/// <remarks>
		/// Необходимо входить в число руководителей этого сообщества.
		/// Страница документации ВКонтакте https://vk.com/dev/stats.getPostReach
		/// </remarks>
		PostReach GetPostReach(long ownerId, long postId);
	}
}