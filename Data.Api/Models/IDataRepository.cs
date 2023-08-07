using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Api.Models
{
	public interface IDataRepository
	{
		Task<IEnumerable<Record>> GetRecords();
		Task<Record> GetRecord(int id);
		Task<Record> GetRecordByField(string field);
		Task<Record> AddRecord(Record record);
		Task<Record> UpdateRecord(Record record);
		void DeleteRecord(int id);
	}
}
