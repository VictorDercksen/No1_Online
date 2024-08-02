using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class LoadingScheduleDetailsViewModel
    {
        public LoadingSchedule LoadingSchedule { get; set; }

        public LoadingScheduleDetailsViewModel()
        {
            LoadingSchedule = new LoadingSchedule();
        }
    }
}
