using No1_Online.Models;

namespace No1_Online.ViewModels
{
    public class LoadingScheduleVM
    {
        public LoadingSchedule loadingSchedule = new LoadingSchedule();
        public LoadingScheduleVM(LoadingSchedule loadingSchedule)
        {
            this.loadingSchedule = loadingSchedule;
        }

        public LoadingScheduleVM()
        {
            
        }
    }
}
