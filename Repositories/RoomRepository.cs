using Dapper;
using hotel.DTOs;
using hotel.Models;
using hotel.Repositories;

namespace hotel.Repositories;

public interface IRoomRepository
{
    Task<Room> Create(Room Item);
    Task<bool> Update(Room Item);
    Task<bool> Delete(long RoomId);
    Task<Room> GetById(long RoomId);
    Task<List<Room>> GetList();
    Task<List<StaffDTO>> GetAllForRoom(long RoomId);

}
public class RoomRepository : BaseRepository, IRoomRepository
{
    public RoomRepository(IConfiguration configuration) : base(configuration)
    {
    }

    public async Task<Room> Create(Room Item)
    {
        var query = $@"INSERT INTO  rooms(room_id,room_type,facilities,size,price,staff_id)VALUES(@RoomId,@RoomType,@Facilities,@Size,@Price,@StaffId) RETURNING *";
        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Room>(query, Item);
            return res;

        }
    }

    public async Task<bool> Delete(long RoomId)
    {
        var query = $@"DELETE FROM rooms WHERE room_id=@RoomId";

        using (var con = NewConnection)
        {
            var result = await con.ExecuteAsync(query, new { RoomId });
            return result > 0;

        }
    }

    public async Task<List<StaffDTO>> GetAllForRoom(long RoomId)
    {
        var query = $@"SELECT * FROM staff WHERE staff_id = @RoomId";
        using (var con = NewConnection)
            return (await con.QueryAsync<StaffDTO>(query, new { RoomId })).AsList();
    }

    // public Task<List<RoomDTO>> GetAllForRoom(long room_id)
    // {
    //     throw new NotImplementedException();
    // }

    public async Task<Room> GetById(long RoomId)

    {
        var query = $@"SELECT * FROM rooms WHERE room_id = @RoomId";
        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Room>(query, new { RoomId });
    }

    public async Task<List<Room>> GetList()
    {
        var query = $@"SELECT * FROM rooms ";
        List<Room> result;
        using (var con = NewConnection)
            result = (await con.QueryAsync<Room>(query)).AsList();
        return result;
    }

    public async Task<bool> Update(Room Item)
    {
        var query = $@"UPDATE rooms SET room_type = @RoomType, facilities = @Facilities, @price = @Price WHERE room_id = @RoomId";
        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }

    Task<List<StaffDTO>> IRoomRepository.GetAllForRoom(long RoomId)
    {
        throw new NotImplementedException();
    }
}