﻿using backend.Models;

namespace backend.IRepository
{
    public interface IFirstLocationRepo
    {
          Task<IEnumerable<firstLocation>> getAllFirstLocation();
        //  Task<IEnumerable<busService>> getBusServiceById(int Id);
        //  Task<IEnumerable<busService>> CreateBusService(int Id);
        //  Task<IEnumerable<busService>> putBusService(int Id);
        //  Task<IEnumerable<busService>> deleteBusService(int Id);
    }
}