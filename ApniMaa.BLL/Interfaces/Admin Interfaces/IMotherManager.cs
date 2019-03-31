using ApniMaa.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using ApniMaa.DAL;

namespace ApniMaa.BLL.Interfaces
{
    public interface IMotherManager
    {
        ActionOutput<List<MotherQuestion>> GetMotherQuestions();
        ActionOutput SaveMotherAnswers(List<MotherAnswer> model);
        ActionOutput<MotherModel> UpdateMotherProfile(MotherModel model);
        ActionOutput<MotherModel> GetMotherProfile(int Id);
        ActionOutput<MotherScheduleModel> GetMotherDailySchedule(int Id);
        ActionOutput UpdateMotherDailySchedule(MotherScheduleModel model);
        ActionOutput<List<MotherDishScheduleModel>> GetMotherDishDailySchedule(int Id);
        ActionOutput UpdateMotherDishDailySchedule(List<MotherDishScheduleModel> model);
    }
}
