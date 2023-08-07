using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Api.Models
{
	public class DataRepository : IDataRepository
	{
		private readonly AppDbContext appDbContext;

		public DataRepository(AppDbContext appDbContext)
		{
			this.appDbContext = appDbContext;
		}

		public async Task<IEnumerable<Record>> GetRecords()
		{
			return await appDbContext.Records.ToListAsync();
		}

		public async Task<Record> GetRecord(int id)
		{
			return await appDbContext.Records.FirstOrDefaultAsync(e =>  e.Id == id);
		}

		public async Task<Record> GetRecordByField(string field)
		{
			return await appDbContext.Records.FirstOrDefaultAsync(e => e.Field == field);
		}

		public async Task<Record> AddRecord(Record record)
		{
			var result = await appDbContext.Records.AddAsync(record);
			await appDbContext.SaveChangesAsync();
			return result.Entity;
		}

		public async Task<Record> UpdateRecord(Record record)
		{
			var result = await appDbContext.Records.FirstOrDefaultAsync(e => e.Id ==  record.Id);

			if (result != null)
			{
				result.Field = record.Field;

				await appDbContext.SaveChangesAsync();

				return result;
			}

			return null;
		}

		public async void DeleteRecord(int id)
		{
			var result = await appDbContext.Records.FirstOrDefaultAsync(e => e.Id == id);
			if (result != null)
			{
				appDbContext.Records.Remove(result);
				await appDbContext.SaveChangesAsync();
			}
		}
	}
}
