using No1_Online.ViewModels;

namespace No1_Online.Interfaces
{
    public interface ILoadingScheduleService
    {
        public Task<LoadingScheduleVM> GetLoadingSchedule(int? searchId);
    }
}
