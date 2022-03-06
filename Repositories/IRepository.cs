using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Family_GPS_Tracker_Api.Repositories
{
	public interface IRepository<T>
	{
		T GetEntity(Guid id);
		IEnumerable<T> GetEntities();
		void CreateEntity(T item);
		void UpdateEntity(T item);
		void DeleteEntity(T item);
	}
}
