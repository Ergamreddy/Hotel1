using Dapper;
using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;

namespace hotel.Repositories;

public interface IStaffRepository
{
    Task<Staff> Create(Staff Item);
    Task<bool> Update(Staff Item);
    Task<bool> Delete(long StaffId);
    Task<Staff> GetById(long StaffId);
    Task<List<Staff>> GetList();
    Task<List<Staff>> GetAllForRooms(long RoomId);



}
    public class StaffRepository : BaseRepository, IStaffRepository

{
    public StaffRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Staff> Create(Staff Item)
    {
        var query = $@"Insert Into Staff(staff_id,name,gender,mobile,shift,position)VALUES(@StaffId,@Name,@Gender,@Mobile,@Shift,@Position) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Staff>(query, Item);
            return res;

        }
    }


    public async Task<bool> Delete(long StaffId)
    {
        var query = $@"DELETE FROM Staff WHERE staff_id=@StaffId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { StaffId });
            return result > 0;

        }
    }

    public async Task<List<Staff>> GetAllForRooms(long RoomId)
    {
        var query = $@"SELECT * FROM Staff WHERE room_id = RoomId";
        using (var con = NewConnection)
            return (await con.QueryAsync<Staff>(query, new { RoomId })).AsList();
    }

    public async Task<Staff> GetById(long StaffId)

    {
        var query = $@"SELECT * FROM Staff WHERE staff_id = @StaffId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Staff>(query, new { StaffId });
    }

    public async Task<List<Staff>> GetList()
    {
        var query = $@"SELECT * FROM Staff";
        List<Staff> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<Staff>(query)).AsList();
        return result;
    }

    public async Task<bool> Update(Staff Item)
    {
        var query = $@"UPDATE Staff SET mobile=@Mobile, shift=@Shift WHERE staff_id=@StaffId";
        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }

    // Task<Staff> IStaffRepository.GetById(long StaffId)
    // {
    //     throw new NotImplementedException();
    // }



    //     Task<Staff> IStaffRepository.GetById(long StaffId)
    // {
    //         throw new NotImplementedException();
    // }
}


